﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Tiled;
using System;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room3 : Actor
    {
        ExitNotifier exitNotifier;
        CameraMan cameraMan;
        private TileMap tileMap2; // Declare tileMap1 as a class field
        private Dog dog;         // Declare dog as a class field
        Placeholder placeholder = new Placeholder();
        private Mail mail;
        Song song;
        SoundEffect soundEffect;
        SoundEffect soundEffect2;
        private bool soundPlayed = false;

        public Room3(Vector2 screenSize, ExitNotifier exitNotifier, CameraMan cameraMan)
        {
            this.exitNotifier = exitNotifier;
            this.cameraMan = cameraMan;

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room3_floor.csv");
            tileMap2 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room3_tiles.csv");
            var tileMap3 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room3_decoration.csv");


            dog = new Dog(tileMap2);
            int[] phohibiTiles = [ 
                ///block1
                103,104,107,110,113,114,203,208,209,214,301,303,304,305,306,307,308,309,310,311,312,313,314,316,
                401,402,403,404,405,406,407,408,409,410,411,412,413,414,412,416,500,501,502,503,504,506,507,
                508,509,510,511,512,513,514,515,516,517,600,601,602,603,604,605,606,607,608,609,610,611,612,613,
                614,615,616,617,700,701,702,703,704,705,706,707,708,709,710,711,712,713,714,715,716,717,800,801,
                802,803,804,805,806,807,808,809,810,811,812,813,814,815,816,817,900,901,902,903,904,905,906,907,
                908,909,910,911,912,913,914,915,916,917,1000,1001,1002,1003,1004,1005,1006,1007,1008,1009,1010,1011,
                1012,1013,1014,1015,1016,1017,1100,1101,1102,1103,1104,1105,1106,1107,1108,1109,1110,1111,1112,1113,
                1114,1115,1116,1117,
                //block2
                1202,1203,1204,1205,1206,1207,1208,1209,1210,1211,1212,1213,1214,1215,1302,1303,1304,1305,1306,1307,
                1308,1309,1310,1311,1312,1313,1314,1315,1402,1403,1404,1405,1406,1407,1408,1409,1410,1411,1412,1413,
                1414,1415,1502,1503,1504,1505,1506,1507,1508,1509,1510,1511,1512,1513,1514,1515,1602,1603,1604,1605,
                1606,1607,1608,1609,1610,1611,1612,1613,1614,1615,
                //block3
                1704,1705,1706,1707,1710,1711,1712,1713,1804,1805,1806,1807,1810,1811,1812,1813,
                1904,1905,1906,1907,1910,1911,1912,1913,
                //block4
                2100,2101,2102,2103,2104,2105,2106,2107,2108,2109,2110,2111,2112,2113,2114,2115,2116,2117,
                2200,2201,2202,2203,2204,2205,2206,2207,2208,2209,2210,2211,2212,2213,2214,2215,2216,2217,
                2300,2301,2302,2303,2304,2305,2306,2307,2308,2309,2310,2311,2312,2313,2314,2315,2316,2317,
                2400,2401,2402,2403,2404,2405,2406,2407,2408,2409,2410,2411,2412,2413,2414,2415,2416,2417,
                2500,2501,2502,2503,2504,2505,2506,2507,2508,2509,2510,2511,2512,2513,2514,2515,2516,2517,
                //block5
                2602,2603,2604,2605,2606,2607,2608,2609,2610,2611,2612,2613,2614,2615,
                2702,2703,2704,2705,2706,2707,2708,2709,2710,2711,2712,2713,2714,2715,
                2802,2803,2804,2805,2806,2807,2808,2809,2810,2811,2812,2813,2814,2815,
                2902,2903,2904,2905,2906,2907,2908,2909,2910,2911,2912,2913,2914,2915,
                3002,3003,3004,3005,3006,3007,3008,3009,3010,3011,3012,3013,3014,3015,
                //block6
                3104,3105,3106,3107,3110,3111,3112,3113,3204,3205,3206,3207,3210,3211,3212,3213,
                3304,3305,3306,3307,3310,3311,3312,3313,
                //block7
                118,119,120,121,122,124,125,126,127,128,218,222, 224,228,318,322,324,328,418,422,424,428,
                518,522,524,528,618,619,620,621,622,624,628,718,722,724,726,728,818,822,824,826,828,918,
                922,924,926,928,1018,1022,1024,1026,1028,1118,1122,1124,1126,1129,
                //block8
                1316,1317,1318,1319,1320,1322,1323,1324,1325,1416,1417,1418,1419,1420,1422,1423,1424,1425,
                1516,1517,1518,1519,1520,1522,1523,1524,1525,
                //block9
                1716,1717,1728,1719,1720,1721,1722,1723,1724,1725,1816,1817,1818,1819,1820,1821,1822,1823,1824,1825,
                1916,1917,1918,1919,1920,1921,1922,1923,1924,1925,
                //block10
                230,231,232,233,234,235,236,237,330,331,332,333,334,335,336,337,430,431,432,433,434,435,436,437,
                530,531,532,533,534,535,536,537,630,631,632,633,634,635,636,637,830,831,832,833,
                //block11
                39,40,41,42,43,139,140,141,142,143,239,243,339,343,439,443,539,543,
                //block12
                54,55,56,57,154,155,156,157,254,257,354,357,454,457,554,557,654,657,

                //block13
                739,836,837,839,936,937,939,941,943,944,1036,1037,1039,1041,1043,1044,1136,1137,1139,1141,1143,1144,

                //block14 
                846,847,849,450,851,852,853,854,855,856,857,858,946,947,948,949,950,951,952,953,954,955,956,957,958,
                1046,1047,1048,1049,1050,1051,1052,1053,1054,1055,1056,1057,1058,1059,1146,1147,1148,1149,1150,1151,
                1153,1154,1156,1157,1158,1159,

                //block15
                1339,1340,
                1439,1440,
                1539,1540,
                1637,1638,1639,1640,1641,1642,
                //1737,1738,1739,1740,1741,1742,
                1823,1837,1838,1839,1840,1841,1842,1843,
                //1936,1937,1938,1939,1940,1941,4942,1943,
                //2037,2038,2039,2040,2041,2042,
                2137,2138,2139,2140,2141,2142,
                2239,2240,

                2439,2440,
                2538,2539,2540,2541,
                2638,2639,2640,2641,
                2739,2740,

                //block16
                2530,2531,2532,2533,
                2630,2631,2632,2633,
                2730,2731,2732,2733,
                2830,2831,2832,2833,
                2930,2931,2932,2933,

                //block17,18,19
                163,164,165,166,167,168,169,170,171,172,173,174,175,176,
                263,264,265,266,267,268,269,270,271,272,
                363,364,365,366,367,

                //block20
                463,464,465,466,467,468,469,563,564,565,566,567,568,569,663,664,665,666,667,668,669,
                763,764,765,768,769,
                863,864,865,868,869,
                963,964,965,968,969,
                1063,1064,1065,
                1163,1164,1165,
                1263,1264,1265,
                1363,1364,1365,
                1463,1464,1465,
                1563,1564,1565,
                //block21
                471,472,473,474,475,476,
                571,572,573,574,575,576,
                671,672,673,674,675,676,
                //block22
                872,873,874,875,876,
                972,973,974,975,976,
                //block23
                1172,1173,1174,1175,1176,
                1272,1273,1274,1275,1276,
                //block24
                1568,1569,1574,1575,
                1668,1669,1671,1672,1674,1675,1677,1678,
                1864,1865,   1867,1868,   1870,1871,   1873,1874,
                1964,1965,   1967,1968,   1970,1971,   1973,1974,
                2164,2165,
                2264,2265];

            dog.ProhibitTiles = phohibiTiles;
            dog.Position = tileMap1.TileCenter(5, 5);


            var visual = new Actor() { Position = new Vector2(415, 0) };
            visual.Scale = new Vector2(2.25f, 2.25f);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            sorter.Add(dog);
            visual.Add(sorter);

            Add(visual);
            Add(placeholder);

            song = Song.FromUri("song", new Uri("Snowy.ogg", UriKind.Relative));
            MediaPlayer.Play(song);
            soundEffect = SoundEffect.FromFile("Paper-Sound-Effect.wav");
            soundEffect2 = SoundEffect.FromFile("Flee.wav");

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;

            
            //Demo เปลี่ยนห้อง
            if (keyInfo.IsKeyPressed(Keys.End))
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));

            // Demo Logic ตัวอย่างกรณี Game Over
            else if (keyInfo.IsKeyPressed(Keys.PageDown))
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 1))
                    ));
            

            // Get the dog's current position
            var dogTileIndex = TileIndexFromPosition(dog.Position);

            // Check the tile number at that position
            var tileNumber = tileMap2.GetTile(dogTileIndex);

            if (tileNumber == 2651 || tileNumber == 2951)
            {
                ShowMail();
            }

            if (mail != null && keyInfo.IsKeyPressed(Keys.Space))
            {
                soundEffect2.Play();
                placeholder.Enable = false;
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));
            }

            if (tileNumber == 505 || tileNumber == 1738 || tileNumber == 1739 || tileNumber == 1741 ||
               tileNumber == 1838 || tileNumber == 1839 || tileNumber == 1841 ||
               tileNumber == 1938 || tileNumber == 1939 || tileNumber == 1941 ||
               tileNumber == 2038 || tileNumber == 2039 || tileNumber == 2041)
            {
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 1))
                    ));
            }

        }
        private Vector2i TileIndexFromPosition(Vector2 position)
        {
            int x = (int)(position.X / tileMap2.TileSize.X);
            int y = (int)(position.Y / tileMap2.TileSize.Y);
            return new Vector2i(x, y);
        }
        private void ShowMail()
        {
            if (!soundPlayed)
            {
                soundEffect.Play();
                soundPlayed = true; // Set the flag to true to indicate that sound has been played
            }
            mail = new Mail();
            mail.Position = new Vector2(500, 200);
            placeholder.Add(mail);
            placeholder.Enable = true;
        }
    }
}
