using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Bossfight : Actor
    {
        RectangleActor background;
        HollowRectActor frame;
        RectF rawRect;

        

        public Bossfight(RectF rawRect)
        {
            this.rawRect = rawRect;
        }

        public Bossfight(Vector2 size, Color backgroundColor, Color outlineColor, float outlineWidth = 2) 
        {
            rawRect = new RectF(Vector2.Zero, size);
            background = new RectangleActor(backgroundColor, rawRect);
            frame = new HollowRectActor(outlineColor, outlineWidth, rawRect.CreateExpand(-outlineWidth / 2));

            var bossfightmenu = new Bossfightmenu(new Vector2(300, 300), Color.Green, Color.White, 5);
            bossfightmenu.Position = new Vector2(0, 400);
            Add(bossfightmenu);


        }
        

        protected override void DrawSelf(DrawTarget target, DrawState state)
        {
            base.DrawSelf(target, state);
            var combine = CombineState(state);

            background.Draw(target, combine);
            frame.Draw(target, combine);
        }

        
    }
}
