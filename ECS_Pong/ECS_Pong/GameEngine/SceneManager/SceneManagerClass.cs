using ECS_Pong.GameCode;
using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Entity;
using ECS_Pong.GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.SceneManager
{
    class SceneManagerClass : ISceneManager
    {
        #region Dictionary
        //DECLARE Dictionary of systems as key value pair of string as name and desired system using ISystem interface
        public Dictionary<string, ISystem> SystemDictionary;
        #endregion

        public SceneManagerClass()
        {
            SystemDictionary = new Dictionary<string, ISystem>();
        }

        #region Add/Remove
        //METHOD add System to the dictionary
        public void AddSystem(string name, ISystem system)
        {        
            SystemDictionary.Add(name, system);
        }

        //METHOD remove System from dictionary
        public void RemoveSystem(string name)
        {
            SystemDictionary.Remove(name);
        }
        #endregion

        #region Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            //IF Dictionary contains texture system
            if (SystemDictionary.ContainsKey("texture") == true)
            {
                //DRAW game objects using texture system
                ((TextureSystem)SystemDictionary["texture"]).Draw(spriteBatch);
            }
            else
            {
                //IF there is no texture system in the dictionary, write a messange to the console
                Console.WriteLine("Can not draw as texture System has not been added");
            }

        }
        #endregion

        #region Update
        public void Update(GameTime gametime)
        {
            //UPDATE the position of game object using movement position
            ((MoveSystem)SystemDictionary["move"]).update(gametime);
            //APPLY collision behavior between the ball and the boundires of the map         
            ((Ball_Movement_System)SystemDictionary["ball"]).ChackWallCollision();
            //APPLY Imput behavior on paddles, used in Pond Demo
            //((Paddle_Input_System)SystemDictionary["paddle"]).GetKeyboardInputDirection();

            //APPLY paddle boundries behavior, used in Pong Demo 
            //((Paddle_Boundries_System)SystemDictionary["paddle_boundries"]).CheckWallCollision();
          
        }
        #endregion
    }
}
