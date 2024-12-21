using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room4 : Actor
    {
        ExitNotifier exitNotifier;
        CameraMan cameraMan;
        Vector2 screenSize;

        Placeholder placeholder = new Placeholder();
        private MiniGamePanel4 minigame4;
        public Room4(Vector2 screenSize, ExitNotifier exitNotifier, CameraMan cameraMan)
        {

            this.exitNotifier = exitNotifier;
            this.cameraMan = cameraMan;
            this.screenSize = screenSize;


            

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer1.csv");
            var tileMap2 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer2.csv");
            var tileMap3 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer3.csv");

            var dog = new Dog(tileMap2);
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

            for (int i = 0; i < 100; ++i)
            {
                int imgNo = RandomUtil.Next(2);
                Vector2 randomPosition = new Vector2(
                    RandomUtil.Next((int)screenSize.X),
                    RandomUtil.Next((int)screenSize.Y)
                );

                if (imgNo == 0)
                {
                    var ball = CreateBall(randomPosition);
                    visual.Add(ball);
                    sorter.Add(ball);
                }

                else
                    visual.Add(CreatePuppy());
            }


            visual.Add(sorter);

            Add(visual);
            Add(placeholder);
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

            /*
            if (keyInfo.IsKeyPressed(Keys.Enter)) // Replace with the actual key for interaction
            {
                ShowMiniGame(); //กดenter โชว์เครื่องกดรหัส
            }
            */
        }

        private void ShowMiniGame() 
        {
            if (minigame4 == null)
            {
                minigame4 = new MiniGamePanel4(new Vector2(500, 800));
                placeholder.Add(minigame4);
            }
            placeholder.Enable = true;
        }

        private Actor CreateBall(Vector2 position)
        {
            var texture = TextureCache.Get("Ball.png");
            var ball = new SpriteActor(texture);
            ball.Origin = ball.RawSize / 2;
            ball.Scale = new Vector2(0.5f, 0.5f);
            ball.Position = position;
            ball.AddAction(new RandomMover(ball));
            ball.AddAction(new RotateToAction(1, 360, ball));
            return ball;
        }

        private Actor CreatePuppy()
        {
            var texture = TextureCache.Get("Puppy.jpg");
            var actor = new SpriteActor(texture);
            actor.Origin = actor.RawSize / 2;
            actor.Scale = new Vector2(0.3f, -0.3f);
            actor.Position = screenSize / 2;
            actor.AddAction(new RandomMover(actor));
            //actor.AddAction(new RotateAction(actor, -90));
            return actor;
        }
    }
}
