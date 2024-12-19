using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Messagewindow1 : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        Text text;
        Text name;

        string currentMessage; //ข้อความที่แสดงปัจจุบัน
        List<string> messages; //บทพูด
        int currentIndex; //ลำดับข้อความ

        RectF rawRect;
        private bool visible = true;

        public Messagewindow1(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));

            //list บทพูด
            messages = new List<string>
            {
                "ที่นี่ที่ไหนเนี่ย ใครก็ได้ช่วยด้วย!",
                "แม่จ๋าาาาา ",
                "หิวข้าวจัง",
                "ฮืออออออออออออออออออออออออ"
            };

            currentIndex = 0;
            currentMessage = messages[currentIndex]; //ตั้งให้แสดงข้อความอันแรก
        }
        public bool Visible
        {
            get => visible;
            set
            {
                visible = value;
                // Optionally, add logic to hide/show components
            }
        }

        protected override void DrawSelf(DrawTarget target, DrawState state)
        {
            base.DrawSelf(target, state);
            var combine = CombineState(state);

            background.Draw(target, combine);
            frame.Draw(target, combine);
        }

        private void DisplayMessage()
        {           
            var texture = TextureCache.Get("dogdog.png");
            var dogdog = new SpriteActor(texture);
            dogdog.Scale = new Vector2(0.4f, 0.4f);
            dogdog.Position = new Vector2(30, 30);
            
            Add(dogdog);

            //ถ้าไม่มีข้อความ ก็ให้สร้างข้อความขึ้นมา
            if (text == null)
            {
                name = new Text("Pridi-Regular.ttf", 50, Color.White, "เจ้าหมา:") { Position = new(300, 40) };
                text = new Text("Pridi-Regular.ttf", 50, Color.White, "") { Position = new(300, 100) };
                Add(text);
                Add(name);
            }          
            text.AddAction(new TextAnimation(text, currentMessage, 45)); 
        }

        private void HandleInput()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (keyInfo.IsKeyPressed(Keys.Space))
            {
                currentIndex++; //เปลี่ยนเป็นข้อความลำดับถัดไป

                // Check if there are more messages to display
                if (currentIndex < messages.Count)
                {
                    currentMessage = messages[currentIndex];
                    DisplayMessage();
                }
                else
                {
                    //ถ้าข้อความแสดงครบแล้ว ก็ให้ทำการปิดหน้าต่าง
                    if (text != null)
                    {
                        AddAction(new RunAction(() => this.Detach()));
                    }
                    currentMessage = "";
                }

            }
            

        }

        

        public override void Act(float deltaTime)
        {
            if (!visible) return;
            base.Act(deltaTime);

            // Display the initial message if not already displayed
            if (currentMessage != "" && text == null)
            {
                DisplayMessage();
            }

            HandleInput();
        }

        
    }
}
