using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Game1 : Game2D
    {
        Actor room1, room2, room4, room6, room12, gameover;
        protected override void LoadContent()
        {
            BackgroundColor = Color.LightGray;
            /*
            room12 = new Room12();
            All.Add(room12);
            */
            /*
            room1 = new Room1(ExitNotifier);
            All.Add(room1);*/
            
            
            /* room2 = new Room2(ExitNotifier);
            All.Add(room2);*/
            
            
            /*room4 = new Room4();
            All.Add(room4);*/
            
            
            room6 = new Room6();
            All.Add(room6);
            

            
            

        }

        private void ExitNotifier(Actor actor, int code)
        {
            if (actor == null)
                return;

            //จบหน้าตัวเอง ให้เรียหหน้าต่อไป
            if (actor == room1 && code == 0)
            {
                room1.Detach();
                room1 = null;
                room12 = new Room12(ExitNotifier);
                All.Add(room12);
            }
            else if (actor == room12 && code == 0)
            {
                room12.Detach();
                room12 = null;
                room2 = new Room2(ExitNotifier);
                All.Add(room2);
            }
            else if (actor == room2 && code == 0)
            {
                room2.Detach();
                room2 = null;
                /*dragScreen = new DragScreen(ScreenSize, ExitNotifier);
                All.Add(dragScreen);*/
            }


            else if (actor == gameover)
            {
                gameover.Detach();
                gameover = null;
                room1 = new Room1(ExitNotifier);
                All.Add(room1);
            }

            //หน้าอื่นส่ง Game Over มา จะส่ง Code 1
            else if (code == 1)
            {
                actor.Detach();
                actor = null;
                gameover = new GameOverScreen(ScreenSize, ExitNotifier);
                All.Add(gameover);
            }
        }

    }
    }

