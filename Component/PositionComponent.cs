using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Component
{
    class PositionComponent : IComponent
    {
        //DECLARE Vector2 position to store the value of entity coordinates on the screen
        private Vector2 _position;

        public PositionComponent(float X, float Y)
        {
            _position.X = X;
            _position.Y = Y;
        }

        #region Setters and Getters

        /*
         * METHODS that allows to get and set the vector 2 position, and its X and Y values
         */
        public void SetPosition(Vector2 position)
        {
            _position = position;
        }

        public Vector2 GetPosition()
        {
            return _position;
        }

        public void SetPositionX(float X)
        {
            _position.X = X;
        }

        public void SetPositionY(float Y)
        {
            _position.Y = Y;
        }

        public float GetPositionX()
        {
            return _position.X;
        }

        public float GetPositionY()
        {
            return _position.Y;
        }
        #endregion
    }
}
