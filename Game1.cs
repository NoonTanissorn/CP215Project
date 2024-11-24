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
                All.Add(new Monstor(ScreenSize / 2));
                //All.Add(new Exercise(ScreenSize / 4));
                //All.Add(new Fireball(new Vector2(1000, 180)));
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

