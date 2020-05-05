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
#endregion

namespace Pacman.GameObjects
{
    class Fraude : Ghosts
    {
        Random rnd = new Random();
        public Fraude(Vector2 pos) : base(pos, "Ghost1")
        {
            this.position = pos;
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            Vector2 oldPosition = position;
            ghostWalk = rnd.Next(4);
            if (inputHelper.KeyPressed(Keys.W) || inputHelper.KeyPressed(Keys.A) || inputHelper.KeyPressed(Keys.S) || inputHelper.KeyPressed(Keys.D))
            {

                switch (ghostWalk)
                {
                    case 0:
                        {
                            if (position.X > 25)
                            {
                                position.X -= 50;
                            }
                            break;
                        }
                    case 1:
                        {
                            if (position.X < 675)
                            {
                                position.X += 50;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (position.Y < 975)
                            {
                                position.Y += 50;
                            }
                            break;
                        }
                    case 3:
                        {
                            if (position.Y > 25)
                            {
                                position.Y -= 50;
                            }
                            break;
                        }
                }
                if (CollidesWithGhost(this))
                {
                    position = oldPosition;
                }

            }

        }
    }
}
