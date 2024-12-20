using System;
using System.Linq;
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
        Vector2 currentPosition;
        private string enteredPassword = string.Empty;
        public event Action<string> OnPasswordEntered;



        RectF rawRect;
        

        

        public PassWindow(RectF rawRect)
        {
            this.rawRect = rawRect;
        }

        public PassWindow(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));
            currentPosition = new Vector2(35, 10); // Initial position for the first text

            //ปุ่มทั้งหมด

            var button1 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "1", new Vector2(100, 100));
            button1.Position = new Vector2(50, 200);
            button1.ButtonClicked += Button1_ButtonClicked;
            Add(button1);

            var button2 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "2", new Vector2(100, 100));
            button2.Position = new Vector2(200, 200);
            button2.ButtonClicked += Button2_ButtonClicked;
            Add(button2);

            var button3 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "3", new Vector2(100, 100));
            button3.Position = new Vector2(350, 200);
            button3.ButtonClicked += Button3_ButtonClicked;
            Add(button3);

            var button4 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "4", new Vector2(100, 100));
            button4.Position = new Vector2(50, 350);
            button4.ButtonClicked += Button4_ButtonClicked;
            Add(button4);

            var button5 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "5", new Vector2(100, 100));
            button5.Position = new Vector2(200, 350);
            button5.ButtonClicked += Button5_ButtonClicked;
            Add(button5);

            var button6 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "6", new Vector2(100, 100));
            button6.Position = new Vector2(350, 350);
            button6.ButtonClicked += Button6_ButtonClicked;
            Add(button6);

            var button7 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "7", new Vector2(100, 100));
            button7.Position = new Vector2(50, 500);
            button7.ButtonClicked += Button7_ButtonClicked;
            Add(button7);

            var button8 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "8", new Vector2(100, 100));
            button8.Position = new Vector2(200, 500);
            button8.ButtonClicked += Button8_ButtonClicked;
            Add(button8);

            var button9 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "9", new Vector2(100, 100));
            button9.Position = new Vector2(350, 500);
            button9.ButtonClicked += Button9_ButtonClicked;
            Add(button9);

            var button0 = new Button("BlackOpsOne-Regular.ttf", 50, Color.Brown, "0", new Vector2(100, 100));
            button0.Position = new Vector2(200, 650);
            button0.ButtonClicked += Button0_ButtonClicked;
            Add(button0);

            var buttonclear = new Button("BlackOpsOne-Regular.ttf", 40, Color.Brown, "clear", new Vector2(100, 100));
            buttonclear.Position = new Vector2(50, 650);
            buttonclear.ButtonClicked += Buttonclear_ButtonClicked;
            Add(buttonclear);

            var buttonenter = new Button("BlackOpsOne-Regular.ttf", 40, Color.Brown, "enter", new Vector2(100, 100));
            buttonenter.Position = new Vector2(350, 650);
            buttonenter.ButtonClicked += Buttonenter_ButtonClicked;
            Add(buttonenter);
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
            AddText("1");
        }

        private void Button2_ButtonClicked(GenericButton button)
        {
            AddText("2");
        }

        private void Button3_ButtonClicked(GenericButton button)
        {
            AddText("3");
        }

        private void Button4_ButtonClicked(GenericButton button)
        {
            AddText("4");
        }

        private void Button5_ButtonClicked(GenericButton button)
        {
            AddText("5");
        }

        private void Button6_ButtonClicked(GenericButton button)
        {
            AddText("6");
        }

        private void Button7_ButtonClicked(GenericButton button)
        {
            AddText("7");
        }

        private void Button8_ButtonClicked(GenericButton button)
        {
            AddText("8");
        }

        private void Button9_ButtonClicked(GenericButton button)
        {
            AddText("9");
        }

        private void Button0_ButtonClicked(GenericButton button)
        {
            AddText("0");
        }

        private void Buttonclear_ButtonClicked(GenericButton button)
        {
            enteredPassword = string.Empty;
            ClearText();
        }

        private void Buttonenter_ButtonClicked(GenericButton button)
        {
            OnPasswordEntered?.Invoke(enteredPassword);
        }

        private void AddText(string textValue)
        {
            enteredPassword += textValue;
            var newText = new Text("BlackOpsOne-Regular.ttf", 185, Color.Brown, textValue);
            newText.Position = currentPosition;
            Add(newText);

            // Update the current position for the next text
            currentPosition.X += newText.RawSize.X;
        }

        private void ClearText()
        {
            // Remove all text actors
            foreach (var child in Children.OfType<Text>().ToList())
            {
                Remove(child);
            }
            currentPosition = new Vector2(35, 10); // Reset position
        }

        public void ClearEnteredPassword()
        {
            enteredPassword = string.Empty;
            ClearText();
        }
    }
}
