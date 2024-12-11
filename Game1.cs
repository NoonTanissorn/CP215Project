using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Game1 : Game2D
    {
        protected override void LoadContent()
        {
            //TestAladdin();
            //TestGirl();
            //All.Add(new Aladdin(ScreenSize / 2));
            //All.Add(new Monstor(ScreenSize / 2));
            //All.Add(new Exercise(ScreenSize / 4));
            //All.Add(new Fireball(new Vector2(1000, 180)));
            BackgroundColor = Color.LightGray;

            /*var builder = new TileMapBuilder();
            // 1. tileMap1
            var tileMap1 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1_Floor.csv");
            var tileMap2 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1_Walls.csv");
            var tileMap3 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map1_Decoration.csv");
            var visual = new Actor() { Position = new Vector2(200, 200) };
            visual.Scale = new Vector2(3, 3);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            visual.Add(sorter);

            All.Add(visual);*/

            /*Actor room2;
            room2 = new Room2();
            All.Add(room2);*/
            Actor room4;
            room4 = new Room4();
            All.Add(room4);
            /*Actor room6;
            room6 = new Room6();
            All.Add(room6);*/

        }
        private void TestAladdin()
            {
                var size = new Vector2(45, 45);
                var sprite = new SpriteActor();
                sprite.Position = ScreenSize / 2;
                sprite.Origin = size / 2;
                sprite.Scale = new Vector2(4, 4);
                All.Add(sprite);

                var texture = TextureCache.Get("Aladdin.png");
                var regions2d = RegionCutter.Cut(texture, size, countX: 4, countY: 4);
                var regions1d = RegionSelector.Select(regions2d, start: 5, count: 8);
                var animation = new Animation(sprite, 0.5f, regions1d);
                sprite.AddAction(animation);
            }
     
            private void TestGirl()
            {
                var size = new Vector2(60, 60);
                var sprite = new SpriteActor();
                sprite.Position = ScreenSize / 2;
                sprite.Origin = size / 2;
                sprite.Scale = new Vector2(2, 2);
                All.Add(sprite);

                var texture = TextureCache.Get("Girl.png");
                var regions2d = RegionCutter.Cut(texture, size, countX: 8, countY: 4);
                var regions1d = RegionSelector.Select(regions2d, start: 16, count: 8);
                var animation = new Animation(sprite, 0.5f, regions1d);
                sprite.AddAction(animation);
            }

        }
    }

