using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameFinalProject
{
    public class HighScoreScene : GameScene
    {
        private SpriteBatch spriteBatch;
        public HighScoreScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
        }
    }
}
