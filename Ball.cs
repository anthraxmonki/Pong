using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


//EXTRAS
//    Give each paddle an amount of lives
//    When the ball hits the screen edge behind you, 
//    you lose a score.
//        -Last Man Standing games all lives decrement
//        -or Greed, where the scoring paddle steals a life
//         or the scored-on paddle.

namespace Pong
{

    class Ball : Sprite
    {
        const float fSpeedMaxX = 1000;
        const float fSpeedMaxY = 500;



        static Random oRandom = new Random();
        public Vector2 v2BallPosition;

        static int iRandom;

        public float fSpeedX;
        public float fSpeedY;
        public float fSpeedIncrementer;





        public Rectangle rBallRectangle;
  

        //Instantiate the ball's sprite characteristics
        //    Randomize the ball direction
        //    while maintaing a playable speed and angle
        public void LoadContent(ContentManager thecontentManager, string sfileName)
        {

            base.LoadContent(thecontentManager, sfileName);

            v2BallPosition = new Vector2(Game1.iScreenWidth / 2  - tSprite.Width  / 2,
                                         Game1.iScreenHeight / 2 - tSprite.Height / 2);

            
            iRandom = oRandom.Next(350, 425);
            fSpeedX =  iRandom;
            iRandom = oRandom.Next(-2, 2);
            if (iRandom < 0)
            {
                fSpeedX *= -1;
            }



            iRandom = oRandom.Next(250, 450);
            fSpeedY = iRandom;
            iRandom = oRandom.Next(-2, 2);
            if (iRandom < 0)
            {
                fSpeedY *= -1;
            }




        }



        public void Update(GameTime thegameTime)
        {
            

            ScreenCollision();


            v2BallPosition += new Vector2(fSpeedX * (float)thegameTime.ElapsedGameTime.TotalSeconds, 
                                          fSpeedY * (float)thegameTime.ElapsedGameTime.TotalSeconds);

            rSpriteSource = new Rectangle((int)v2BallPosition.X, (int)v2BallPosition.Y, 
                                            rSpriteSource.Width, rSpriteSource.Height);
            rBallRectangle = rSpriteSource;

        }


        //Bounce off the screen
        //   Proof logic to be implemented with Paddles later
        public void ScreenCollision()
        {
            if (rSpriteSource.Left     < Game1.rScreen.Left)
            {
                v2BallPosition = new Vector2(Game1.rScreen.Left, v2BallPosition.Y);
                fSpeedX = fSpeedX * -1;

                BallSpeedIncrementX();
            }

            else if (rSpriteSource.Right > Game1.rScreen.Right)
            {
                v2BallPosition = new Vector2(Game1.rScreen.Right - rSpriteSource.Width, v2BallPosition.Y);
                fSpeedX = fSpeedX * -1;

                BallSpeedIncrementX();
            }

            else if (rSpriteSource.Top < Game1.rScreen.Top)
            {
                v2BallPosition = new Vector2(v2BallPosition.X, Game1.rScreen.Top);
                fSpeedY = fSpeedY * -1;

                BallSpeedIncrementY();
            }

            else if (rSpriteSource.Bottom > Game1.rScreen.Bottom)
            {
                v2BallPosition = new Vector2(v2BallPosition.X, Game1.rScreen.Bottom - rSpriteSource.Height);
                fSpeedY = fSpeedY * -1;

                BallSpeedIncrementY();
            }
        }




        //Check if fSpeed is Negative
        //    Increment accordingly

        public void BallSpeedIncrementX()
        {
            iRandom = oRandom.Next(13, 37);
            fSpeedIncrementer = iRandom;

            if (fSpeedX < fSpeedMaxX && fSpeedX > -fSpeedMaxX)
            {
                if (fSpeedX < 0)
                {
                    fSpeedX += -fSpeedIncrementer;
                }
                else
                {
                    fSpeedX += fSpeedIncrementer;
                }
            }

            else
            {
                fSpeedX += -iRandom;
            }


        }


        //the outside Else clause if made to 
        //   keep the ball out of a ricochet loop
        //the outside Else will also slightly increase
        //    over the Mx speed, and this is okay.
        public void BallSpeedIncrementY()
        {
            iRandom = oRandom.Next(13, 37);
            fSpeedIncrementer = iRandom;

            if (fSpeedY < fSpeedMaxY && fSpeedY > -fSpeedMaxY)
            {
                if (fSpeedY < 0)
                {
                    fSpeedY += -fSpeedIncrementer;
                }
                else
                {
                    fSpeedY += fSpeedIncrementer;
                }

            }
            else
            {
                fSpeedY += -iRandom + -50;
            }

        }



        public void Draw(SpriteBatch thespriteBatch)
        {

            thespriteBatch.Draw(tSprite, rSpriteSource, Color.White);

            base.Draw(thespriteBatch);

        }









    //
    }
//
}
