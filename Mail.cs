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
            var Line1 = CreateLabel("ถึงโฮ่งๆลูกรัก <3\n" 
                + "ถ้าลูกได้เห็นจดหมายนี้ แม่คงไปที่ดาวหมา\n" 
                + "แล้ว นั่นมันเป็นปีศาจที่คอยไล่ฆ่าพวกเรา\n" 
                + "ทุกคืนปีศาจนั่นมันจะจับพวกเรา ไปทีละตัว\n"
                + "และเพื่อนหมาที่มันพาออกไปจากห้องนี้\n"
                + "ไม่เคยมีหมาไหนได้กลับมาที่ห้องได้อีกเลย..\n"
                + "ลูกจะต้องหนีออกจากที่นี่ไปให้ได้\n"
                + "ระวังตัวด้วย เหมือนบ้านหลังนี้มันแปลกๆ\n"
                + "ชีวิตของลูกเพียงชีวิตเดียว รักษาไว้ให้ดีๆ\n"
                + "ถ้าเจอปีศาจก็เอาไม้แถวนั้นบ๊องหัวมันเลยลูก\n"
                + "รักลูกน้าา จุ๊บ (กด Spacebar เพื่อไปต่อ)\n"
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

