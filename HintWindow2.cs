using System;
using System.Collections.Generic;
using System.Net.Mime;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
namespace CP215Project
{
    public class HintWindow2 : Panel
 
    {
        public HintWindow2()
            : base(new Vector2(900, 350), Color.PeachPuff, Color.Brown, 2)
        {
            CreateLabels();
        }

        

        private void CreateLabels()
        {
            
            var Line1 = CreateLabel("ภาพนี้มีรหัส");
            Line1.Position = new Vector2(50, 50);
            Add(Line1);
            var pictureRegion = new TextureRegion(TextureCache.Get("fruit.png"), new RectF(0, 0, 822, 203));
            var pictureActor = new SpriteActor(pictureRegion)
            {
                Position = new Vector2(70, 150) // Adjust the position as needed
            };
            Add(pictureActor);
        }

        private Text CreateLabel(string s)
        {
            return new Text("Pridi-Regular.ttf", 50, Color.Black, s);
        }
    }
}