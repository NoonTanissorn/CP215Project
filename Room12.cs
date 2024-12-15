using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

// ห้อง 1.2 ห้องที่กรงเปิด
namespace CP215Project
{
    internal class Room12 : Actor
    {
        ExitNotifier exitNotifier;
        public Room12(ExitNotifier exitNotifier)
        {
            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1.2_Floor.csv");
            var tileMap2 = builder.CreateSimple("mainlevbuild.png", new Vector2(16, 16), 64, 40,
                                                "map1.2_Walls.csv");
            var tileMap3 = builder.CreateSimple("decorative.png", new Vector2(16, 16), 16, 16,
                                                "map1.2_Decoration.csv");

            /*var dog = new Monstaa(tileMap2);
            int[] phohibiTiles = [194,197,198,199,200,201,202,203,204,
                205,206,207,207,271,335,399,79,460,461,462,68,388,324,260,322,258,386,709,710,
                711,712,713,714,215,279,343,727,360,364,
                452,453,454,455,456,719,708,729,
                473,537,601,665,744,415,164,159,90,91,92,93,225];
            dog.ProhibitTiles = phohibiTiles;
            dog.Position = tileMap1.TileCenter(10, 10);*/

            var visual = new Actor() { Position = new Vector2(100, 100) };
            visual.Scale = new Vector2(2, 2);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            //sorter.Add(dog);
            visual.Add(sorter);

            Add(visual);
            this.exitNotifier = exitNotifier;
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

