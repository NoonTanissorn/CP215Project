using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
    public class Start : Actor

    {
        //ปุ่ม
        ExitNotifier exitNotifier;
        Placeholder placeholder = new Placeholder();

        
        private ImageButton imageButton1;

        Song song;
        SoundEffect soundEffect;

        

        public Start(ExitNotifier exitNotifier)

        {
            this.exitNotifier = exitNotifier;

            

            var texture = TextureCache.Get("ครูบาช่วยหมาด้วย.png");
            var bosspic = new SpriteActor(texture);
            bosspic.Scale = new Vector2(2.0f, 3.0f);
            bosspic.Position = new Vector2(385, 0);
            Add(bosspic);

            //ปุ่ม
            var button1 = new TextureRegion(TextureCache.Get("startbutt.png"), new RectF(0, 0, 250, 100));
            imageButton1 = new ImageButton(button1);
            imageButton1.Position = new Vector2(800, 650);
            imageButton1.ButtonClicked += imageButton1_ButtonClicked;
            Add(imageButton1);

            

            var button3 = new TextureRegion(TextureCache.Get("exitbutt.png"), new RectF(0, 0, 250, 100));
            var imageButton3 = new ImageButton(button3);
            imageButton3.Position = new Vector2(800, 800);
            imageButton3.ButtonClicked += imageButton3_ButtonClicked;
            Add(imageButton3);

            song = Song.FromUri("song", new Uri("menusound.ogg", UriKind.Relative));
            MediaPlayer.Play(song);
            soundEffect = SoundEffect.FromFile("Paper-Sound-Effect.wav");

            
        }

        private void imageButton1_ButtonClicked(GenericButton button) //Start Game
        {
            AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));
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
