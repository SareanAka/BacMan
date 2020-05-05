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
    class Ghosts : SpriteGameObject
    {
        public int ghostWalk;
        public Ghosts(Vector2 pos, string assetname) : base(assetname)
        {
            
        }

        public bool CollidesWithGhost(Ghosts self)
        {
            bool temp = false;
            foreach(Ghosts ghosts in PlayingState.spookjes.Children)
            {
                if (this.CollidesWith(ghosts) && ghosts != self)
                {
                    temp = true;
                }
            }
            return temp;
                

        }

        public override void HandleInput(InputHelper inputHelper)
        {
        }
    }
}
