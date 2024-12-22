using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using CP215Project.Asset;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using ThanaNita.MonoGameTnt;






namespace CP215Project
{
    public class Start : Actor

    {
        //ปุ่ม
        ExitNotifier exitNotifier;
        Placeholder placeholder = new Placeholder();
        SoundEffect soundEffect;
        private Howtoplay howtoplay;


        public Start(ExitNotifier exitNotifier)

        {
            this.exitNotifier = exitNotifier;

            var texture = TextureCache.Get("bg1.jpg");
            var bosspic = new SpriteActor(texture);
            bosspic.Scale = new Vector2(2.0f, 3.0f);
            bosspic.Position = new Vector2(385, 0);
            Add(bosspic);

            //ปุ่ม
            var button1 = new TextureRegion(TextureCache.Get("startbutt.png"), new RectF(0, 0, 250, 100));
            var imageButton1 = new ImageButton(button1);
            imageButton1.Position = new Vector2(800, 500);
            imageButton1.ButtonClicked += imageButton1_ButtonClicked;
            Add(imageButton1);

            var button2 = new TextureRegion(TextureCache.Get("howtobutt.png"), new RectF(0, 0, 320, 100));
            var imageButton2 = new ImageButton(button2);
            imageButton2.Position = new Vector2(770, 650);
            imageButton2.ButtonClicked += imageButton2_ButtonClicked;
            Add(imageButton2);

            var button3 = new TextureRegion(TextureCache.Get("exitbutt.png"), new RectF(0, 0, 250, 100));
            var imageButton3 = new ImageButton(button3);
            imageButton3.Position = new Vector2(800, 800);
            imageButton3.ButtonClicked += imageButton3_ButtonClicked;
            Add(imageButton3);
        }

        private void imageButton1_ButtonClicked(GenericButton button) //Start Game
        {
            AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));
        }

        //pop up วิธีการเล่น
        private void imageButton2_ButtonClicked(GenericButton button) //popup กล่องข้อความบอกคำใบ้
        {
            
            var keyInfo = GlobalKeyboardInfo.Value;
            //soundEffect.Play();
            howtoplay = new Howtoplay();
            howtoplay.Position = new Vector2(500, 200);
            placeholder.Add(howtoplay);
            placeholder.Enable = true;

        }

        private void imageButton3_ButtonClicked(GenericButton button) //Start Game
        {
            AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 2))
                    ));
        }

    }
        
}
