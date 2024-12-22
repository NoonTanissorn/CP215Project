using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class HintWindow : Panel

    {
        public HintWindow()
            : base(new Vector2(600, 600), Color.PeachPuff , Color.Brown, 2)
        {
            
            CreateLabels();
        }

        private void CreateLabels()
        {

            var Line1 = CreateLabel("[หมาหันมา หาหมู เห็นหูหมา\n"
                + "หูหมาหนา หมูหนี หมีเห็นหมู\n"
                + "เห็นหมูหัน หูหนี หมีหันดู\n"
                + "หมีหมาหา เห็นหมู หันหูดี\n"
                + "หาหมีเห็น เหม็นหู หมีหูเหม็น\n"
                + "หาหมีหาย หมาเห็น เหม็นหูหมี\n"
                + "หมาหนีหาย หมายหมู หูหันรี\n"
                + "หมายหาหมู หมาหนี หมีหายตัว]\n"
                + "หาขาหมา หาขาหมู หาขาหมี หาขาแมว\n"
                );

            Line1.Position = new Vector2(50, 50);

            Add(Line1);
        }

        private Text CreateLabel(string s)
        {
            return new Text("Pridi-Regular.ttf", 50, Color.Black, s);
        }


    }
}
