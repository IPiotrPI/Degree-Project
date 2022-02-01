using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameCode
{
    class Ball_Movement_System : ISystem
    {
        //DECLARE dictionary of components
        private Dictionary<PositionComponent, MoveComponent> components;

        public Ball_Movement_System()
        {
            components = new Dictionary<PositionComponent, MoveComponent>();
        }

        #region Add/Remove Component
        public void AddComponents(PositionComponent pos, MoveComponent move)
        {
            components.Add(pos, move);
        }

        public void RemoveComponent(PositionComponent pos)
        {
            components.Remove(pos);
        }
        #endregion

        #region Serve
        /*
         * METHOD used to initialize the ball, and reset the game in Pong Demo
         */
        private void Serve()
        {
            //DECLARE: speed and random number generator
            int speed = 10;
            Random random = new Random();

            //place ball in the centre of the screen
            foreach (var item in components)
            {
                item.Value.SetVelocityX(10);
                item.Key.SetPosition(new Microsoft.Xna.Framework.Vector2(375f, 240f));
                //((IEntity)_body).setPosition(Kernel.ScreenWidth / 2, Kernel.ScreenHeight / 2);
                float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
                item.Value.SetVelocityX((float)Math.Sin(rotation));
                item.Value.SetVelocityY((float)Math.Cos(rotation));
                int rnd = random.Next(1, 3);
                //face the ball in a random direction
                if (rnd == 2)
                {
                    item.Value.SetVelocityX(item.Value.GetVelocity().X * -1);
                }

                ///Push the ball
                item.Value.SetVelocityX(item.Value.GetVelocity().X * speed);
            }
            
        }
        #endregion

        #region Check wall collision
        /*
         * MTHOD that checks when ball collides with the boundries of the game eg. walls
         */
        public void ChackWallCollision()
        {
            //FOR EACH keay value pair in dictionary of components
            foreach (var item in components)
            {
                //IF ball crosses the boundry on the left
                if (item.Key.GetPositionX() <= 0)
                {
                    //re intialize
                    Serve();
                }
                //IF ball crosses the boundry on the right
                else if (item.Key.GetPositionX() >= 750)
                {
                    //re intialize
                    Serve();
                }
                //IF ball crosses the boundry above
                else if (item.Key.GetPositionY() <= 0)
                {
                    //cahnge the direction of the ball to the opposite on Y axis
                    item.Value.SetVelocityY(item.Value.GetVelocityY() * -1);
                }
                //IF ball crosses the boundry below
                else if (item.Key.GetPositionY() >= 430)
                {
                    //cahnge the direction of the ball to the opposite on Y axis
                    item.Value.SetVelocityY(item.Value.GetVelocityY() * -1);
                }

            }
        }
        #endregion
    }
}
