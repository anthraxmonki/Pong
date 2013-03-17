using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework.Input;


namespace Pong
{
    public class CheckInput
    {

        //check to see if the key is held down 
        public static bool IsHeld(Keys key)
        {
            if (Game1.ksCurrentState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        //Check to see if the key was just released
        public static bool IsReleased(Keys key)
        {
            if (Game1.ksCurrentState.IsKeyUp(key)
                && Game1.ksPreviousState.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        public static bool JustPressed(Keys key)
        {
            if (Game1.ksCurrentState.IsKeyDown(key)
                && Game1.ksPreviousState.IsKeyUp(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }




    //
    }
//
}
