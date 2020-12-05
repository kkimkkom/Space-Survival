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
    public class AboutScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private AboutComponent aboutComponent;
        public AboutScene(Game game, SpriteBatch spriteBatch) : base(game)
        {
            this.spriteBatch = spriteBatch;
            aboutComponent = new AboutComponent(game, spriteBatch,
                                game.Content.Load<SpriteFont>("Fonts/RegularFont"),
                                game.Content.Load<SpriteFont>("Fonts/SpecialFont"));
            this.Components.Add(aboutComponent);
        }
    }
}
