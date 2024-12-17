using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Room1 : Actor
    {
        ExitNotifier exitNotifier;
        Placeholder placeholder = new Placeholder();
        private string predefinedPassword = "1234"; // Example password
        private PassWindow passWindow;

        public Room1(ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1_Floor.csv");
            var tileMap2 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1_Walls.csv");
            var tileMap3 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map1_Decoration.csv");

            var dog = new Dog(tileMap2);
            int[] phohibiTiles = [194,197,198,199,200,201,202,203,204,
                205,206,207,207,271,335,399,79,460,461,462,68,388,324,260,322,258,386,709,710,
                711,712,713,714,215,279,343,727,360,364,
                452,453,454,455,456,719,708,729,
                473,537,601,665,744,415,164,159,90,91,92,93];
            dog.ProhibitTiles = phohibiTiles;
            dog.Position = tileMap1.TileCenter(10, 10);

            //tile ที่จะมีคำถามคือ 799

            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(3, 3);
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


            //หน้าจอรหัส
            if(keyInfo.IsKeyPressed(Keys.Space))
                placeholder.Toggle();

            if (keyInfo.IsKeyPressed(Keys.Enter)) // Replace with the actual key for interaction
            {
                ShowPassWindow();
            }
        }

        private void ShowPassWindow()
        {
            if (passWindow == null)
            {
                passWindow = new PassWindow(new Vector2(500, 800), Color.White, Color.Black);
                passWindow.OnPasswordEntered += PassWindow_OnPasswordEntered;
                passWindow.Position = new Vector2(500, 200);
                placeholder.Add(passWindow);
            }
            placeholder.Enable = true;
        }

        private void PassWindow_OnPasswordEntered(string enteredPassword)
        {
            if (enteredPassword == predefinedPassword)
            {
                // Navigate to Room12
                exitNotifier(this, 0); // Assuming 0 is the code to navigate to Room12
            }
            else
            {
                // Password is incorrect, do nothing or show an error message
                // Demo as hide the pass window and clear the number entered
                placeholder.Enable = false;
                passWindow.ClearEnteredPassword();

            }
        }
    }
}

