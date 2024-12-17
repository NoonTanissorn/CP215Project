using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game10;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Dog : SpriteActor
    {
        //Animation[] animationArray;
        AnimationStates states;
        public Dog(TileMap tileMap)
        {
            var size = new Vector2(125, 125);
            player = this;
            //sprite.Position = position;
            player.Origin = size / 2;
            player.Scale = new Vector2(0.35f, 0.35f);

            //player = this;
            this.tileMap = tileMap;


            var texture = TextureCache.Get("dog.png");
            //SetTextureRegion(new TextureRegion(texture, new RectF(0, 0, 125, 125)));
            var regions2d = RegionCutter.Cut(texture, size, countX: 4, countY: 4);

            var selector = new RegionSelector(regions2d);
            var stay = new Animation(this, 1.0f, selector.Select1by1(0, 1, 2, 3));
            var left = new Animation(this, 1.0f, selector.Select1by1(4, 5, 6, 7));
            var right = new Animation(this, 1.0f, selector.Select1by1(8, 9, 10, 11));
            var up = new Animation(this, 1.0f, selector.Select1by1(12, 13, 14, 15));
            var down = new Animation(this, 1.0f, selector.Select(0, 4));
            states = new AnimationStates([stay, left, right, up, down]);
            AddAction(states);
        }

        //KeyQueue keyQueue = new KeyQueue();
        //LinearMotion motion = LinearMotion.Empty();
        Actor player;
        TileMap tileMap;
        public int[] ProhibitTiles { get; set; }




        /*        int last = -1;
                public void Animate(int index)
                {
                    for (int i = 0; i < animationArray.Length; i++)
                        animationArray[i].Running = (i == index);

                    if (index != last)
                        animationArray[index].Restart();
                    last = index;
                }
        */
        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            var direction = DirectionKey.Normalized;
            if (!IsAllowMove(direction))
                return;

            player.Position += 100 * direction * deltaTime;
            //Position += 100 * direction * deltaTime;



            if (direction.X > 0)
                states.Animate(2); // right
            else if (direction.X < 0)
                states.Animate(1); // left
            else if (direction.Y > 0)
                states.Animate(4); // down
            else if (direction.Y < 0)
                states.Animate(3); // up
            else
                states.Animate(0);



            

            //StepJumpMovement();


        }

        /*private void StepJumpMovement()
        {
            var keyInfo = GlobalKeyboardInfo.Value;
            if (!keyInfo.IsAnyKeyPressed())
                return;

            var key = keyInfo.GetPressedKeys()[0];
            var direction = DirectionKey.DirectionOf(key);
            if (!IsAllowMove(direction))
                return;

            player.Position += direction * tileMap.TileSize;
        }*/







        private bool IsAllowMove(Vector2 direction)
        {
            Vector2i index = tileMap.CalcIndex(player.Position, direction);
            return tileMap.IsInside(index) && IsAllowTile(index);
        }

        private bool IsAllowTile(Vector2i index)
        {
            /* (ProhibitTiles == null)
                return true;

            int tileCode = tileMap.GetTileCode(index);
            return !ProhibitTiles.Contains(tileCode);*/

            int tileCode = tileMap.GetTileCode(index);
            return !ProhibitTiles.Contains(tileCode);
        }


    }
}

  

       


