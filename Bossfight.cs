using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Bossfight : Actor
    {

        ProgressBar playerhp;
        ProgressBar bosshp;
        private Random random;
        

        


        public Bossfight() 
        {
            //background
            var bossfight = new Panel(new Vector2(1080, 1080), Color.Black, Color.White, 0);
            bossfight.Position = new Vector2(415, 0);
            Add(bossfight);

            //-------------------------------------------------//

            //มีชื่อกับหลอดเลือดบอสกับผู้เล่น
            var bossfightmenu = new Panel(new Vector2(900, 300), Color.Green, Color.White, 5);
            bossfightmenu.Position = new Vector2(90, 600);
            bossfight.Add(bossfightmenu);

            //-------------------------------------------------//

            //รูปภาพบอส
            var texture = TextureCache.Get("dogdog.png");
            var bosspic = new SpriteActor(texture);
            bosspic.Scale = new Vector2(1, 1);
            bosspic.Position = new Vector2(720, 80);
            Add(bosspic);

            //-------------------------------------------------//

            /*var statmenu = new Panel(new Vector2(730, 350), Color.Green, Color.White, 5);
            statmenu.Position = new Vector2(350, 730);
            bossfight.Add(statmenu);*/

            //ปุ่มต่างๆ
            var fightbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Fight", new Vector2(200, 80));
            //fightbutton.NormalColor = Color.Green;
            //fightbutton.HighlightColor = Color.Green;
            //fightbutton.PressedColor = Color.Green;
            //fightbutton.NormalColorLine = Color.Green;
            //fightbutton.HighlightColorLine = Color.Green;
            //fightbutton.PressedColorLine = Color.Green;
            fightbutton.Position = new Vector2(590, 950);
            fightbutton.ButtonClicked += fightbutton_ButtonClicked;
            Add(fightbutton);

            var healbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Heal", new Vector2(200, 80));
            healbutton.Position = new Vector2(850, 950);
            healbutton.ButtonClicked += Healbutton_ButtonClicked;
            Add(healbutton);

            var runbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Run", new Vector2(200, 80));
            runbutton.Position = new Vector2(1110, 950);
            runbutton.ButtonClicked += Runbutton_ButtonClicked;
            Add(runbutton);

            //-------------------------------------------------//

            //ชื่อ
            var bossname = new Text("Pridi-Regular.ttf", 70, Color.White, "ชื่อคน") { Position = new(600, 670) };
            Add(bossname);
            var playername = new Text("Pridi-Regular.ttf", 70, Color.White, "เจ้าหมา") { Position = new(600, 770) };
            Add(playername);

            //-------------------------------------------------//

            //หลอดเลือด
            bosshp = new ProgressBar(new Vector2(400, 50), max: 1000, Color.Black, Color.Red);
            bosshp.Position = new Vector2(800, 680);
            bosshp.Value = 1000;
            Add(bosshp);

            playerhp = new ProgressBar(new Vector2(400, 50), max: 100, Color.Black, Color.Red);
            playerhp.Position = new Vector2(800, 780);
            playerhp.Value = 100;
            Add(playerhp);

            //-------------------------------------------------//


        }

        private void fightbutton_ButtonClicked(GenericButton button)
        {
            int playerDamage = RandomUtil.Next(10, 16);
            bosshp.Value -= playerDamage;
            CheckBattleEnd();

            
            if (bosshp.Value > 0)
            {
                BossAttack();
            }

            
        }

        private void Healbutton_ButtonClicked(GenericButton button)
        {
            int healAmount = RandomUtil.Next(10, 16);
            playerhp.Value = playerhp.Value + healAmount;
            //playerhp.Value = Math.Min(playerhp.Value + healAmount, 10);
            BossAttack();
        }

        private void Runbutton_ButtonClicked(GenericButton button)
        {

            var run = new Text("Pridi-Regular.ttf", 70, Color.Red, "หนี? นี่คือชะตากรรมที่คุณเป็นคนเลือกเอง สู้ต่อไปน้า") { Position = new(500, 500) };
            Add(run);




        }

        

        
        

        private void BossAttack()
        {
            if (bosshp.Value > 0)
            {
                int bossDamage = RandomUtil.Next(1, 6);
                playerhp.Value -= bossDamage;
                //UpdateStatus($"บอส: โจมตี! สร้าง {bossDamage} ดาเมจ");
            }

            if (playerhp.Value <= 0)
            {
                //UpdateStatus("ผู้เล่นพ่ายแพ้!");
                var loss = new Text("Pridi-Regular.ttf", 70, Color.Red, "แตก") { Position = new(600, 500) };
                Add(loss);
            }
        }

        private void CheckBattleEnd()
        {
            if (bosshp.Value <= 0)
            {
                //UpdateStatus("บอส: ยอมแพ้!");
                var win = new Text("Pridi-Regular.ttf", 70, Color.Red, "ชนะแล้วโว้ยยยยยยยยยยย") { Position = new(600, 500) };
                Add(win);

                /////////////ไปที่หน้าจบเกม////////////////
            }
        }

        

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            
            




        }

        


    }
}
