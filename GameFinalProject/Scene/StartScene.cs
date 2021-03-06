﻿using System;
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
    public class StartScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private MenuComponent menu;
        private Song song;
        private SoundEffect click;

        private string[] menuArray = { "Play Game", "Help", "High Score", "About", "Exit" };
        public MenuComponent Menu { get => menu; set => menu = value; }
        public StartScene(Game game, SpriteBatch spriteBatch, Song song, SoundEffect click) : base(game)
        {
            this.spriteBatch = spriteBatch;
            menu = new MenuComponent(game,
                spriteBatch,
                game.Content.Load<SpriteFont>("Fonts/RegularFont"),
                game.Content.Load<SpriteFont>("Fonts/HighlightFont"),
                menuArray, click);
            this.Components.Add(menu);
            this.song = song;
            MediaPlayer.IsRepeating = true;
            this.click = click;
        }

        
    }
}
