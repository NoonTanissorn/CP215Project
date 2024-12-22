using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Messagewindow6 : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        Text text; //ข้อความบทพูด         
        SpriteActor characterImage;

        List<(string Message, string ImagePath)> dialogLines;
        int currentIndex;

        RectF rawRect;

        public Messagewindow6(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));

            // list บทพูด
            dialogLines = new List<(string Message, string ImagePath)>
            {
                ("คนจีน: \nเจ้าหมาโง่ ลื้อทำให้อั๊วดูแย่", "chineseguy.png"),
                ("คนจีน: \nนี่แกหนีออกมาได้ยังไงเนี่ย", "chineseguy.png"),
                ("เจ้าหมา: \nแกเป็นใคร่ จับฉันมาทำไม แกต้องการอะไร", "dogdog.png"),
                ("คนจีน: \nกำลังหิวอยู่พอดีเลย ตัวอ้วนๆน่าอร่อย", "chineseguy.png"),
                ("เจ้าหมา: \nอย่าเข้ามานะ", "dogdog.png"),
                ("เจ้าหมา: \nครูบาช่วยหมาด้วยยยยยยยยยยยยยยย", "dogdog.png"),
                ("กด [enter] เพิ่อสู้กับคนจีน", "dogdog.png"),
            };

            currentIndex = 0; //ลำดับบทพูด
        }


        protected override void DrawSelf(DrawTarget target, DrawState state)
        {
            base.DrawSelf(target, state);
            var combine = CombineState(state);

            background.Draw(target, combine);
            frame.Draw(target, combine);
        }

        private void DisplayCurrentLine()
        {
            if (currentIndex >= dialogLines.Count) return; //หากข้อความหมดแล้ว currentIndex เกินจำนวน dialogLines จะหยุดทำงาน

            var currentLine = dialogLines[currentIndex]; //แสดงบทพูดที่อยู่ใน list บทพูด

            // สร้าง text แสดงข้อความ
            if (text == null)
            {
                text = new Text("Pridi-Regular.ttf", 50, Color.White, "");
                text.Position = new Vector2(300, 40);
                Add(text);
            }
            text.AddAction(new TextAnimation(text, currentLine.Message, 30));
            if (characterImage != null)
            {
                Remove(characterImage);
            }

            // สร้าง SpriteActor ตัวใหม่สำหรับตัวละครปัจจุบัน
            characterImage = new SpriteActor(TextureCache.Get(currentLine.ImagePath));
            characterImage.Scale = new Vector2(0.4f, 0.4f); // ปรับขนาดรูปภาพ
            characterImage.Position = new Vector2(30, 30); // ตำแหน่งของรูปภาพ        
            Add(characterImage);

        }

        private void HandleInput()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (keyInfo.IsKeyPressed(Keys.Space))
            {
                currentIndex++;

                // Check if there are more dialog lines to display
                if (currentIndex < dialogLines.Count)
                {
                    DisplayCurrentLine();
                }
                else
                {
                    // All dialog lines shown, optionally close the message window
                    AddAction(new RunAction(() => this.Detach()));
                }
            }
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            // Display the initial dialog line if not already displayed
            if (currentIndex < dialogLines.Count && text == null)
            {
                DisplayCurrentLine();
            }

            HandleInput();
        }

        
            
    }
}
