﻿/*
 *      PROG 2370 FINAL PROJECT
 * 
 * Ezatullah Rafie
 * Keum Ji Kim
 * 
 * Revision History
 *      Dec 04, 2020 : Created
 *                      - Shared, GameScene, StartScene, PlayScene, HelpScene, HighScoreScene, AboutScene, MenuComponent
 *      Dec 05, 2020 : Added Image and Sound Contents
 *      
 *      ===================================================
 *      Dec 11, 2020 : Separated file created
 *                      Add astronaut component with moving
 *                      
 * 
 */


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media; // for background music
using Microsoft.Xna.Framework.Audio; // for sound effect

namespace GameFinalProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // all scenes references
        private StartScene startScene;
        private PlayScene playScene;
        private HelpScene helpScene;
        private HighScoreScene highScoreScene;
        private AboutScene aboutScene;

        // all bgm references
        private Song startMusic;
        private Song backgroundMusic;

        // soundEffect
        private SoundEffect click;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight);

            base.Initialize();
        }
        
        //* Need comment
        /// <summary>
        /// 
        /// </summary>
        private void HideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in this.Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.Hide();
                }
            }
        }


        /// <summary>
        /// Switch background music.
        /// If the music was already playing, make it stop and play new song.
        /// </summary>
        /// <param name="song"></param>
        private static void SwitchMusic(Song song)
        {
            if (MediaPlayer.State == MediaState.Playing)
            {
                MediaPlayer.Stop();
            }
            MediaPlayer.Play(song);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // background music
            startMusic = Content.Load<Song>("Sounds/StartMusic");
            backgroundMusic = Content.Load<Song>("Sounds/BackgroundMusic");
            click = Content.Load<SoundEffect>("Sounds/Click");

            // Instantiate all scenes
            startScene = new StartScene(this, spriteBatch, startMusic, click);
            this.Components.Add(startScene);
            
            playScene = new PlayScene(this, spriteBatch, backgroundMusic);
            this.Components.Add(playScene);

            helpScene = new HelpScene(this, spriteBatch);
            this.Components.Add(helpScene);

            highScoreScene = new HighScoreScene(this, spriteBatch);
            this.Components.Add(highScoreScene);

            aboutScene = new AboutScene(this, spriteBatch);
            this.Components.Add(aboutScene);

            // Show only startScene and play start music
            startScene.Show();
            SwitchMusic(startMusic);

        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            //* tbh I don't know what these mean but somebody in stackoverflow wrote these so just followed
            if (startMusic != null)
            {
                startMusic.Dispose();
            }
            if (backgroundMusic != null)
            {
                backgroundMusic.Dispose();
            }
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            int selectedIndex = 0;
            KeyboardState ks = Keyboard.GetState();

            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex; //* StartScene.cs > MenuComponent > SelectedIndex
                if (ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    // sound effect when selecting menu
                    click.Play();
                    switch (selectedIndex)
                    {
                        case 0:
                            playScene.Show();
                            SwitchMusic(backgroundMusic);
                            break;
                        case 1:
                            helpScene.Show();
                            break;
                        case 2:
                            highScoreScene.Show();
                            break;
                        case 3:
                            aboutScene.Show();
                            break;
                        case 4:
                            this.Exit();
                            break;
                        default:
                            //* ERROR CATCH
                            break;
                    }
                }
                //* changed this if block to switch
                //if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                //{
                //    HideAllScenes();
                //    playScene.Show();
                //}
                //if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                //{
                //    HideAllScenes();
                //    helpScene.Show();
                //}
                //if (selectedIndex == 4 && ks.IsKeyDown(Keys.Enter)) // QUIT
                //{
                //    this.Exit();
                //}
            }
            
            if (playScene.Enabled || helpScene.Enabled || highScoreScene.Enabled || aboutScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.Show();
                    SwitchMusic(startMusic);
                }
            }

            base.Update(gameTime);
        }

        private void MediaPlayer_ActiveSongChanged(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LavenderBlush);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
