using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class StartState : GameObjectList
    {
        public StartState()
        {
            SpriteGameObject startscreen = new SpriteGameObject("StartScreen");

            this.Add(startscreen);

            startscreen.Origin = new Vector2 (150, 0);
        }

        public override void HandleInput(InputHelper inputHelper)
        {
            base.HandleInput(inputHelper);
            if (inputHelper.KeyPressed(Keys.Space))
            {
                GameEnvironment.GameStateManager.SwitchTo("PlayingState");
            }
        }
    }
}