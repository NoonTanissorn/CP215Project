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
        public End()
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

        }

        
        

    }
}
