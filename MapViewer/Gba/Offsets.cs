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
        public int BGPalette24Bit { get; set; }
        public int MapNames { get; set; }

        public Offsets(byte[] rom)
        {
            var crc32 = Crc32.HashToUInt32(rom);

            BGPalette24Bit = 0;

            switch (crc32)
            {
                case 0xb3297d59: //LOG 2 International (Japan)
                    NumberOfMaps    = 0x1c4;  //wrong
                    AreaInfo        = 0x44BA28;
                    TilesetImage    = 0x521CF8;
                    BGPalette       = 0x21D864;
                    MapNames        = 0;
                    break;
                case 0x01c1707f: //LOG Buu's Fury (USA)
                    NumberOfMaps    = 452;
                    AreaInfo        = 0x8e2e0;
                    TilesetImage    = 0x179764;
                    BGPalette       = 0x5632c;
                    MapNames        = 0x6bce8;
                    break;
                case 0x02b545c8: //DBZ3_cart22.GBA
                    NumberOfMaps    = 0x1c4; //wrong
                    AreaInfo        = 0x8AEF4;
                    TilesetImage    = 0x1094F4;
                    BGPalette       = 0x5632c; //wrong
                    MapNames        = 0;
                    break;
                case 0x77b85569: //DBZBUUSFURY_BG3E00_cart21.gba
                    NumberOfMaps    = 452;
                    AreaInfo        = 0xCF834;
                    TilesetImage    = 0x1B9180;
                    BGPalette       = 0x579CC;
                    MapNames        = 0x6C9C8;
                    break;
                case 0x54569bca: //DBZBUUSFURY_BG3E00_cart33.gba
                    NumberOfMaps    = 452;
                    AreaInfo        = 0xCF834;
                    TilesetImage    = 0x1B9180;
                    BGPalette       = 0x579CC;
                    MapNames        = 0x6C9C8;
                    break;
                case 0x2bebd716: //DBZ3_cart13.GBA
                    NumberOfMaps    = 431;
                    AreaInfo        = 0x8AEF4;
                    TilesetImage    = 0x1094F4;
                    BGPalette       = 0;
                    MapNames        = 0x30CEC;
                    BGPalette24Bit  = 0x7E660;
                    break;
                case 0x865b15ba: //DBZ3_cart14.GBA
                    NumberOfMaps    = 23;
                    AreaInfo        = 0x65CD8;
                    TilesetImage    = 0x7C0EC;
                    BGPalette       = 0;
                    MapNames        = 0x1D590;
                    BGPalette24Bit  = 0x628F4;
                    break;
                default:
                    throw new Exception($"Unknown ROM CRC32 {crc32:X8}");
            }
        }
    }
}
