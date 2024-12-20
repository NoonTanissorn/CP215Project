﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class HintWindow : Panel

    {
        public HintWindow()
            : base(new Vector2(300, 300), Color.Ivory, Color.Black, 2)
        {
            CreateLabels();
        }

        private void CreateLabels()
        {
            var Line1 = CreateLabel("หมาหันมา หาหมู เห็นหูหมา");
            var Line2 = CreateLabel("หูหมาหนา หมูหนี หมีเห็นหมู");
            var Line3 = CreateLabel("เห็นหมูหัน หูหนี หมีหันดู");
            var Line4 = CreateLabel("หมีหมาหา เห็นหมู หันหูดี");
            var Line5 = CreateLabel("หาหมีเห็น เหม็นหู หมีหูเหม็น");
            var Line6 = CreateLabel("หาหมีหาย หมาเห็น เหม็นหูหมี");
            var Line7 = CreateLabel("หมาหนีหาย หมายหมู หูหันรี");
            var Line8 = CreateLabel("หมายหาหมู หมาหนี หมีหายตัว");


            Line1.Position = new Vector2(50, 50);
            Alignment.SetPosition(Line1, AlignDirection.Down);
            Alignment.SetPosition(Line2, AlignDirection.Down);
            Alignment.SetPosition(Line3, AlignDirection.Down);
            Alignment.SetPosition(Line4, AlignDirection.Down);
            Alignment.SetPosition(Line5, AlignDirection.Down);
            Alignment.SetPosition(Line6, AlignDirection.Down);
            Alignment.SetPosition(Line7, AlignDirection.Down);

            Add(Line1);
            Add(Line2);
            Add(Line3);
            Add(Line4);
            Add(Line5);
            Add(Line6);
            Add(Line7);
            Add(Line8);
        }

        private Text CreateLabel(string s)
        {
            return new Text("Pridi-Regular.ttf", 25, Color.Black, s);
        }


    }
}
