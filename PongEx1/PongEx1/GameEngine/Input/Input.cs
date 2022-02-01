using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace PongEx1
{
    class Input
    {
        #region Variables
        //DECLARE static vector2 for storing the direction the paddle is moving, name is direction
        private static Vector2 direction;
        //DECLARE accleration 1
        public static double acc1 = 0.04;
        //DECLARE acceleration 2
        public static double acc2 = 0.04;
        //DECLARE max speed
        private static double maxSpeed = 5;
        #endregion

        #region Get Input Direction
        /*
         * METHOD that is responsible for movement behavior responding to input
         */
        public static Vector2 GetKeyboardInputDirection(PlayerIndex pPlayerIndex)
        {
            direction.Y = 0;
            KeyboardState keyboardState = Keyboard.GetState(pPlayerIndex);
            //if player one interacts with the keyboard
            if (pPlayerIndex == PlayerIndex.One)
            {
                //if the w key is pressed
                if (keyboardState.IsKeyDown(Keys.W))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc1 >= maxSpeed)
                    {
                        acc1 = maxSpeed;
                    }
                    acc1++;
                    //move paddle upwards
                    direction.Y -= (int)acc1;

                }
                //if the s key is pressed
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc1 >= maxSpeed)
                    {
                        acc1 = maxSpeed;
                    }
                    acc1++;
                    //move paddle downwards
                    direction.Y += (int)acc1;

                }
            }

            //if player one interacts with the keyboard
            if (pPlayerIndex == PlayerIndex.Two)
            {
                //if the Up key is pressed
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc2 >= maxSpeed)
                    {
                        acc2 = maxSpeed;
                    }
                    acc2++;
                    //move paddle upwards
                    direction.Y -= (int)acc2;

                }
                //if the Down key is pressed
                else if (keyboardState.IsKeyDown(Keys.Down))
                {
                    //if the acceleration has reached its max speed, then top it from increasing further
                    if (acc2 >= maxSpeed)
                    {
                        acc2 = maxSpeed;
                    }
                    acc2++;
                    //move paddle downwards
                    direction.Y += (int)acc2;

                }
            }

            return direction;
        }
        #endregion
    }
}
