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

namespace Pacman.GameObjects
{
    public class Bullet : SpriteGameObject
    {
        public Bullet(Vector2 pos, Vector2 direction) : base("Bullet")
        {
            position = pos;
            direction.Normalize();
            velocity = new Vector2(150, 150);
            velocity *= direction;
        }
    }
}
