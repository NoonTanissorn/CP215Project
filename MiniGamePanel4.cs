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
        Vector2 screensize;

        RectF rawRect;
        public MiniGamePanel4(Vector2 screensize)
        {
            this.screensize = screensize;
            for (int i = 0; i < 100; ++i)
            {
                int imgNo = RandomUtil.Next(2);
                if (imgNo == 0)
                    Add(CreateBall());
                else
                    Add(CreatePuppy());
            }
        }

        private Actor CreateBall()
        {
            var texture = TextureCache.Get("Ball.png");
            var ball = new SpriteActor(texture);
            ball.Origin = ball.RawSize / 2;
            //ball.Scale = new Vector2(4, 4);
            ball.Position = screensize / 2;
            ball.AddAction(new RandomMover(ball));
            ball.AddAction(new RotateToAction(1,360, ball));
            return ball;
        }
        private Actor CreatePuppy()
        {
            var texture = TextureCache.Get("Puppy.jpg");
            var actor = new SpriteActor(texture);
            actor.Origin = actor.RawSize / 2;
            actor.Scale = new Vector2(0.3f, -0.3f);
            actor.Position = screensize / 2;
            actor.AddAction(new RandomMover(actor));
            //actor.AddAction(new RotateAction(actor, -90));
            return actor;
        }





    }
}
