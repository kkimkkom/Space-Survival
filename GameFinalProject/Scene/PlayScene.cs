using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace GameFinalProject
{
    public class PlayScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private Song song;
        private Astronaut astronaut;

        public PlayScene(Game game, SpriteBatch spriteBatch, Song song) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.song = song;
            MediaPlayer.IsRepeating = true;
            astronaut = new Astronaut(game, spriteBatch, game.Content.Load<Texture2D>("Images/Astronaut"), 3);
            this.Components.Add(astronaut);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
    }
}
