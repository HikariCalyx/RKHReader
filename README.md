# RKHReader
A tool to read the root key hash from most Qualcomm signed binaries/dsp firmwares/partitions (works on both last decade and modern day devices!)

# Usage
1. Download and install .NET 6.0 Runtime based on your architecture here: https://dotnet.microsoft.com/download/dotnet/6.0
2. [Download the build from Releases](https://github.com/HikariCalyx/RKHReader/releases/latest) page.
3. Open a command prompt at where you extracted the RKHReader.
4. Execute this command to check the Qualcomm ELF image (e.g. aboot, abl, xbl, xbl_config, tz, rpm, keymaster, firehose programmer) you obtained from wherever you extracted:
   ```
   rkhreader path\to\the\bsp\image\you\extracted\such\as\abl.elf
   ```
6. Then RKHReader will output the RKH value of the BSP image.
   ```
   path\to\the\bsp\image\you\extracted\such\as\abl.elf
   RKH: 1030CD12CE708F29D6914D7529DF75149D8EF91C27DAF0E1F84B90F4B707329A
   ```
7. You can check another ELF image from a different build. Let's say we examined RKH inside of an ELF image extracted from an enginnering sample, then we also examined RKH from the retail build of that unit. If RKH between these 2 builds are identical, then enginnering sample ELF images are compatible with retail unit and will not hard brick your secure boot enabled retail unit. Otherwise it will hard brick your retail unit at 900E state.
8. Comparing to original build from WOA-Project, this fork added following feature(s):
  * Detect if BSD image contains Qualcomm Generic Test Signature, which has a fixed RKH value: ```959B8D0549EF41BEFABC24F51EFE84FEE366AC169AB04A0DB30C799B324FD798``` If the ELF image has that RKH value, RKHReader will warn you.

# TODO
* Add dry output parameter for script optimization
* Add feature of comparing RKH between 2 ELF images

# Why make a fork of this?
Some OEMs don't provide a normal bootloader unlock method (especially the triple-color company), so we have to discover the engineering sample unit with OEM retail signature and OEM Unlock command untouched from ABL partition. We bricked some units without acknowledging how it works on background. After that, we have learned that RKH from ELF image extracted from engineering sample units must match retail unit.
