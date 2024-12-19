using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class MiniGamePanel4 : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        Text text;
        Text name;

        string currentMessage;
        List<string> messages;
        int currentIndex;

        RectF rawRect;

        public MiniGamePanel4(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2)
        {
            /*
            collisionDetectionUnit.AddDetector(1, 2);

            for (int i = 0; i < 5000; ++i)
                Add(new Enemy(ScreenSize / 2));

            Add(new Player(this, ScreenSize));

            Add(new FPS());
            */
        }


        
    }
}
