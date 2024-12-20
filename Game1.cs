using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class Game1 : Game2D
    {
        Actor room1, room2, room3, room4, room5, room6, room12, gameover;
        CameraMan cameraMan;
        protected override void LoadContent()
        {
            cameraMan = new CameraMan(Camera, ScreenSize);
            BackgroundColor = Color.Black;
            /*
            room12 = new Room12();
            All.Add(room12);
            */



            room1 = new Room1(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room1);

            
            /* room2 = new Room2(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room2);*/
            

            /*room3 = new Room3(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room3);*/

            /*room4 = new Room4(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room4);*/

            /*room5 = new Room5(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room5);*/

            /*room6 = new Room6(ScreenSize, ExitNotifier, cameraMan);
            All.Add(room6);*/
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
                room2 = new Room2(ScreenSize, ExitNotifier, cameraMan);
                All.Add(room2);
            }
            
            else if (actor == room2 && code == 0)
            {
                room2.Detach();
                room2 = null;
                room3 = new Room3(ScreenSize, ExitNotifier, cameraMan);
                All.Add(room3);
            }
            else if (actor == room3 && code == 0)
            {
                room3.Detach();
                room3 = null;
                room4 = new Room4(ScreenSize, ExitNotifier, cameraMan);
                All.Add(room4);
            }
            else if (actor == room4 && code == 0)
            {
                room4.Detach();
                room4 = null;
                room5 = new Room5(ScreenSize, ExitNotifier, cameraMan);
                All.Add(room5);
            }
            else if (actor == room5 && code == 0)
            {
                room5.Detach();
                room5 = null;
                room6 = new Room6(ScreenSize, ExitNotifier, cameraMan);
                All.Add(room6);
            }


            else if (actor == gameover)
            {
                gameover.Detach();
                gameover = null;
                room1 = new Room1(ScreenSize, ExitNotifier, cameraMan);
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

