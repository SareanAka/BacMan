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
    class GameOverState : GameObjectList
    {
        public bool scoreFinal = ;
        bool check;
        public GameOverState()
        {
            if(scoreFinal == true)
            {
                check = true;
            }

            SpriteGameObject gameOverScreen = new SpriteGameObject("gameOverScreen");

            this.Add(gameOverScreen);

            gameOverScreen.Origin = new Vector2(0, 0);
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
