#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.GameStates;
using Pacman.GameObjects;
#endregion

namespace Pacman
{
    public class PacManGameObject : RotatingSpriteGameObject
    {
        #region Constructor
        /// <summary>
        /// Constructor for the Pacman
        /// </summary>
        /// <param name="position">gives the starting position for the pacman</param>
        public PacManGameObject(Vector2 position) : base("PacMan2")
        {
            this.position = position;
        }
        #endregion

        public override void Update(GameTime gameTime)
        {
            
        }

        #region Input handler
        /// <summary>
        /// Handles the keyboard inputs and responds apropriatly by moving the Pacman
        /// </summary>
        /// <param name="inputHelper"></param>
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.KeyPressed(Keys.W) && position.Y > 25)
            {
                position.Y -= 50;
                Degrees = (270);
            }
            if (inputHelper.KeyPressed(Keys.A) && position.X > 25)
            {
                position.X -= 50;
                Degrees = (180);
            }
            if (inputHelper.KeyPressed(Keys.S) && position.Y < 975)
            {
                position.Y += 50;
                Degrees = (90);
            }
            if (inputHelper.KeyPressed(Keys.D) && position.X < 675)
            {
                position.X += 50;
                Degrees = (0);
            } 
            
        }
        #endregion
    }
}
