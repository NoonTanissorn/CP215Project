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
//using static System.Net.Mime.MediaTypeNames;

namespace CP215Project
{
    internal class End : Actor
    {
        ExitNotifier exitNotifier;

        Text text;
        string str;
        private ImageButton imageButton1;
        Song song;
        SoundEffect soundEffect;
        public End(ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var texture = TextureCache.Get("theendscreen.png");
            var endspic = new SpriteActor(texture);
            endspic.Scale = new Vector2(2, 2);
            endspic.Position = new Vector2(385, 0);
            Add(endspic);

            
            text = new Text("Pridi-Regular.ttf", 200, Color.Black, "") { Position = new(675, 400) };
            str = "THE END";
            Add(text);
            text.AddAction(new TextAnimation(text, str, 45));
            
            var button1 = new TextureRegion(TextureCache.Get("replaybutt.png"), new RectF(0, 0, 250, 100));
            imageButton1 = new ImageButton(button1);
            imageButton1.Position = new Vector2(1100, 825);
            imageButton1.ButtonClicked += OnButton1Clicked;
            Add(imageButton1);

            var button2 = new TextureRegion(TextureCache.Get("exitbutt.png"), new RectF(0, 0, 250, 100));
            var imageButton2 = new ImageButton(button2);
            imageButton2.Position = new Vector2(1100, 950);
            Add(imageButton2);

            song = Song.FromUri("song", new Uri("endsong.ogg", UriKind.Relative));
            MediaPlayer.Play(song);
            //soundEffect = SoundEffect.FromFile("Paper-Sound-Effect.wav");
        }
        private void OnButton1Clicked(GenericButton button)
        {
            AddAction(new SequenceAction(
                Actions.FadeOut(0.5f, this),
                new RunAction(() => exitNotifier(this, 0))
            ));
        }


    }
}
