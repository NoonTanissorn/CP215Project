using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
using System;
using System.Xml.Linq;

namespace CP215Project
{
    public class Test : Actor
    {
        // Boss and Player stats
        private int bossHP = 100;
        private int playerHP = 50;

        private Random random;

        // UI elements
        private RectangleActor background;
        private HollowRectActor frame;
        private Text statusText;
        private Button fightButton;
        private Button healButton;
        private Button runButton;

        public Test(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            random = new Random();

            // Background and frame
            var rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));

            // Status Text
            statusText = new Text("Pridi-Regular.ttf", 50, Color.White, "เริ่มการต่อสู้!")
            {
                Position = new Vector2(50, 20)
            };
            Add(statusText);

            // Buttons
            var fightbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Fight", new Vector2(100, 100));
            fightbutton.Position = new Vector2(350, 200);
            fightbutton.ButtonClicked += Fightbutton_ButtonClicked;
            Add(fightbutton);

            var healbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Heal", new Vector2(100, 100));
            healbutton.Position = new Vector2(450, 200);
            healbutton.ButtonClicked += Healbutton_ButtonClicked;
            Add(healbutton);

            var runbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Run", new Vector2(100, 100));
            runbutton.Position = new Vector2(550, 200);
            runbutton.ButtonClicked += Runbutton_ButtonClicked;
            Add(runbutton);

            /*fightButton = CreateButton("ต่อสู้", new Vector2(50, 300), OnFightPressed);
            healButton = CreateButton("เพิ่มเลือด", new Vector2(250, 300), OnHealPressed);
            runButton = CreateButton("วิ่งหนี", new Vector2(450, 300), OnRunPressed);*/

            /*Add(fightButton);
            Add(healButton);
            Add(runButton);*/
        }

        /*private Button CreateButton(string text, Vector2 position, Action onClick)
        {
            return new Button("Pridi-Regular.ttf", 30, text, Color.White, Color.Gray, Color.Green, Color.Red, new Vector2(200, 60))
            {
                Position = position,
                OnClick = onClick
            };
        }*/

        protected override void DrawSelf(DrawTarget target, DrawState state)
        {
            base.DrawSelf(target, state);
            var combine = CombineState(state);

            background.Draw(target, combine);
            frame.Draw(target, combine);
        }

        /*private void UpdateStatus(string message)
        {
            statusText.Content = message;
        }*/

        private void Fightbutton_ButtonClicked(GenericButton button)
        {
            var name = new Text("Pridi-Regular.ttf", 50, Color.White, "เจ้าหมา:") { Position = new(300, 40) };
            Add(name);
            OnFightPressed();
        }

        private void Healbutton_ButtonClicked(GenericButton button)
        {
            OnHealPressed();
        }

        private void Runbutton_ButtonClicked(GenericButton button)
        {
            OnRunPressed();
        }

        private void OnFightPressed()
        {
            // Player attacks
            int playerDamage = random.Next(10, 16);
            bossHP -= playerDamage;
            //UpdateStatus($"ผู้เล่น: ต่อสู้! โจมตีบอส {playerDamage} ดาเมจ");
            CheckBattleEnd();

            if (bossHP > 0)
            {
                BossAttack();
            }
        }

        private void OnHealPressed()
        {
            // Player heals
            int healAmount = random.Next(10, 16);
            playerHP = Math.Min(playerHP + healAmount, 50);
            //UpdateStatus($"ผู้เล่น: เพิ่มเลือด {healAmount} หน่วย");

            BossAttack();
        }

        private void OnRunPressed()
        {
            // Exit the battle
            //UpdateStatus("ผู้เล่น: วิ่งหนี!");
            EndBattle();
        }

        private void BossAttack()
        {
            if (bossHP > 0)
            {
                int bossDamage = random.Next(1, 6);
                playerHP -= bossDamage;
                //UpdateStatus($"บอส: โจมตี! สร้าง {bossDamage} ดาเมจ");
            }

            if (playerHP <= 0)
            {
                //UpdateStatus("ผู้เล่นพ่ายแพ้!");
                EndBattle();
            }
        }

        private void CheckBattleEnd()
        {
            if (bossHP <= 0)
            {
                //UpdateStatus("บอส: ยอมแพ้!");
                EndBattle();
            }
        }

        private void EndBattle()
        {
            // Logic to return to the start window
            // Replace this with actual navigation logic to the start screen
            Console.WriteLine("กลับไปที่หน้าหลัก");
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            // Example: Refresh UI or update animations
        }
    }
}

