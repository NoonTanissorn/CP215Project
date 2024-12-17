using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Placeholder : Actor
    {
        public Placeholder()
        {
        }
        public Placeholder(Actor child)
        {
            Add(child);
        }
        public bool Enable { get; set; } = true;
        public void Toggle()
        {
            Enable = !Enable;
        }
        public override void Act(float deltaTime)
        {
            if (Enable)
                base.Act(deltaTime);
        }
        public override void Draw(DrawTarget target, DrawState state)
        {
            if (Enable)
                base.Draw(target, state);
        }
        /*public override RectF RawRect
        {
            get
            {
                if (ChildCount > 0)
                    return Children[0].RawRect;
                return base.RawRect;
            }
        }*/
    }
}
