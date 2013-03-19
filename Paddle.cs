using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Design;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;





namespace Pong
{

    class Paddle : Sprite
    {

        //KeyboardState ksCurrentState = Keyboard.GetState();


        Vector2 v2PaddlePosition;



        Keys oUpKey;
        Keys oDownKey;
        Keys oRightKey;
        Keys oLeftKey;

        float fPaddleSpeed = 240;
        public static float fBallSpeedX;
        public static float fBallSpeedY;

        public void LoadContent(ContentManager thecontentManager, string sfileName)
        {
            base.LoadContent(thecontentManager, sfileName);

        }

        public void SetPaddlePosition(Vector2 v2StartPosition)
        {
            v2PaddlePosition = v2StartPosition;
        }

        public void SetPaddleControlsUpDown(Keys kupKey, Keys kdownKey)
        {
            this.oUpKey = new Keys();
            this.oDownKey = new Keys();
            oUpKey = kupKey;
            oDownKey = kdownKey;
        }

        public void SetPaddleControlsLeftRight(Keys kLeftKey, Keys kRightKey)
        {

            this.oLeftKey = new Keys();
            this.oRightKey = new Keys();
            oLeftKey = kLeftKey;
            oRightKey = kRightKey;


        }







        public void Update(GameTime thegameTime)
        {
            rSpriteSource = new Rectangle((int)v2PaddlePosition.X, (int)v2PaddlePosition.Y,
                                rSpriteSource.Width, rSpriteSource.Height);



            MovePaddle(thegameTime);

        }







        public bool IsPaddleCollision(Rectangle rballSource)
        {
            if (rSpriteSource.Intersects(rballSource))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        //Left Paddle Left Paddle Left Paddle
        public Vector2 LeftPaddleCollision(float fballSpeedX, Vector2 v2ballPosition, Rectangle rballRectangle)
        {
            if (rballRectangle.Intersects(rSpriteSource)
                && rballRectangle.Left < rSpriteSource.Right)
            {
                //Don't go through the paddle. Ever.
                v2ballPosition = new Vector2(rSpriteSource.Right, v2ballPosition.Y);

                fBallSpeedX = fballSpeedX * -1;
            }
            return v2ballPosition;
        }

        //RIGHT PADDLE RIGHT PADDLE RIGHT PADDLE
        public Vector2 RightPaddleCollision(float fballSpeedX, Vector2 v2ballPosition, Rectangle rballRectangle)
        {
            if (rballRectangle.Intersects(rSpriteSource)
                && rballRectangle.Right > rSpriteSource.Left)
            {
                //Don't go through the paddle. Ever.
                v2ballPosition = new Vector2(rSpriteSource.Left - rballRectangle.Width, v2ballPosition.Y);

                fBallSpeedX = fballSpeedX * -1;
            }
            return v2ballPosition;
        }


        //BOTTOM PADDLE BOTTOM PADDLE BOTTOM PADDLE BOTTOM PADDLE
        public Vector2 BottomPaddleCollision(float fballSpeedY, Vector2 v2ballPosition, Rectangle rballRectangle)
        {
            if (rballRectangle.Intersects(rSpriteSource)
                && rballRectangle.Bottom > rSpriteSource.Top)
            {
                //Don't go through the paddle. Ever.
                v2ballPosition = new Vector2(v2ballPosition.X, rSpriteSource.Top - rballRectangle.Height);

                fBallSpeedY = fballSpeedY * -1;
            }
            return v2ballPosition;
        }


        public Vector2 TopPaddleCollision(float fballSpeedY, Vector2 v2ballPosition, Rectangle rballRectangle)
        {
            if (rballRectangle.Intersects(rSpriteSource)
                && rballRectangle.Top < rSpriteSource.Bottom)
            {
                //Don't go through the paddle. Ever.
                v2ballPosition = new Vector2(v2ballPosition.X, rSpriteSource.Bottom);

                fBallSpeedY = fballSpeedY * -1;
            }
            return v2ballPosition;
        }
















        //move the paddle up, down, left, or right
        //multiply by (float)thegameTime.ElapsedGameTime.TotalSeconds)
        //    to update venly across processors -- some are faster than others
        //    ElapsedGameTime is much different than TotalGametime.
        public void MovePaddle(GameTime thegameTime)
        {
            //UPUPUP
            if (CheckInput.JustPressed(oUpKey) == true)
            {
                v2PaddlePosition += new Vector2(0, (-1 * fPaddleSpeed) * (float)thegameTime.ElapsedGameTime.TotalSeconds);
            }
            if (CheckInput.IsHeld(oUpKey) == true)
            {
                v2PaddlePosition += new Vector2(0, (-1 * fPaddleSpeed) * (float)thegameTime.ElapsedGameTime.TotalSeconds);
            }
            //DOWN DOWN DOWN
            if (CheckInput.JustPressed(oDownKey) == true)
            {
                v2PaddlePosition += new Vector2(0, fPaddleSpeed * (float)thegameTime.ElapsedGameTime.TotalSeconds);
            }
            if (CheckInput.IsHeld(oDownKey) == true)
            {
                v2PaddlePosition += new Vector2(0, fPaddleSpeed * (float)thegameTime.ElapsedGameTime.TotalSeconds);
            }

            //LEFT LEFT LEFT
            if (CheckInput.JustPressed(oLeftKey) == true)
            {
                v2PaddlePosition += new Vector2((-1 * fPaddleSpeed) * (float)thegameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (CheckInput.IsHeld(oLeftKey) == true)
            {
                v2PaddlePosition += new Vector2((-1 * fPaddleSpeed) * (float)thegameTime.ElapsedGameTime.TotalSeconds, 0);
            }

            //RIGHT RIGHT RIGHT
            if (CheckInput.JustPressed(oRightKey) == true)
            {
                v2PaddlePosition += new Vector2(fPaddleSpeed * (float)thegameTime.ElapsedGameTime.TotalSeconds, 0);
            }
            if (CheckInput.IsHeld(oRightKey) == true)
            {
                v2PaddlePosition += new Vector2(fPaddleSpeed * (float)thegameTime.ElapsedGameTime.TotalSeconds, 0);
            }


        }
















        public void Draw(SpriteBatch thespriteBatch)
        {

            //thespriteBatch.Draw(tSprite, v2PaddlePosition, rSpriteSource, Color.White);
            //thespriteBatch.Draw(tSprite, v2PaddlePosition, rSpriteSource, Color.White, 0.0f, Vector2.Zero, fSpriteScale, SpriteEffects.None, 1.0f);
            thespriteBatch.Draw(tSprite, rSpriteSource, Color.White);

        }








        //
    }
    //
}