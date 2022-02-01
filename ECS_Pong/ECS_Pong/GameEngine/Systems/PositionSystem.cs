using ECS_Pong.GameEngine.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Systems
{
    class PositionSystem : ISystem
    {
        //DECLARE list of position components
        private List<PositionComponent> _component;

        public PositionSystem()
        {
            _component = new List<PositionComponent>();
        }

        #region Add/Remove Component
        public void AddComponents(PositionComponent position)
        {
            _component.Add(position);
        }

        public void RemoveComponent(PositionComponent position)
        {
            _component.Remove(position);
        }
        #endregion

        #region Update Position
        /*
         * METHOD responsible for updating the position using given Vector2
         */
        public void UpdatePosition(Vector2 new_position)
        {
            //FOR EACH position component in private list
            foreach (var item in _component)
            {
                //Change position of entity to the given vector
                item.SetPosition(new_position);
            }
        }
        #endregion
    }
}
