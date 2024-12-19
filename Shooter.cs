using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanaNita.MonoGameTnt;
using Microsoft.Xna.Framework.Input;

namespace CP215Project
{
    public class Shooter : Action
    {
        Actor all;
        Player player;
        private float coolDownTime = 0;
        private float coolDownFix = 0.1f;
        public Shooter(Actor all, Player player)
        {
            this.all = all;
            this.player = player;
        }
        public bool Act(float deltaTime)
        {
            coolDownTime += deltaTime;

            var keyInfo = GlobalKeyboardInfo.Value;
            if(keyInfo.IsKeyPressed(Keys.Space) && coolDownTime >= 0)
            {
                all.Add(new Bullet(player));
                coolDownTime = -coolDownFix;
            }
            return false;
        }

        public bool IsFinished()
        {
            return false;
        }

        public void Restart()
        {
            
        }
    }
}
