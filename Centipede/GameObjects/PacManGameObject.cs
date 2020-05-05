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
        public PacManGameObject(Vector2 position) : base("PacMan2")
        {
            this.position = position;
        }

        public override void Update(GameTime gameTime)
        {
            
        }
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
    }
}
