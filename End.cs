using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Timers;
using ThanaNita.MonoGameTnt;
//using static System.Net.Mime.MediaTypeNames;

namespace CP215Project
{
    internal class End : Actor
    {
        Text text;
        string str;
        public End(ExitNotifier exitNotifier)
        {
            var texture = TextureCache.Get("bgend.jpg");
            var bosspic = new SpriteActor(texture);
            bosspic.Scale = new Vector2(1.5f, 1.7f);
            bosspic.Position = new Vector2(385, 0);
            Add(bosspic);

            text = new Text("Pridi-Regular.ttf", 50, Color.Black, "") { Position = new(900, 200) };
            str = "กลับบ้านได้แน้ว";
            Add(text);
            text.AddAction(new TextAnimation(text, str, 45));

            var button1 = new TextureRegion(TextureCache.Get("exitbutt.png"), new RectF(0, 0, 250, 100));
            var imageButton1 = new ImageButton(button1);
            imageButton1.Position = new Vector2(1100, 950);
            Add(imageButton1);
        }

        
        

    }
}
