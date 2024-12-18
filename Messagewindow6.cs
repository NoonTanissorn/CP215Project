using System.Collections.Generic;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Messagewindow6 : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        Text text;
        Text speakerText;
        Text name;
        SpriteActor characterImage;

        List<(string Speaker, string Message, string ImagePath)> dialogLines;
        int currentIndex;

        RectF rawRect;

        public Messagewindow6(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));

            // Initialize dialog lines with speaker and message
            dialogLines = new List<(string Speaker, string Message, string ImagePath)>
            {
                ("Character 1", "ชื่อคน: \nหมาโง่ แกทำให้ฉันดูแย่", "wrong.png"),
                ("Character 2", "เจ้าหมา: \nแกเป็นใคร อย่าเข้ามานะ!", "dogdog.png"),
                ("Character 1", "ชื่อคน: \nกำลังหิวอยู่พอดี", "wrong.png"),
                ("Character 2", "เจ้าหมา: \nครูบาช่วยหมาด้วยยยยยยยยยยยยยยย", "dogdog.png"),
            };

            currentIndex = 0;
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
            if (currentIndex >= dialogLines.Count) return;

            var currentLine = dialogLines[currentIndex];

            

            // Initialize speaker text if not already done
            if (speakerText == null)
            {
                speakerText = new Text("Pridi-Regular.ttf", 50, Color.Yellow, "")
                {
                    Position = new Vector2(300, 80)
                };
                Add(speakerText);
            }

            // Initialize dialog text if not already done
            if (text == null)
            {
                text = new Text("Pridi-Regular.ttf", 50, Color.White, "")
                {
                    Position = new Vector2(300, 40)
                };
                Add(text);
            }

            // Update speaker and dialog text
            //speakerText = currentLine.Speaker; // Set the speaker's name
            //text.ClearActions(); // Clear any previous animations
            text.AddAction(new TextAnimation(text, currentLine.Message, 45)); // Animate the dialog text



            if (characterImage != null)
            {
                Remove(characterImage);
            }

            // สร้าง SpriteActor ตัวใหม่สำหรับตัวละครปัจจุบัน
            characterImage = new SpriteActor(TextureCache.Get(currentLine.ImagePath))
            {
                Scale = new Vector2(0.4f, 0.4f), // ปรับขนาดรูปภาพ
                Position = new Vector2(30, 30) // ตำแหน่งของรูปภาพ
            };
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

        public void CloseWindow()
        {
            // Optional: Remove or deactivate the message window
            if (text != null)
                text = new Text("Pridi-Regular.ttf", 50, Color.White, ""); // Clear text content

            if (speakerText != null)
                speakerText = new Text("Pridi-Regular.ttf", 50, Color.White, ""); // Clear speaker text content

            dialogLines.Clear(); // Clear dialog lines
        }

        
            
    }
}
