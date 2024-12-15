using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Game1 : Game2D
    {
        Actor room1, room2, room4, room6, room12;
        protected override void LoadContent()
        {
            //TestAladdin();
            //TestGirl();
            //All.Add(new Aladdin(ScreenSize / 2));
            //All.Add(new Monstor(ScreenSize / 2));
            //All.Add(new Exercise(ScreenSize / 4));
            //All.Add(new Fireball(new Vector2(1000, 180)));
            BackgroundColor = Color.LightGray;
            /*
            room12 = new Room12();
            All.Add(room12);
            */
            
            room1 = new Room1(ExitNotifier);
            All.Add(room1);
            
            /*
             room2 = new Room2(ExitNotifier);
            All.Add(room2);
            */
            /*
            room4 = new Room4();
            All.Add(room4);
            */
            /*
            room6 = new Room6();
            All.Add(room6);
            */

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

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            if (actor == room1)
            {
                room1.Detach();
                room1 = null;
                room2 = new Room2(ExitNotifier);
                All.Add(room2);
            }
            else if (actor == room2)
            {
                room2.Detach();
                room2 = null;
                /*dragScreen = new DragScreen(ScreenSize, ExitNotifier);
                All.Add(dragScreen);*/
            }
        }

    }
    }

