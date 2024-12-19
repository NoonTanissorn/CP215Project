using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room4 : Actor
    {
        public Room4()
        {
            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer1.csv");
            var tileMap2 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer2.csv");
            var tileMap3 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer3.csv");


            var visual = new Actor() { Position = new Vector2(415, 0) };
            visual.Scale = new Vector2(2.25f, 2.25f);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);


            visual.Add(sorter);

            Add(visual);
        }
    }
}
