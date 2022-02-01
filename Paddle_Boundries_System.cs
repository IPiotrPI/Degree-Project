using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameCode
{
    class Paddle_Boundries_System: ISystem
    {
        #region List
        //DECLARE the list of position components
        private List<PositionComponent> components;
        #endregion

        public Paddle_Boundries_System()
        {
            //INTIALIZE list of position components
            components = new List<PositionComponent>();
        }

        #region Add / Remove
        //METHOD add component to hte list
        public void AddComponent(PositionComponent pos)
        {
            components.Add(pos);
        }

        //METHOD remove component from list
        public void RemoveComponent(PositionComponent pos)
        {
            components.Remove(pos);
        }
        #endregion

        #region Behavioral logic
        public void CheckWallCollision()
        {
            //BEGIN LOOP to iterate through the list of components
            foreach (var item in components)
            {
                //IF position of the paddle reaches top of the scene
                if(item.GetPositionY() <= 0)
                {
                    //LOCK paddle before the boundry
                    item.SetPositionY(0);
                }
                //IF position of the paddle reaches bottom of the scene
                else if (item.GetPositionY() >= 340)
                {
                    //LOCK paddle before the boundry
                    item.SetPositionY(340);
                }
            }
        }
        #endregion
    }
}
