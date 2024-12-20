using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    public class GameOverScreen : Actor
    {
        // ref: https://gamefromscratch.com/monogame-tutorial-audio/
        Song song;
        SoundEffect soundEffect;
        ExitNotifier exitNotifier;
        public GameOverScreen(Vector2 screenSize, ExitNotifier exitNotifier)
        {
            this.exitNotifier = exitNotifier;

            var panel = new Panel(screenSize, new Vector2(100, 100), Color.Black, Color.White, 5);
            var textureRegion = new TextureRegion(TextureCache.Get("dogdied.jpg"), new RectF(0, 0, 700, 460));
            var scale = new Vector2(1.5f, 1.5f);
            var textureActor = new SpriteActor(textureRegion)
            {
                Position = new Vector2(450, 150),
                Scale = scale
            };
            var text = new Text("Pridi-Regular.ttf", 100, Color.White, "Game Over")
            {
                Position = new Vector2(800, 850)
            };
            Add(panel);
            Add(textureActor);
            Add(text);
            Color = new Color(Color, 0);
            AddAction(Actions.FadeIn(3, this));

            song = Song.FromUri("song", new Uri("Guitar-Nokia.ogg", UriKind.Relative));
            MediaPlayer.Play(song);

            //soundEffect = SoundEffect.FromFile("bump.wav");
        }
        public override void Act(float deltaTime)
        {
            base.Act(deltaTime);
            var keyInfo = GlobalKeyboardInfo.Value;
            if (keyInfo.IsKeyPressed(Keys.Space))
            {
                if (MediaPlayer.State == MediaState.Stopped)
                    MediaPlayer.Play(song);
                else if (MediaPlayer.State == MediaState.Playing)
                    MediaPlayer.Pause();
                else if (MediaPlayer.State == MediaState.Paused)
                    MediaPlayer.Resume();
            }

            if (keyInfo.IsKeyPressed(Keys.R))
                MediaPlayer.Play(song);

            if (keyInfo.IsKeyPressed(Keys.Tab))
            {
                soundEffect.Play();
            }

            if (keyInfo.IsKeyPressed(Keys.End))
            {
                MediaPlayer.Stop();
                AddAction(new SequenceAction(
                                Actions.FadeOut(0.5f, this),
                                new RunAction(() => exitNotifier(this, 0))
                    ));
            }
        }
    }
}
