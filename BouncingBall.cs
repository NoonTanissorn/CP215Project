using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class BouncingBall : SpriteActor
    {
        private TileMap tileMap;
        private Vector2 velocity;

        public BouncingBall(Texture2D texture, TileMap tileMap) : base(texture)
        {
            this.tileMap = tileMap;
            this.velocity = new Vector2(RandomUtil.Next(-100, 100), RandomUtil.Next(-100, 100));
        }

        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);

            Position += velocity * deltaTime;

            // Check for collision with the edges of the tile map
            if (Position.X < 0 || Position.X > tileMap.TileSize.X * tileMap.Count2d.X)
            {
                velocity.X = -velocity.X;
            }

            if (Position.Y < 0 || Position.Y > tileMap.TileSize.Y * tileMap.Count2d.Y)
            {
                velocity.Y = -velocity.Y;
            }
        }
    }
}
