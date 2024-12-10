using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room2 : Actor
    {
        public Room2()
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
            visual.Add(sorter);

            Add(visual);
        }
    }
}
