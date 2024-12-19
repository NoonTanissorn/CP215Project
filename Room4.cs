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
        public Room4(Vector2 screenSize, ExitNotifier exitNotifier, CameraMan cameraMan)
        {
            this.exitNotifier = exitNotifier;
            this.cameraMan = cameraMan;

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer1.csv");
            var tileMap2 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer2.csv");
            var tileMap3 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room4_layer3.csv");


            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(3, 3);
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
        }
    }
}
