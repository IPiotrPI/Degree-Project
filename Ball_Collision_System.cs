using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Systems;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace ECS_Pong.GameCode
{
    class Ball_Collision_System: ISystem
    {
        #region Variables
        //DECLARE list of hitbox components
        private List<HitBoxComponent> components;
        //DECLARE Movement compoonent that will be affected by behavior
        private MoveComponent move;
        #endregion

        public Ball_Collision_System(MoveComponent _move)
        {
            components = new List<HitBoxComponent>();
            move = _move;
        }

        #region Add/Remove Components
        public void addComponents(HitBoxComponent hitbox)
        {
            components.Add(hitbox);
        }

        public void RemoveComponent(HitBoxComponent hitbox)
        {
            components.Remove(hitbox);
        }
        #endregion

        #region Collision behavior
        public void Collision()
        {
            //FOR EACH hitbox component in the list
            for (int i = 0; i < components.Count; i++)
            {
             //IF hitbox interesct with each other
              if (components[i].GetHitbox().IntersectsWith(components[i].GetHitbox()))
              {
                //CHANGE Velocity on axis X to opposite
                move.SetVelocityX(move.GetVelocityX() * -1);
              }
               
            }
        }
        #endregion
    }
}
