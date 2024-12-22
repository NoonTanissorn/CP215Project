using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Mail : Panel

    {
        public Mail()
            : base(new Vector2(600, 600), Color.LightGoldenrodYellow, Color.LightGoldenrodYellow, 2)
        {
            CreateLabels();
        }

        private void CreateLabels()
        {
            var Line1 = CreateLabel("ถึงใครที่อ่านจดหมายนี้อยู่\n" 
                + "ฮ่อง ฮ่อง ฮ่อง ฮ่อง ฮ่องฮ่อง ฮ่องฮ่อง\n" 
                + "ฮ่อง ฮ่อง ฮ่อง ฮ่อง ฮ่องฮ่อง ฮ่องฮ่อง\n" 
                + "ฮ่อง ฮ่อง ฮ่อง ฮ่อง ฮ่องฮ่อง ฮ่องฮ่อง\n" 
                + "ฮ่อง ฮ่อง ฮ่อง ฮ่อง ฮ่องฮ่อง ฮ่องฮ่อง\n"
                + "ป.ล. ห้องต่อไประวังตัวด้วย!!!\n"
                + "กด space เพื่อไปต่อ\n"
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

