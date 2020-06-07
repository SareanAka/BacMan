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
       /// <summary>
       /// all starting positions for the Ghosts and Pacman
       /// </summary>
        public Vector2 StartingPositionFraude = new Vector2 (175, 175);
        public Vector2 StartingPositionSmite = new Vector2(175, 825);
        public Vector2 StartingPositionSleep = new Vector2(525, 175);
        public Vector2 StartingPositionVirus = new Vector2(525, 825);
        public Vector2 StartingPositionPacman = new Vector2(325, 525);
        /// <summary>
        /// step intervals
        /// </summary>
        public int interval = 50;

        int score;
        #endregion

        #region New Objects
        PacManGameObject pacman;
        Score scoreText;

        GameObjectList bullets;
        #endregion

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
            bullets = new GameObjectList();
            this.Add(bullets);
            
        }
        #endregion

        #region Reset
        /// <summary>
        /// Executes everything that is in the first frame of playingstate
        /// </summary>
        public override void Reset()
        {

            SpriteGameObject background = new SpriteGameObject("Background");

            this.Add(background);

            background.Origin = new Vector2(0, 0);

            scoreText = new Score("File");

            fraude = new Fraude(new Vector2(StartingPositionFraude.X, StartingPositionFraude.Y));
            smite = new Smite(new Vector2(StartingPositionSmite.X, StartingPositionSmite.Y));
            virus = new Virus(new Vector2(StartingPositionSleep.X, StartingPositionSleep.Y));
            sleep = new Sleep(new Vector2(StartingPositionVirus.X, StartingPositionVirus.Y));

            pacman = new PacManGameObject(new Vector2(StartingPositionPacman.X, StartingPositionPacman.Y));

            points = new Points(new Vector2(25 + interval * random.Next(0, GameEnvironment.Screen.X / interval - 1),
                25 + interval * random.Next(0, GameEnvironment.Screen.Y / interval - 1)));

            this.Add(scoreText);

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
        /// <summary>
        /// checks for all collisions between game objects and draws the score
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            scoreText.score = score;

            if (CollidesWithPacman(pacman))
            {
                points = new Points(new Vector2(25 + interval * random.Next(0, GameEnvironment.Screen.X / interval - 1), 25 + interval * random.Next(0,
                    GameEnvironment.Screen.Y / interval - 1)));
                punten.Children.Clear();
                punten.Add(points);
                punten.Children[0].Reset();
                AddScore();
            }

            if (GhostCollidesWithPacman(pacman) || BulletCollidesWithPacman(pacman))
            {
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");
                Reset();
            }

            foreach (Ghosts ghost in spookjes.Children)
            {
                if (ghost is Fraude)
                {
                    if (GameEnvironment.Random.Next(400) == 1)
                    {
                        bullets.Add(new Bullet(ghost.Position, pacman.Position - ghost.Position));
                    }
                }
            }

            foreach (Ghosts ghost in spookjes.Children)
            {
                if (ghost is Sleep)
                {
                    if (GameEnvironment.Random.Next(400) == 1)
                    {
                        bullets.Add(new Bullet(ghost.Position, pacman.Position - ghost.Position));
                    }
                }
            }

            foreach (Ghosts ghost in spookjes.Children)
            {
                if (ghost is Virus)
                {
                    if (GameEnvironment.Random.Next(400) == 1)
                    {
                        bullets.Add(new Bullet(ghost.Position, pacman.Position - ghost.Position));
                    }
                }
            }

            foreach (Ghosts ghost in spookjes.Children)
            {
                if (ghost is Smite)
                {
                    if (GameEnvironment.Random.Next(400) == 1)
                    {
                        bullets.Add(new Bullet(ghost.Position, pacman.Position - ghost.Position));
                    }
                }
            }

            base.Update(gameTime);
        }
        #endregion

        #region Score
        /// <summary>
        /// Adds to the score
        /// </summary>
        public void AddScore()
        {
            score++;
        }
        #endregion

        #region PacmanCollision Bool
        /// <summary>
        /// Collision bool between the Points and the Pacman
        /// </summary>
        /// <param name="pacman"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Collision bool between the Pacman and the Ghosts
        /// </summary>
        /// <param name="pacman"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Collision bool between the Pacman and the bullets
        /// </summary>
        /// <param name="pacman"></param>
        /// <returns></returns>
        public bool BulletCollidesWithPacman(PacManGameObject pacman)
        {

            bool temp2 = false;
            foreach (Bullet bullet in bullets.Children)
            {
                if (bullet.CollidesWith(pacman))
                {
                    temp2 = true;
                }
            }
            return temp2;
        }
        #endregion
    }
}