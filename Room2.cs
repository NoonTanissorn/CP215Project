﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room2 : Actor
    {
        ExitNotifier exitNotifier;
        public Room2(ExitNotifier exitNotifier)
        {
           

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map2_layer1.csv");
            var tileMap2 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map2_layer2.csv");
            var tileMap3 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map2_layer3.csv");
            var tileMap4 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map2_layer4.csv");
            var tileMap5 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map2_layer5.csv");

            var dog = new Dog(tileMap2);
            int[] phohibiTiles = [68,69,72,75,78,79,83,84,85,86,87,89,90,91,92,93, 40,41,42,43,44,104,105,106,107,108,168,169,170,171,172,232,233,234,235,236,296,297,298,299,300,360,361,362,363,364,
                132,137,138,143,147,151,153,157,211,215,217,221,275,279, 281,285,  159,160,161,162,163,164,165,166,   55,56,57,58,119,120,121,122,183,184,185,186,247,248,249,250,311,312,313,314,375,376,377,378,439,440,441,442,
                194,196,197,198,199,200,201,202,203,204,205,206,207,209,339,343, 345,349, 223,224,225,226,227,228,229,230,
                258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273, 287,288,289,290,291,292,293,294,   351,352,353,354,355,356,357,358,
                322,323,324,325,326,327,328,329,330,321,322,323,324,325,326,327,328,329,330,331,332,333,334,335,336,337,338,403,404,405,406,407
                ,385,386,387,388,389,390,391,392,393,394,395,396,397,398,399,400,401,402  ,409,413  ,415,416,417,418,419,420,421,422 ,488
                ,449,450,451,452,453,454,455,456,457,458,459,460,461,462,463,464,465,466,467,471,473,475,477,
                513,514,515,516,517,518,519,520,521,522,523,524,525,526,527,528,529,530,531,535,   537,539,541,   543,544,545,546,   549,550,552,
                577, 578, 579,580,581,582,583,584,585,586,587,588,589,590,591,592,593,594,595,599,   601,603,605,   613,614, 616,  618,  620,621,
                641,642,643,644,645,646,647,648,649,650,651,652,653,654,655,656,657,658,659,663,   665,667,669,  677,678,  680, 682,  684,685,
                705,706,707,708,709,710,711,712,713,714,715,716,717,718,719,720,711,722,723,727,   729,731,733,    741,742,  744,746,  748,749,
                771,772,773,774,775,776,777,778,779,780,781,782,783,784,
                835,836,837,838,839,840,841,842,843,844,845,846,847,848, 849,850,851,852,853, 855,856,857,858,
                899,900,901,902,903,904,905,906,907,908,909,910,911,912,913,914,915,916,917,919,920,921,922,
                963,964,965,966,967,968,969,970,971,972,973,974,975,976,977,978,979,981,983,984,985,986,
                1027,1027,1029,1030,1031,1032,1033,1034,1035,1036,1037,1038,1039,1040,
                1093,1094,1095,1096,1099,1100,1101,1102,  1105,1106,1107,1108,1109,1110,1111,1112,1113,1114,
                1157,1158,1159,1160,1163,1164,1165,1166,  1169,1170,1171,1172,1173,1174,1175,1176,1177,1178,
                1221,1222,1223,1224,1227,1228,1229,1230,  1233,1234,1235,1236,1237,1238,1239,1240,1241,1242,
                1345,1346,1347,1348,1349,1350,1351,1352,1353,1354,1355,1356,1357,1358,1359,1360,1361,1362,  1363,1364,1365,1366, 1368,1369,1370,1371,
                1409,1410,1411,1412,1413,1414,1415,1416,1417,1418,1419,1420,1421,1422,1423,1424,1425,1426,  1427,1428,1429,1430, 1432,1433,1434,1435,
                1537,1538,1539,1540,1541,1542,1543,1544,1545,1546,1547,1548,1549,1550,1551,1552,1553,1554,  1491,1492,1493,1494, 1496,1497,1498,1499,
                1601,1602,1603,1604,1605,1606,1607,1608,1609,1610,1611,1612,1613,1614,1615,1616,1617,1618,  1619,1620,1621,1622, 1624,1625,1626,1627,
                1667,1668,1669,1670,1671,1672,1673,1674,1675,1676,1677,1678,1679,1680,  1683,1684,1685,1686  ,1688,1689,1690,1691,
                1731,1732,1733,1734,1735,1736,1737,1738,1739,1740,1741,1742,1743,1744,  1747,1748,1749,1750  ,1752,1753,1754,1755,
                1795,1796,1767,1798,1799,1800,1801,1802,1803,1804,1805,1806,1807,1808,
                1859,1860,1861,1862,1863,1864,1865,1866,1867,1868,1869,1870,1871,1872,
                1923,1924,1925,1926,1927,1928,1929,1930,1931,1932,1933,1934,1935,1936,
                1989,1990,1991,1992,1995,1996,1997,1998,
                2053,2054,2055,2056,2059,2060,2061,2062,
                2117,2118,2119,2120,2123,2124,2125,2126,];
            dog.ProhibitTiles = phohibiTiles;
            dog.Position = tileMap1.TileCenter(10, 10);





            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(3, 3);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);
            visual.Add(tileMap4);
            visual.Add(tileMap5);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            sorter.Add(tileMap4);
            sorter.Add(tileMap5);
            sorter.Add(dog);
            visual.Add(sorter);

            Add(visual);

        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;

            if (keyInfo.IsKeyPressed(Keys.End))
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));
        }
    }
}
