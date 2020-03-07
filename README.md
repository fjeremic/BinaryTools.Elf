# BinaryTools.Elf
[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg?style=flat-square)](https://github.com/fjeremic/BinaryTools.Elf/blob/master/LICENSE)

A standalone library for endian-aware reading/parsing of ELF (Executable and Linkable Format) files built for ease of use and pretty-printing ELF file contents.

## Installing / Getting started

The best way to obtain the library is via the [BinaryTools.Elf NuGet package](https://www.nuget.org/packages/BinaryTools.Elf/):
 
```shell
dotnet add package BinaryTools.Elf
```

Alternatively you may clone this git repository and build the library for use within your projects:

```shell
dotnet build
```

## Examples

To demonstrate the capabilities and ease of use of this library we will recreate most of the capabilities of the `readelf` utility in a series of examples.

### Setup

First we open up the binary with our endian aware reader:

```csharp
var stream = new FileStream("Binaries/base32", FileMode.Open, FileAccess.Read);
var reader = new EndianBinaryReader(stream, EndianBitConverter.NativeEndianness);
ElfFile elfFile = ElfFile.ReadElfFile(reader);
```

### Recreating `readelf --file-header`

```csharp
Console.WriteLine("ELF Header:");
Console.Write("  Magic:  ");

for (Int32 i = 0; i < 16; ++i)
{
    Console.Write(" {0:x2}", reader.ReadByte());
}

Console.WriteLine();
Console.WriteLine($"  Class:                             {elfFile.Header.Class.GetDescription()}");
Console.WriteLine($"  Data:                              {elfFile.Header.Data.GetDescription()}");
Console.WriteLine($"  Version:                           {elfFile.Header.Version}");
Console.WriteLine($"  OS / ABI:                          {elfFile.Header.OSABI.GetDescription()}");
Console.WriteLine($"  ABI Version:                       {elfFile.Header.OSABIVersion}");
Console.WriteLine($"  Type:                              {elfFile.Header.Type.GetDescription()}");
Console.WriteLine($"  Machine:                           {elfFile.Header.Machine.GetDescription()}");
Console.WriteLine($"  Version:                           0x{elfFile.Header.Version:x8}");
Console.WriteLine($"  Entry point address:               0x{elfFile.Header.EntryOffset:x16}");
Console.WriteLine($"  Start of program headers:          {elfFile.Header.ProgramHeaderOffset}");
Console.WriteLine($"  Start of section headers:          {elfFile.Header.SectionHeaderOffset}");
Console.WriteLine($"  Flags:                             0x{elfFile.Header.Flags:x8}");
Console.WriteLine($"  Size of this header:               {elfFile.Header.Size}");
Console.WriteLine($"  Size of program headers:           {elfFile.Header.ProgramHeaderSize}");
Console.WriteLine($"  Number of program headers:         {elfFile.Header.ProgramHeaderEntryCount}");
Console.WriteLine($"  Size of section headers:           {elfFile.Header.SectionHeaderSize}");
Console.WriteLine($"  Number of section headers:         {elfFile.Header.SectionHeaderEntryCount}");
Console.WriteLine($"  Section header string table index: {elfFile.Header.StringSectionIndex}");
```

Which outputs:

```
ELF Header:
  Magic:   7f 45 4c 46 02 01 01 00 00 00 00 00 00 00 00 00
  Class:                             ELF64
  Data:                              2's complement, little endian
  Version:                           1
  OS / ABI:                          No extensions or unspecified
  ABI Version:                       0
  Type:                              Executable file
  Machine:                           AMD x86-64 architecture
  Version:                           0x00000001
  Entry point address:               0x00000000004019e0
  Start of program headers:          64
  Start of section headers:          37808
  Flags:                             0x00000000
  Size of this header:               64
  Size of program headers:           56
  Number of program headers:         9
  Size of section headers:           64
  Number of section headers:         29
  Section header string table index: 28
```

### Recreating `readelf --sections`

```csharp
Console.WriteLine("Section Headers:");
Console.WriteLine("  [Nr] Name              Type             Address           Offset");
Console.WriteLine("       Size              EntSize          Flags  Link  Info  Align");

for (Int32 i = 0; i < elfFile.Sections.Count; ++i)
{
    String name = elfFile.Sections[i].Name.PadRight(20).Substring(0, 17);

    Console.WriteLine(
        $"  " +
        $"[{i:d2}] " +
        $"{name} " +
        $"{elfFile.Sections[i].Type.GetDescription().PadRight(16)} " +
        $"{elfFile.Sections[i].Address:x16}  " +
        $"{elfFile.Sections[i].Offset:x8}");


    Console.WriteLine(
        $"       " +
        $"{elfFile.Sections[i].Size:x16}  " +
        $"{elfFile.Sections[i].EntrySize:x16}  " +
        $"{(UInt16)elfFile.Sections[i].Flags:x4}  " +
        $"{elfFile.Sections[i].Link.ToString().PadLeft(4)} " +
        $"{elfFile.Sections[i].Info.ToString().PadLeft(5)} " +
        $"{elfFile.Sections[i].Alignment.ToString().PadLeft(5)}");
}
```

Which outputs:

```
Section Headers:
  [Nr] Name              Type             Address           Offset
       Size              EntSize          Flags  Link  Info  Align
  [00]                   Null             0000000000000000  00000000
       0000000000000000  0000000000000000  0000     0     0     0
  [01] .interp           ProgBits         0000000000400238  00000238
       000000000000001c  0000000000000000  0002     0     0     1
  [02] .note.ABI-tag     Note             0000000000400254  00000254
       0000000000000020  0000000000000000  0002     0     0     4
  [03] .note.gnu.build-i Note             0000000000400274  00000274
       0000000000000024  0000000000000000  0002     0     0     4
  [04] .gnu.hash         1879048182       0000000000400298  00000298
       0000000000000048  0000000000000000  0002     5     0     8
  [05] .dynsym           DynSym           00000000004002e0  000002e0
       0000000000000678  0000000000000018  0002     6     1     8
  [06] .dynstr           StrTab           0000000000400958  00000958
       00000000000002e0  0000000000000000  0002     0     0     1
  [07] .gnu.version      1879048191       0000000000400c38  00000c38
       000000000000008a  0000000000000002  0002     5     0     2
  [08] .gnu.version_r    1879048190       0000000000400cc8  00000cc8
       0000000000000060  0000000000000000  0002     6     1     8
  [09] .rela.dyn         RelA             0000000000400d28  00000d28
       00000000000000c0  0000000000000018  0002     5     0     8
  [10] .rela.plt         RelA             0000000000400de8  00000de8
       0000000000000570  0000000000000018  0042     5    24     8
  [11] .init             ProgBits         0000000000401358  00001358
       000000000000001a  0000000000000000  0006     0     0     4
  [12] .plt              ProgBits         0000000000401380  00001380
       00000000000003b0  0000000000000010  0006     0     0    16
  [13] .plt.got          ProgBits         0000000000401730  00001730
       0000000000000008  0000000000000000  0006     0     0     8
  [14] .text             ProgBits         0000000000401740  00001740
       0000000000004489  0000000000000000  0006     0     0    16
  [15] .fini             ProgBits         0000000000405bcc  00005bcc
       0000000000000009  0000000000000000  0006     0     0     4
  [16] .rodata           ProgBits         0000000000405be0  00005be0
       00000000000014bd  0000000000000000  0002     0     0    32
  [17] .eh_frame_hdr     ProgBits         00000000004070a0  000070a0
       000000000000029c  0000000000000000  0002     0     0     4
  [18] .eh_frame         ProgBits         0000000000407340  00007340
       0000000000000e24  0000000000000000  0002     0     0     8
  [19] .init_array       InitArray        0000000000608e10  00008e10
       0000000000000008  0000000000000000  0003     0     0     8
  [20] .fini_array       FiniArray        0000000000608e18  00008e18
       0000000000000008  0000000000000000  0003     0     0     8
  [21] .jcr              ProgBits         0000000000608e20  00008e20
       0000000000000008  0000000000000000  0003     0     0     8
  [22] .dynamic          Dynamic          0000000000608e28  00008e28
       00000000000001d0  0000000000000010  0003     6     0     8
  [23] .got              ProgBits         0000000000608ff8  00008ff8
       0000000000000008  0000000000000008  0003     0     0     8
  [24] .got.plt          ProgBits         0000000000609000  00009000
       00000000000001e8  0000000000000008  0003     0     0     8
  [25] .data             ProgBits         0000000000609200  00009200
       0000000000000074  0000000000000000  0003     0     0    32
  [26] .bss              NoBits           0000000000609280  00009274
       00000000000001c0  0000000000000000  0003     0     0    32
  [27] .gnu_debuglink    ProgBits         0000000000000000  00009274
       0000000000000034  0000000000000000  0000     0     0     1
  [28] .shstrtab         StrTab           0000000000000000  000092a8
       0000000000000102  0000000000000000  0000     0     0     1
```

### Recreating `readelf --segments`

```csharp
Console.WriteLine("Program Headers:");
Console.WriteLine("  Type           Offset             VirtAddr           PhysAddr");
Console.WriteLine("                 FileSiz            MemSiz              Flags  Align");

for (Int32 i = 0; i < elfFile.Segments.Count; ++i)
{
    Console.WriteLine(
        $"  {elfFile.Segments[i].Type.GetDescription().PadRight(15)}" +
        $"0x{elfFile.Segments[i].Offset:x16} " +
        $"0x{elfFile.Segments[i].VirtualAddress:x16} " +
        $"0x{elfFile.Segments[i].PhysicalAddress:x16}");

    String flags =
        (elfFile.Segments[i].Flags.HasFlag(ElfSegmentFlags.Read) ? "R" : " ") +
        (elfFile.Segments[i].Flags.HasFlag(ElfSegmentFlags.Write) ? "W" : " ") +
        (elfFile.Segments[i].Flags.HasFlag(ElfSegmentFlags.Exec) ? "E" : " ");

    Console.WriteLine(
        $"                 " +
        $"0x{elfFile.Segments[i].FileSize:x16} " +
        $"0x{elfFile.Segments[i].MemorySize:x16}  " +
        $"{flags}    " +
        $"{elfFile.Segments[i].Alignment}");
}

Console.WriteLine();
Console.WriteLine(" Section to Segment mapping:");
Console.WriteLine("  Segment Sections...");

for (Int32 i = 0; i < elfFile.Segments.Count; ++i)
{
    Console.Write($"   {i:d2}    ");

    foreach (var section in elfFile.Segments[i].Sections)
    {
        Console.Write($" {section.Name}");
    }

    Console.WriteLine();
}
```

Which outputs:

```
Program Headers:
  Type           Offset             VirtAddr           PhysAddr
                 FileSiz            MemSiz              Flags  Align
  PHdr           0x0000000000000040 0x0000000000400040 0x0000000000400040
                 0x00000000000001f8 0x00000000000001f8  R E    8
  Interp         0x0000000000000238 0x0000000000400238 0x0000000000400238
                 0x000000000000001c 0x000000000000001c  R      1
  Load           0x0000000000000000 0x0000000000400000 0x0000000000400000
                 0x0000000000008164 0x0000000000008164  R E    2097152
  Load           0x0000000000008e10 0x0000000000608e10 0x0000000000608e10
                 0x0000000000000464 0x0000000000000630  RW     2097152
  Dynamic        0x0000000000008e28 0x0000000000608e28 0x0000000000608e28
                 0x00000000000001d0 0x00000000000001d0  RW     8
  Note           0x0000000000000254 0x0000000000400254 0x0000000000400254
                 0x0000000000000044 0x0000000000000044  R      4
  1685382480     0x00000000000070a0 0x00000000004070a0 0x00000000004070a0
                 0x000000000000029c 0x000000000000029c  R      4
  1685382481     0x0000000000000000 0x0000000000000000 0x0000000000000000
                 0x0000000000000000 0x0000000000000000  RW     16
  1685382482     0x0000000000008e10 0x0000000000608e10 0x0000000000608e10
                 0x00000000000001f0 0x00000000000001f0  R      1

 Section to Segment mapping:
  Segment Sections...
   00
   01     .interp
   02     .interp .note.ABI-tag .note.gnu.build-id .gnu.hash .dynsym .dynstr .gnu.version .gnu.version_r .rela.dyn .rela.plt .init .plt .plt.got .text .fini .rodata .eh_frame_hdr .eh_frame
   03     .init_array .fini_array .jcr .dynamic .got .got.plt .data .bss
   04     .dynamic
   05     .note.ABI-tag .note.gnu.build-id
   06     .eh_frame_hdr
   07
   08     .init_array .fini_array .jcr .dynamic .got
```

### Recreating `readelf --dynamic`

```csharp
foreach (var dynamicSection in elfFile.Sections.OfType<ElfDynamicSection>())
{
    Console.WriteLine($"Dynamic section at offset 0x{dynamicSection.Offset:x} contains {dynamicSection.Count} entries:");
    Console.WriteLine($"  Tag               Type                  Name / Value");

    foreach (ElfDynamicEntry entry in dynamicSection)
    {
        String valueOrName = entry.Name != String.Empty ? entry.Name : $"{entry.Value:x8}";
        Console.WriteLine(
            $" 0x{(Int64)entry.Tag:x16} " +
            $"({entry.Tag.GetDescription()}) ".PadRight(22) +
            $"{valueOrName}");
    }
}
```

Which outputs:

```
Dynamic section at offset 0x8e28 contains 24 entries:
  Tag               Type                  Name / Value
 0x0000000000000001 (NEEDED)              libc.so.6
 0x000000000000000c (INIT)                00401358
 0x000000000000000d (FINI)                00405bcc
 0x0000000000000019 (INIT_ARRAY)          00608e10
 0x000000000000001b (INIT_ARRAYSZ)        00000008
 0x000000000000001a (FINI_ARRAY)          00608e18
 0x000000000000001c (FINI_ARRAYSZ)        00000008
 0x000000006ffffef5 (1879047925)          00400298
 0x0000000000000005 (STRTAB)              00400958
 0x0000000000000006 (SYMTAB)              004002e0
 0x000000000000000a (STRSZ)               000002e0
 0x000000000000000b (SYMENT)              00000018
 0x0000000000000015 (DEBUG)               00000000
 0x0000000000000003 (PLTGOT)              00609000
 0x0000000000000002 (PLTRELSZ)            00000570
 0x0000000000000014 (PLTREL)              00000007
 0x0000000000000017 (JMPREL)              00400de8
 0x0000000000000007 (RELA)                00400d28
 0x0000000000000008 (RELASZ)              000000c0
 0x0000000000000009 (RELAENT)             00000018
 0x000000006ffffffe (1879048190)          00400cc8
 0x000000006fffffff (1879048191)          00000001
 0x000000006ffffff0 (1879048176)          00400c38
 0x0000000000000000 (NULL)                00000000
```

### Recreating `readelf --relocs`

```csharp
foreach (var relcationSection in elfFile.Sections.OfType<ElfRelocationSection>())
{
    Console.WriteLine($"Relocation section '{relcationSection.Name}' at offset 0x{relcationSection.Offset:x} contains {relcationSection.Count} entries:");
    Console.WriteLine($"  Offset          Info             Type     Sym. Value       Sym. Name + Addend");

    foreach (ElfRelocationEntry entry in relcationSection)
    {
        Console.WriteLine(
            $"{entry.Offset:x16}  " +
            $"{entry.Info:x16} " +
            $"{entry.Type:x8} " +
            $"{entry.SymbolValue:x16} " +
            $"{entry.Symbol} + {entry.Addend}");
    }

    Console.WriteLine();
}
```

Which outputs:

```
Relocation section '.rela.dyn' at offset 0xd28 contains 8 entries:
  Offset          Info             Type     Sym. Value       Sym. Name + Addend
0000000000608ff8  0000002300000006 00000006 0000000000000000 __gmon_start__ + 0
0000000000609280  0000003d00000005 00000005 0000000000609280 __progname + 0
0000000000609288  0000003c00000005 00000005 0000000000609288 stdout + 0
0000000000609290  0000003e00000005 00000005 0000000000609290 stdin + 0
0000000000609298  0000004300000005 00000005 0000000000609298 optind + 0
00000000006092a0  0000004400000005 00000005 00000000006092a0 optarg + 0
00000000006092a8  0000004000000005 00000005 00000000006092a8 __progname_full + 0
00000000006092c0  0000004200000005 00000005 00000000006092c0 stderr + 0

Relocation section '.rela.plt' at offset 0xde8 contains 58 entries:
  Offset          Info             Type     Sym. Value       Sym. Name + Addend
0000000000609018  0000000100000007 00000007 0000000000000000 __uflow + 0
0000000000609020  0000000200000007 00000007 0000000000000000 getenv + 0
0000000000609028  0000000300000007 00000007 0000000000000000 free + 0
0000000000609030  0000000400000007 00000007 0000000000000000 abort + 0
0000000000609038  0000000500000007 00000007 0000000000000000 __errno_location + 0
0000000000609040  0000000600000007 00000007 0000000000000000 strncmp + 0
0000000000609048  0000000700000007 00000007 0000000000000000 _exit + 0
0000000000609050  0000000800000007 00000007 0000000000000000 __fpending + 0
0000000000609058  0000000900000007 00000007 0000000000000000 fread_unlocked + 0
0000000000609060  0000000a00000007 00000007 0000000000000000 textdomain + 0
0000000000609068  0000000b00000007 00000007 0000000000000000 fclose + 0
0000000000609070  0000000c00000007 00000007 0000000000000000 bindtextdomain + 0
0000000000609078  0000000d00000007 00000007 0000000000000000 dcgettext + 0
0000000000609080  0000000e00000007 00000007 0000000000000000 __ctype_get_mb_cur_max + 0
0000000000609088  0000000f00000007 00000007 0000000000000000 strlen + 0
0000000000609090  0000001000000007 00000007 0000000000000000 __stack_chk_fail + 0
0000000000609098  0000001100000007 00000007 0000000000000000 getopt_long + 0
00000000006090a0  0000001200000007 00000007 0000000000000000 mbrtowc + 0
00000000006090a8  0000001300000007 00000007 0000000000000000 strchr + 0
00000000006090b0  0000001400000007 00000007 0000000000000000 __overflow + 0
00000000006090b8  0000001500000007 00000007 0000000000000000 strrchr + 0
00000000006090c0  0000001600000007 00000007 0000000000000000 lseek + 0
00000000006090c8  0000001700000007 00000007 0000000000000000 __assert_fail + 0
00000000006090d0  0000001800000007 00000007 0000000000000000 __strtoul_internal + 0
00000000006090d8  0000001900000007 00000007 0000000000000000 memset + 0
00000000006090e0  0000001a00000007 00000007 0000000000000000 fscanf + 0
00000000006090e8  0000001b00000007 00000007 0000000000000000 close + 0
00000000006090f0  0000001c00000007 00000007 0000000000000000 posix_fadvise + 0
00000000006090f8  0000001d00000007 00000007 0000000000000000 memchr + 0
0000000000609100  0000001e00000007 00000007 0000000000000000 __libc_start_main + 0
0000000000609108  0000001f00000007 00000007 0000000000000000 memcmp + 0
0000000000609110  0000002000000007 00000007 0000000000000000 fputs_unlocked + 0
0000000000609118  0000002100000007 00000007 0000000000000000 calloc + 0
0000000000609120  0000002200000007 00000007 0000000000000000 strcmp + 0
0000000000609128  0000002400000007 00000007 0000000000000000 memcpy + 0
0000000000609130  0000002500000007 00000007 0000000000000000 fileno + 0
0000000000609138  0000002600000007 00000007 0000000000000000 malloc + 0
0000000000609140  0000002700000007 00000007 0000000000000000 fflush + 0
0000000000609148  0000002800000007 00000007 0000000000000000 nl_langinfo + 0
0000000000609150  0000002900000007 00000007 0000000000000000 ungetc + 0
0000000000609158  0000002a00000007 00000007 0000000000000000 __freading + 0
0000000000609160  0000002b00000007 00000007 0000000000000000 fwrite_unlocked + 0
0000000000609168  0000002c00000007 00000007 0000000000000000 realloc + 0
0000000000609170  0000002d00000007 00000007 0000000000000000 fdopen + 0
0000000000609178  0000002e00000007 00000007 0000000000000000 setlocale + 0
0000000000609180  0000002f00000007 00000007 0000000000000000 __printf_chk + 0
0000000000609188  0000003000000007 00000007 0000000000000000 memmove + 0
0000000000609190  0000003100000007 00000007 0000000000000000 error + 0
0000000000609198  0000003200000007 00000007 0000000000000000 open + 0
00000000006091a0  0000003300000007 00000007 0000000000000000 fseeko + 0
00000000006091a8  0000003400000007 00000007 0000000000000000 fopen + 0
00000000006091b0  0000003500000007 00000007 0000000000000000 __cxa_atexit + 0
00000000006091b8  0000003600000007 00000007 0000000000000000 exit + 0
00000000006091c0  0000003700000007 00000007 0000000000000000 fwrite + 0
00000000006091c8  0000003800000007 00000007 0000000000000000 __fprintf_chk + 0
00000000006091d0  0000003900000007 00000007 0000000000000000 mbsinit + 0
00000000006091d8  0000003a00000007 00000007 0000000000000000 iswprint + 0
00000000006091e0  0000003b00000007 00000007 0000000000000000 __ctype_b_loc + 0
```

### Recreating `readelf --symbols`

```csharp
foreach (var symbolTable in elfFile.Sections.OfType<ElfSymbolTable>())
{
    Console.WriteLine($"Symbol table '{symbolTable.Name}' contains {symbolTable.Count} entries:");
    Console.WriteLine($"   Num:    Value          Size Type    Bind   Vis      Ndx Name");

    for (Int32 i = 0; i < symbolTable.Count; ++i)
    {
        String index = symbolTable[i].ShIndex == 0 ? "UND" : $"{symbolTable[i].ShIndex:d3}";

        Console.WriteLine(
            $"{i:d6}: " +
            $"{symbolTable[i].Value:x16} " +
            $"{symbolTable[i].Size:d5} " +
            $"{symbolTable[i].Type.GetDescription().PadRight(7)} " +
            $"{symbolTable[i].Binding.GetDescription().PadRight(6)} " +
            $"{symbolTable[i].Visibility.GetDescription().PadRight(8)} " +
            $"{index} " +
            $"{symbolTable[i].Name}");
    }

    Console.WriteLine();
}
```

Which outputs:

```
Symbol table '.dynsym' contains 69 entries:
   Num:    Value          Size Type    Bind   Vis      Ndx Name
000000: 0000000000000000 00000 NOTYPE  LOCAL  DEFAULT  UND
000001: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __uflow
000002: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND getenv
000003: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND free
000004: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND abort
000005: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __errno_location
000006: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND strncmp
000007: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND _exit
000008: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __fpending
000009: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fread_unlocked
000010: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND textdomain
000011: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fclose
000012: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND bindtextdomain
000013: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND dcgettext
000014: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __ctype_get_mb_cur_max
000015: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND strlen
000016: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __stack_chk_fail
000017: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND getopt_long
000018: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND mbrtowc
000019: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND strchr
000020: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __overflow
000021: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND strrchr
000022: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND lseek
000023: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __assert_fail
000024: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __strtoul_internal
000025: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND memset
000026: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fscanf
000027: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND close
000028: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND posix_fadvise
000029: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND memchr
000030: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __libc_start_main
000031: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND memcmp
000032: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fputs_unlocked
000033: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND calloc
000034: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND strcmp
000035: 0000000000000000 00000 NOTYPE  WEAK   DEFAULT  UND __gmon_start__
000036: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND memcpy
000037: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fileno
000038: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND malloc
000039: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fflush
000040: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND nl_langinfo
000041: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND ungetc
000042: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __freading
000043: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fwrite_unlocked
000044: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND realloc
000045: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fdopen
000046: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND setlocale
000047: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __printf_chk
000048: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND memmove
000049: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND error
000050: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND open
000051: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fseeko
000052: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fopen
000053: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __cxa_atexit
000054: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND exit
000055: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND fwrite
000056: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __fprintf_chk
000057: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND mbsinit
000058: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND iswprint
000059: 0000000000000000 00000 FUNC    GLOBAL DEFAULT  UND __ctype_b_loc
000060: 0000000000609288 00008 OBJECT  GLOBAL DEFAULT  026 stdout
000061: 0000000000609280 00008 OBJECT  GLOBAL DEFAULT  026 __progname
000062: 0000000000609290 00008 OBJECT  GLOBAL DEFAULT  026 stdin
000063: 00000000006092a8 00008 OBJECT  WEAK   DEFAULT  026 program_invocation_name
000064: 00000000006092a8 00008 OBJECT  GLOBAL DEFAULT  026 __progname_full
000065: 0000000000609280 00008 OBJECT  WEAK   DEFAULT  026 program_invocation_short_name
000066: 00000000006092c0 00008 OBJECT  GLOBAL DEFAULT  026 stderr
000067: 0000000000609298 00004 OBJECT  GLOBAL DEFAULT  026 optind
000068: 00000000006092a0 00008 OBJECT  GLOBAL DEFAULT  026 optarg
```

## Tests

A set of unit tests covers all features of the library by comparing the result against the output of `readelf -a` for a particular binary found in the `Binaries` directory. To run the tests simply:

```shell
dotnet build
dotnet test
```