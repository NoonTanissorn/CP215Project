using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Timers;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Bossfight : Actor
    {
        ExitNotifier exitNotifier;
        private int playerhp = 100;
        ProgressBar bosshp;
        private Random random;
        private bool isRunButtonClicked = false; // Flag to indicate if the run button has been clicked
        private float countdownTime = 20f; // Countdown time in seconds
        private Text countdownText; // Text to display the countdown timer
        private bool isGameOver = false; // Flag to indicate if the game is over
        Song song;
        SoundEffect soundEffect,soundEffect2;

        public Bossfight(ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;
            //background
            var bossfight = new Panel(new Vector2(1080, 1080), Color.Black, Color.White, 0);
            bossfight.Position = new Vector2(415, 0);
            Add(bossfight);

            //-------------------------------------------------//

            //มีชื่อกับหลอดเลือดบอสกับผู้เล่น
            var bossfightmenu = new Panel(new Vector2(900, 200), Color.Black, Color.White, 5);
            bossfightmenu.Position = new Vector2(90, 800);
            bossfight.Add(bossfightmenu);

            //-------------------------------------------------//

            //รูปภาพบอส
            var texture = TextureCache.Get("wrong.png");
            var bosspic = new SpriteActor(texture);
            bosspic.Scale = new Vector2(0.5f, 0.5f);
            bosspic.Position = new Vector2(720, 180);
            Add(bosspic);

            //-------------------------------------------------//

            //ปุ่มต่างๆ
            var fightbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Fight", new Vector2(200, 80));
            fightbutton.Position = new Vector2(650, 860);
            fightbutton.ButtonClicked += fightbutton_ButtonClicked;
            Add(fightbutton);

            

            var runbutton = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "Run", new Vector2(200, 80));
            runbutton.Position = new Vector2(1070, 860);
            runbutton.ButtonClicked += Runbutton_ButtonClicked;
            Add(runbutton);

            //-------------------------------------------------//

            //ชื่อ
            var bossname = new Text("Pridi-Regular.ttf", 70, Color.White, "แหนม") { Position = new(500, 30) };
            Add(bossname);
            

            //-------------------------------------------------//

            //หลอดเลือด
            bosshp = new ProgressBar(new Vector2(700, 20), max: 1000, Color.Gray, Color.Red);
            bosshp.Position = new Vector2(500, 110);
            bosshp.Value = 1000;
            Add(bosshp);

            //playerhp = new ProgressBar(new Vector2(400, 50), max: 100, Color.Black, Color.Black);
            //playerhp.Position = new Vector2(800, 680);
            //playerhp.Value = 100;
            //Add(playerhp);

            //-------------------------------------------------//

            // Countdown timer text
            countdownText = new Text("Pridi-Regular.ttf", 90, Color.White, countdownTime.ToString("F1")) { Position = new(1300, 50) };
            Add(countdownText);
            song = Song.FromUri("song", new Uri("bossfight.ogg", UriKind.Relative));
            MediaPlayer.Play(song);
            soundEffect = SoundEffect.FromFile("bonk.wav");
            soundEffect2 = SoundEffect.FromFile("Flee.wav");
        }

        private bool IsPlayerDead()
        {
            return playerhp <= 0;
        }

        private void fightbutton_ButtonClicked(GenericButton button)
        {
            if (isRunButtonClicked || IsPlayerDead() || isGameOver) return; // Check if the run button has been clicked or game is over

            int playerDamage = RandomUtil.Next(10, 16);
            bosshp.Value -= playerDamage;
            CheckBattleEnd();
            soundEffect.Play();

            if (bosshp.Value > 0)
            {
                BossAttack();
            }
        }

        

        private async void Runbutton_ButtonClicked(GenericButton button)
        {
            if (IsPlayerDead() || isGameOver) return;
            isRunButtonClicked = true; // Set the flag to indicate the run button has been clicked

            var run = new Text("Pridi-Regular.ttf", 70, Color.Red, "หนี? นี่คือชะตากรรมที่คุณเป็นคนเลือกเอง สู้ต่อไปน้า") { Position = new(500, 700) };
            Add(run);
            soundEffect2.Play();

            await Task.Delay(2000); // Wait for 2 seconds
            
            AddAction(new SequenceAction(
                Actions.FadeOut(0.5f, this),
                new RunAction(() => exitNotifier(this, 1))
            ));
        }

        private async void BossAttack()
        {
            if (bosshp.Value > 0)
            {
                int bossDamage = RandomUtil.Next(1, 6);
                //playerhp.Value -= bossDamage;
            }

            if (playerhp <= 0)
            {
                GameOver();
            }
        }

        private async void CheckBattleEnd()
        {
            if (bosshp.Value <= 0)
            {
                var win = new Text("Pridi-Regular.ttf", 70, Color.White, "บ๊ายบาย เจ้ามนุษย์โง่~") { Position = new(750, 700) };
                Add(win);
                isGameOver = true; // Set the game over flag

                await Task.Delay(2000);

                MediaPlayer.Stop();
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                ));
            }
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            if (!isGameOver)
            {
                countdownTime -= deltaTime;
                countdownText.Str = countdownTime.ToString("F1");

                if (countdownTime <= 0)
                {
                    countdownTime = 0;
                    isGameOver = true;

                    if (bosshp.Value > 0)
                    {
                        GameOver();
                    }
                }
            }
        }

        private async void GameOver()
        {
            var loss = new Text("Pridi-Regular.ttf", 70, Color.White, "บ้าจริง! นี่เราจะโดนกินหรือเนี่ย") { Position = new(700, 700) };
            Add(loss);

            await Task.Delay(2000); // Wait for 2 seconds

            MediaPlayer.Stop();
            AddAction(new SequenceAction(
                Actions.FadeOut(0.5f, this),
                new RunAction(() => exitNotifier(this, 1))
            ));
            isGameOver = true;
        }
    }
}
