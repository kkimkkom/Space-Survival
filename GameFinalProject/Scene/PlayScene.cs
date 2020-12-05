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

        public PlayScene(Game game, SpriteBatch spriteBatch, Song song) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.song = song;
            MediaPlayer.IsRepeating = true;
        }
    }
}
