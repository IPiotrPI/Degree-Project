using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameCode
{
    class Paddle_Input_System: ISystem
    {
        //DECLARE private dictionary of components with int as the player's number and value as characters movement component
        private Dictionary<int, MoveComponent> _components;

        public Paddle_Input_System()
        {
            _components = new Dictionary<int, MoveComponent>();
        }

        #region Add/Ramove player
        public void AddPlayer(int playerIndex, MoveComponent move)
        {   
            _components.Add(playerIndex, move);
            
        }

        public void RemovePlayer(int playerIndex)
        {
            _components.Remove(playerIndex);
        }
        #endregion

        #region Keyboard Input behavior
        /*
         * METHOD that assigns player to prepared set of input. 
         * Used in pong game for first and second player input.
         */
        public void GetKeyboardInputDirection()
        {
            //DECLARE keyboard state to allow input
            KeyboardState keyboardState = Keyboard.GetState();
            
            //FOR EAHCH key value pair in private dictionary
            foreach (var item in _components)
            {
                //IF movement component belongs to first player
                if (item.Key == 1)
                {
                    //IF the w key is pressed
                    if (keyboardState.IsKeyDown(Keys.W))
                    {
                     //move paddle upwards
                        item.Value.SetVelocityY(-10);                

                    }
                   
                    //IF the s key is pressed
                    else if (keyboardState.IsKeyDown(Keys.S))
                    {

                        //move paddle downwards
                        item.Value.SetVelocityY(10);

                    }
                    else
                    {
                        //do not change the velocity
                        item.Value.SetVelocityY(0);
                    }                  

                }
                //IF movement component belongs to second player
                if (item.Key == 2)
                {
                    //if the Up key is pressed
                    if (keyboardState.IsKeyDown(Keys.Up))
                    {
                        //move paddle upwards
                        item.Value.SetVelocityY(-10);                   
                    }
                    
                    //if the Down key is pressed
                    else if (keyboardState.IsKeyDown(Keys.Down))
                    {
                        //move paddle downwards
                        item.Value.SetVelocityY(10);                
                    }
                    else
                    {
                        item.Value.SetVelocityY(0);
                    }

                }

            }
        }
        #endregion


    }
}
