using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;




namespace Pong
{

    class Ball : Sprite
    {
        Point pBallPointPosition;
        Vector2 v2BallPosition;

        float fSpeedX;
        float fSpeedY;


        public void LoadContent(ContentManager thecontentManager, string sfileName)
        {

            base.LoadContent(thecontentManager, sfileName);

            v2BallPosition = new Vector2(Game1.iScreenWidth / 2  - tSprite.Width  / 2,
                                         Game1.iScreenHeight / 2 - tSprite.Height / 2);
            


            fSpeedX = 45;
            fSpeedY = 50;


        }



        public void Update(GameTime thegameTime)
        {

            ScreenCollision();


            v2BallPosition += new Vector2(fSpeedX * (float)thegameTime.ElapsedGameTime.TotalSeconds, 
                fSpeedY * (float)thegameTime.ElapsedGameTime.TotalSeconds);


        }

        public void ScreenCollision()
        {
 




        }






        public void Draw(SpriteBatch thespriteBatch)
        {


            thespriteBatch.Draw(tSprite, v2BallPosition, rSpriteSource, Color.White);
            //thespriteBatch.Draw(tSprite, v2BallPosition, rSpriteSource, Color.White, 0.0f, Vector2.Zero, fSpriteScale, SpriteEffects.None, 1.0f);



        }









    //
    }
//
}
