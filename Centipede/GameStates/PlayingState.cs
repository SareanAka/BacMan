#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pacman;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pacman.GameObjects;
#endregion

namespace Pacman.GameStates
{
    class PlayingState : GameObjectList
    {
        public Random random = new Random();

        #region Public Variables
       
        public Vector2 StartingPositionFraude = new Vector2 (175, 175);
        public Vector2 StartingPositionSmite = new Vector2(175, 825);
        public Vector2 StartingPositionSleep = new Vector2(525, 175);
        public Vector2 StartingPositionVirus = new Vector2(525, 825);
        public Vector2 StartingPositionPacman = new Vector2(325, 525);
        #endregion

        PacManGameObject pacman;


        #region Ghosts
        /// <summary>
        /// Create the GameObjectList for the ghosts
        /// </summary>
        Fraude fraude;
        Smite smite;
        Virus virus;
        Sleep sleep;
        static public GameObjectList spookjes = new GameObjectList();
        #endregion

        #region Points
        /// <summary>
        /// Create the GameObjectList for Points
        /// </summary>
        Points points;
        static public GameObjectList punten = new GameObjectList();
        #endregion

        #region Constructor
        public PlayingState()
        {
            
            Reset();
        }
        #endregion

        #region Reset
        public override void Reset()
        {
            children.Clear();

            SpriteGameObject background = new SpriteGameObject("Background");

            this.Add(background);

            background.Origin = new Vector2(0, 0);

            fraude = new Fraude(new Vector2(StartingPositionFraude.X, StartingPositionFraude.Y));
            smite = new Smite(new Vector2(StartingPositionSmite.X, StartingPositionSmite.Y));
            virus = new Virus(new Vector2(StartingPositionSleep.X, StartingPositionSleep.Y));
            sleep = new Sleep(new Vector2(StartingPositionVirus.X, StartingPositionVirus.Y));

            pacman = new PacManGameObject(new Vector2(StartingPositionPacman.X, StartingPositionPacman.Y));

            points = new Points(new Vector2(25 + 50 * random.Next(0, GameEnvironment.Screen.X / 50 - 1),
                25 + 50 * random.Next(0, GameEnvironment.Screen.Y / 50 - 1)));

            this.Add(punten);
            punten.Add(points);

            this.Add(spookjes);
            spookjes.Add(fraude);
            spookjes.Add(smite);
            spookjes.Add(virus);
            spookjes.Add(sleep);

            this.Add(pacman);

            base.Reset();
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime)
        {
            if (CollidesWithPacman(pacman))
            {
                points = new Points(new Vector2(25 + 50 * random.Next(0, GameEnvironment.Screen.X / 50 - 1), 25 + 50 * random.Next(0,
                    GameEnvironment.Screen.Y / 50 - 1)));
                punten.Children.Clear();
                punten.Add(points);
                punten.Children[0].Reset();
            }

            if (GhostCollidesWithPacman(pacman))
            {
                Console.WriteLine("Hey");
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                Reset();
            }

            base.Update(gameTime);
        }
        #endregion

        #region PacmanCollision Bool
        public bool CollidesWithPacman(PacManGameObject pacman)
        {
            bool temp = false;
            foreach (Points points in punten.Children)
            {
                if (points.CollidesWith(pacman))
                {
                    temp = true;
                }
            }
            return temp;
        }
        #endregion
        
        #region PacmanDeath Bool
        public bool GhostCollidesWithPacman(PacManGameObject pacman)
        {
            bool temp = false;
            foreach (Ghosts ghosts in spookjes.Children)
            {
                if (ghosts.CollidesWith(pacman))
                {
                    temp = true;
                }
            }
            return temp;
        }
        #endregion
    }
}