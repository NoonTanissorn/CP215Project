using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Monstor : SpriteActor
    {
        //Animation[] animationArray;
        AnimationStates states;
        public Monstor(Vector2 position)
        {
            var size = new Vector2(100, 150);
            var sprite = this;
            sprite.Position = position;
            sprite.Origin = size / 2;
            sprite.Scale = new Vector2(1, 1f);

            var texture = TextureCache.Get("Monstor.png");
            var regions2d = RegionCutter.Cut(texture, size, countX: 4, countY: 4);

            var selector = new RegionSelector(regions2d);
            var stay = new Animation(sprite, 0.5f, selector.Select1by1(0, 2));
            var left = new Animation(sprite, 0.5f, selector.Select(start: 4, count: 4));
            var right = new Animation(sprite, 0.5f, selector.Select(start: 8, count: 4));
            var down = new Animation(sprite, 0.5f, selector.Select(start: 12, count: 4));
            var up = new Animation(sprite, 0.5f, selector.Select(start: 0, count: 4));
            states = new AnimationStates([stay, left, right, down, up]);
            AddAction(states);

            sprite.AddAction(stay);
            sprite.AddAction(left);
            sprite.AddAction(right);
            right.Running = false;
            left.Running = false;
        }
        /*int last = -1;
        public void Animate(int index)
        {
            for (int i = 0; i < animationArray.Length; i++)
            {
                animationArray[i].Running = i == index;
            }

            if (index != last)
            {
                animationArray[index].Restart();
            }
            last = index;
        }*/

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            var direction = DirectionKey.Normalized;
            Position += direction * 1000 * deltaTime;
            if (direction.X > 0)
            {
                states.Animate(2);
            }
            else if (direction.X < 0)
            {
                states.Animate(1);
            }
            else if (direction.Y > 0)
            {
                states.Animate(4);
            }
            else if (direction.Y < 0)
            {
                states.Animate(3);
            }
            else
            {
                states.Animate(0);
            }
        }

    }
}
