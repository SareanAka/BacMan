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
    class Score : TextGameObject
    {
        public int score;
        public bool scoreFinal;

        public Score(string assetname) : base("File")
        {
            position = new Vector2(100, 50);
            layer = 100;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text = "Gems: " + score + "/30";

            if (score == 30)
            {
                GameEnvironment.GameStateManager.SwitchTo("WinGameState");
                scoreFinal = true;
            }
        }
    }
}
