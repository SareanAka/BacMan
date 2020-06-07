using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.GameObjects;

namespace Pacman.GameStates
{
    class WinGameState : GameObjectList
    {
        public WinGameState()
        {

            SpriteGameObject winScreen = new SpriteGameObject("WinScreen");

            this.Add(winScreen);

            winScreen.Origin = new Vector2(0, 0);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                System.Environment.Exit(1);
            }
        }
    }
}
