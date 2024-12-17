using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;
//using static System.Net.Mime.MediaTypeNames;


namespace CP215Project
{
    public class PassWindow : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        Text text;
        
        

        RectF rawRect;
        

        //public override RectF RawRect => rawRect;

        public PassWindow(RectF rawRect)
        {
            this.rawRect = rawRect;
        }

        public PassWindow(Vector2 size, Color backgroundColor, Color outlineColor,
                     float outlineWidth = 2)
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth,
                rawRect.CreateExpand(-outlineWidth/2));

            var button1 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "1", new Vector2(100, 100));
            button1.Position = new Vector2(50, 200);
            button1.ButtonClicked += Button1_ButtonClicked;
            Add(button1);

            var button2 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "2", new Vector2(100, 100));
            button2.Position = new Vector2(200, 200);
            button2.ButtonClicked += Button2_ButtonClicked;
            Add(button2);

            var button3 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "3", new Vector2(100, 100));
            button3.Position = new Vector2(350, 200);
            button3.ButtonClicked += Button3_ButtonClicked;
            Add(button3);

            var button4 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "4", new Vector2(100, 100));
            button4.Position = new Vector2(50, 350);
            Add(button4);

            var button5 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "5", new Vector2(100, 100));
            button5.Position = new Vector2(200, 350);
            Add(button5);

            var button6 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "6", new Vector2(100, 100));
            button6.Position = new Vector2(350, 350);
            Add(button6);

            var button7 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "7", new Vector2(100, 100));
            button7.Position = new Vector2(50, 500);
            Add(button7);
     
            var button8 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "8", new Vector2(100, 100));
            button8.Position = new Vector2(200, 500);
            Add(button8);
            
            var button9 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "9", new Vector2(100, 100));
            button9.Position = new Vector2(350, 500);
            Add(button9);

            var button0 = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "0", new Vector2(100, 100));
            button0.Position = new Vector2(50, 650);
            Add(button0);

            var buttonclear = new Button("BlackOpsOne-Regular.ttf", 50,
                Color.Brown, "clear", new Vector2(250, 100));
            buttonclear.Position = new Vector2(200, 650);
            Add(buttonclear);

            

        }



        protected override void DrawSelf(DrawTarget target, DrawState state)
        {
            base.DrawSelf(target, state);
            var combine = CombineState(state);

            background.Draw(target, combine);
            frame.Draw(target, combine);
        }

        private void Button1_ButtonClicked(GenericButton button)
        {
            var text1 = new Text("BlackOpsOne-Regular.ttf", 200, Color.Green, "1");
            //text = text + text1;
            text1.Position = new Vector2(50, 10);
            Add(text1);
        }

        private void Button2_ButtonClicked(GenericButton button)
        {
            text = new Text("BlackOpsOne-Regular.ttf", 200, Color.Green, "2");
            text.Position = new Vector2(50, 10);
            Add(text);
        }

        private void Button3_ButtonClicked(GenericButton button)
        {
            text = new Text("BlackOpsOne-Regular.ttf", 200, Color.Green, "3");
            text.Position = new Vector2(50, 10);
            Add(text);
        }

        



    }
}
