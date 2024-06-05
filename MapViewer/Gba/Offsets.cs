using LOGExtractor.Gba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO.Hashing;

namespace LOGExtractor.Gba
{
    internal class Offsets
    {
        public int NumberOfMaps { get; set; }
        public int AreaInfo { get; set; }
        public int TilesetImage { get; set; }
        public int BGPalette { get; set; }
        public int MapNames { get; set; }

        public Offsets(byte[] rom)
        {
            var crc32 = Crc32.HashToUInt32(rom);

            switch(crc32)
            {
                case 0xb3297d59: //LOG 2 International (Japan)
                    NumberOfMaps = 0x1c4;
                    AreaInfo = 0x44BA28;
                    TilesetImage = 0x521CF8;
                    BGPalette = 0x21D864;
                    MapNames = 0;
                    break;
                case 0x01c1707f: //LOG Buu's Fury (USA)
                    NumberOfMaps = 0x1c4;
                    AreaInfo = 0x08e2e0;
                    TilesetImage = 0x179764;
                    BGPalette = 0x05632c;
                    MapNames = 0x06bce8;
                    break;
                default:
                    throw new Exception($"Unknown ROM CRC32 {crc32:X8}");
            }
        }
    }
}
