using System;
using System.Collections.Generic;
using ECS_Pong.GameEngine.Component;
using System.Text;

namespace ECS_Pong.GameEngine.Entity
{
    interface IEntity
    {
        void addComponent(string name, IComponent newComponent);
        void RemoveComponent(string name);
        IComponent GetComponent(string name);
        Dictionary<string, IComponent> GetComponents();


    }
}
