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
    /// <summary>
    /// Parent class of all the ghosts
    /// </summary>
    class Ghosts : SpriteGameObject
    {
        public int ghostWalk;
        public Ghosts(Vector2 pos, string assetname) : base(assetname)
        {
            
        }

        #region Collision detections Ghosts
        /// <summary>
        /// handles the collision detection so they don't overlap with eachother
        /// </summary>
        /// <param name="self">Refers to the ghosts themself</param>
        /// <returns></returns>
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
        #endregion

        public override void HandleInput(InputHelper inputHelper)
        {
        }
    }
}
