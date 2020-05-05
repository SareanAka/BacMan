using Pacman.GameStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Pacman : GameEnvironment
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(700, 1000);
            ApplyResolutionSettings();

            GameStateManager.AddGameState("PlayingState", new PlayingState());
            GameStateManager.AddGameState("StartState", new StartState());
            GameStateManager.AddGameState("GameOverState", new GameOverState());

            GameStateManager.SwitchTo("StartState");

            // TODO: use this.Content to load your game content here
        }
        
    }
}
