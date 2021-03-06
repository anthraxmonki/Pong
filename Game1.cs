using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Pong
{
    //TO-DO
    //Add individual methods for each PAddle
    //    left, right, top, bottom
    //    so they can adjust the ball accordingly


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Rectangle rScreen;


        public static KeyboardState ksCurrentState;
        public static KeyboardState ksPreviousState;



        //we instantiate these textures in Game1
        //    so we can grab their width and heightt
        Texture2D tPaddle;
        Texture2D tPaddleRotated;

        public static int iScreenWidth;
        public static int iScreenHeight;

        Ball   oBall;
        Paddle oPaddleLeft;
        Paddle oPaddleRight;
        Paddle oPaddleBottom;
        Paddle oPaddleTop;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            this.graphics.PreferredBackBufferWidth = 1000;
            this.graphics.PreferredBackBufferHeight = 500;
            iScreenWidth  = this.graphics.PreferredBackBufferWidth;
            iScreenHeight = this.graphics.PreferredBackBufferHeight;
            rScreen = new Rectangle(0, 0, iScreenWidth, iScreenHeight);         
        }





        protected override void Initialize()
        {
            ksCurrentState  = new KeyboardState();
            ksPreviousState = new KeyboardState();


            //tPaddle is instantiated in LoadContent
            oBall        = new Ball();
            oPaddleLeft   = new Paddle();
            oPaddleRight  = new Paddle();
            oPaddleBottom = new Paddle();
            oPaddleTop    = new Paddle();



            base.Initialize();
        }







        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tPaddle = Content.Load<Texture2D>("pongpaddle");
            tPaddleRotated = Content.Load<Texture2D>("pongpaddleRotated");


            oBall.LoadContent(Content, "earthSmall");


            oPaddleLeft.LoadContent(Content, "pongpaddle");
            oPaddleLeft.SetPaddleControlsUpDown(Keys.D1, Keys.D3);
            oPaddleLeft.SetPaddlePosition(new Vector2(0,
                                                      iScreenHeight / 2 - tPaddle.Height/2));

            oPaddleRight.LoadContent(Content, "pongpaddle");
            oPaddleRight.SetPaddleControlsUpDown(Keys.Up, Keys.Down);
            oPaddleRight.SetPaddlePosition(new Vector2(iScreenWidth - tPaddle.Width, 
                                                       iScreenHeight/2 - tPaddle.Height/2));

            oPaddleBottom.LoadContent(Content, "pongpaddleRotated");
            oPaddleBottom.SetPaddleControlsLeftRight(Keys.Z, Keys.C);
            oPaddleBottom.SetPaddlePosition(new Vector2(iScreenWidth/2 - tPaddleRotated.Width / 2,
                                                        iScreenHeight - tPaddleRotated.Height));

            oPaddleTop.LoadContent(Content, "pongpaddleRotated");
            oPaddleTop.SetPaddleControlsLeftRight(Keys.B, Keys.M);
            oPaddleTop.SetPaddlePosition(new Vector2(iScreenWidth / 2 - tPaddleRotated.Width / 2,
                                                     0));


        }


        //Haven't found a reason yet to use unload
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }












        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            //This order is important.  
            //    If you get the current state
            //    and then assign the old keyboard to the current one they will be the same.
            ksPreviousState = ksCurrentState;
            ksCurrentState  = Keyboard.GetState();


            CheckPaddleCollisions();


            oBall.Update(gameTime);

            //LetsTrySomeAI();

            oPaddleLeft.Update (gameTime);
            oPaddleRight.Update(gameTime);
            oPaddleBottom.Update(gameTime);
            oPaddleTop.Update(gameTime);



            base.Update(gameTime);
        }



        public void LetsTrySomeAI()
        {
            oPaddleLeft.v2PaddlePosition = new Vector2(oPaddleLeft.v2PaddlePosition.X, oBall.rBallRectangle.Y);
            oPaddleRight.v2PaddlePosition = new Vector2(oPaddleRight.v2PaddlePosition.X, oBall.rBallRectangle.Y);
            oPaddleBottom.v2PaddlePosition = new Vector2(oBall.rBallRectangle.X, oPaddleBottom.v2PaddlePosition.Y);
            oPaddleTop.v2PaddlePosition = new Vector2(oBall.rBallRectangle.X, oPaddleTop.v2PaddlePosition.Y);


        }



        public void CheckPaddleCollisions()
        {
            if (oPaddleLeft.IsPaddleCollision(oBall.rBallRectangle) == true)
            {
                oBall.v2BallPosition = oPaddleLeft.LeftPaddleCollision(oBall.fSpeedX, oBall.v2BallPosition, oBall.rBallRectangle);
                oBall.fSpeedX = Paddle.fBallSpeedX;
                oBall.BallSpeedIncrementX();
            }
            else if (oPaddleRight.IsPaddleCollision(oBall.rBallRectangle) == true)
            {
                oBall.v2BallPosition = oPaddleRight.RightPaddleCollision(oBall.fSpeedX, oBall.v2BallPosition, oBall.rBallRectangle);
                oBall.fSpeedX = Paddle.fBallSpeedX;
                oBall.BallSpeedIncrementX();
            }
            else if (oPaddleBottom.IsPaddleCollision(oBall.rBallRectangle) == true)
            {
                oBall.v2BallPosition = oPaddleBottom.BottomPaddleCollision(oBall.fSpeedY, oBall.v2BallPosition, oBall.rBallRectangle);
                oBall.fSpeedY = Paddle.fBallSpeedY;
                oBall.BallSpeedIncrementY();
            }
            else if (oPaddleTop.IsPaddleCollision(oBall.rBallRectangle) == true)
            {
                oBall.v2BallPosition = oPaddleTop.TopPaddleCollision(oBall.fSpeedY, oBall.v2BallPosition, oBall.rBallRectangle);
                oBall.fSpeedY = Paddle.fBallSpeedY;
                oBall.BallSpeedIncrementY();
            }


        }








        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            oBall.Draw(spriteBatch);

            oPaddleLeft.Draw(spriteBatch);
            oPaddleRight.Draw(spriteBatch);
            oPaddleBottom.Draw(spriteBatch);
            oPaddleTop.Draw(spriteBatch);



            spriteBatch.End();
            base.Draw(gameTime);
        }








    //
    }
//
}
