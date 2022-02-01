using ECS_Pong.GameEngine.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Systems
{
    class MoveSystem: ISystem
    {
        //DECLARE Dictionary of components updated by the system
        private Dictionary<PositionComponent, MoveComponent> _components;

        public MoveSystem()
        {
            _components = new Dictionary<PositionComponent, MoveComponent>();
        }

        #region Add/Remove Components
        public void AddComponents(PositionComponent position, MoveComponent move)
        {
            _components.Add(position, move);
        }

        public void RemoveComponent(PositionComponent position)
        {
            _components.Remove(position);
        }
        #endregion

        #region update
        public void update(GameTime gametime)
        {
            //FOR EACH key value pair in dictionary
            foreach (var item in _components)
            {
                //CHANGE the position of entity using its current location, and velocity value
                item.Key.SetPosition(item.Key.GetPosition() + item.Value.GetVelocity());
                
            }
        }
        #endregion
    }
}
