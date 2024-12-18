using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room6 : Actor
    {
        public Room6()
        {
            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map6_layer1.csv");
            var tileMap2 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map6_layer2.csv");
            var tileMap3 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map6_layer3.csv");
            var tileMap4 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map6_layer4.csv");

            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(3, 3);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);
            visual.Add(tileMap4);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            sorter.Add(tileMap4);

            visual.Add(sorter);

            Add(visual);

            //Message Window
            var messagewindow = new Messagewindow6(new Vector2(1445, 250), Color.Black, Color.White, 10);
            messagewindow.Position = new Vector2(100, 830);
            Add(messagewindow);
        }
    }
}
