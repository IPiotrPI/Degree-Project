using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Component
{
    class MoveComponent: IComponent
    {
        #region Variables
        //DECLARE Vector2 as current position
        private Vector2 _currentPosition;
        //DECLARE Vector2 as velocity to change the position
        private Vector2 _velocity;
        #endregion

        public MoveComponent(PositionComponent position, Vector2 velocity)
        {
            _currentPosition = position.GetPosition();
            _velocity = velocity;
        }

        #region Set/Get Valocity ; Velocity.X ; Velocity.Y
        public void SetVelocity(Vector2 velocity)
        {
            _velocity = velocity;
        }

        public Vector2 GetVelocity()
        {
            return _velocity;
        }
      

        public void SetVelocityX(float X)
        {
            _velocity.X = X;
        }

        public void SetVelocityY(float Y)
        {
            _velocity.Y = Y;
        }

        public float GetVelocityX()
        {
            return _velocity.X;
        }

        public float GetVelocityY()
        {
            return _velocity.Y;
        }
        #endregion

        #region Move in all directions

        //METHOD that moves entity using vectors
        public Vector2 Move()
        {
            return _currentPosition += _velocity;
        }

        //METHODS that changes position using parts of given vectors
        public float MoveRight()
        {
            return _currentPosition.X += _velocity.X;
        }

        public float MoveLeft()
        {
            return _currentPosition.X -= _velocity.X;
        }

        public float MoveUp()
        {
            return _currentPosition.Y += _velocity.Y;
        }

        public float MoveDown()
        {
            return _currentPosition.Y -= _velocity.Y;
        }
        #endregion
    }
}
