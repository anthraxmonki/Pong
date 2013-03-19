using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;




namespace Pong
{

    class Sprite
    {

        protected Texture2D tSprite;
        

        //TO-FIX
        //    Images don't scale -- the actual .png doesn't increase in size - the rectangle scale just fine 
        //    Gonna have to 


        //TO-DO
        //create collision rectangles
        //change the ball's direction based on screen collision's
        //    if it touches top or bottom, multiply by v2(0, -1)
        // if it touches the left or right, multiply by v2(-1, 0)

        //Give paddles 3 collision rectangles
        // edges and center
        //    modify the ball's speed += more if it touches an edge
        //    Draw the paddle rectangle's in the PAddle Classes Draw method
        //    So we don't have to call anything extra in Game1

        protected Rectangle rSpriteSource;
        protected Rectangle rSpriteSize;

        public float fSpriteScale = 1.0f;
        //This getter/setter function doesn't adjust the size and source rectangles when called.
        //    Needs to be fixed. 
        //public float fSetScale
        //{
        //    get { return fScale; }
        //    set
        //    {
        //        rSpriteSize = new Rectangle(0, 0, (int)(tSprite.Width * fSetScale), (int)(tSprite.Height * fSetScale));
        //        rSpriteSource = rSpriteSize;
        //    }
        //}


        public void LoadContent(ContentManager thecontentManager, string sfileName)
        {
            tSprite = thecontentManager.Load<Texture2D>(sfileName);
            rSpriteSize = new Rectangle(0, 0, (int)(tSprite.Width * fSpriteScale), (int)(tSprite.Height * fSpriteScale));
            rSpriteSource = rSpriteSize;

        }




        public void Update(GameTime thegameTime)
        {


        }




        public virtual void Draw(SpriteBatch thespriteBatch)
        {



        }






    }
}
