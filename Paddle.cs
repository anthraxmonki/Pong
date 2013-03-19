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
        public float fBallSpeedX;
        public float fBallSpeedY;

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



        public Vector2 UpdatePaddleCollision(float fballSpeed, Vector2 v2ballPosition, Rectangle rballSource)
        {
            Vector2 v2ReturnedBallPosition;

            if (IsPaddleCollision(rballSource) == true)
            {
                v2ReturnedBallPosition = CollisionLogic(fballSpeed, v2ballPosition, rballSource);

                return v2ReturnedBallPosition;
            }

            return v2ballPosition;
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








        public Vector2 CollisionLogic(float fballSpeed, Vector2 v2ballPosition, Rectangle rballSource)
        {

            if (rballSource.Intersects(rSpriteSource)
                && rballSource.Left < rSpriteSource.Right)
            {
                //Don't go through the paddle. Ever.
                v2ballPosition = new Vector2(rSpriteSource.Right, v2ballPosition.Y);

                fBallSpeedX = fballSpeed * -1;

                this.fBallSpeedX = fballSpeed;
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