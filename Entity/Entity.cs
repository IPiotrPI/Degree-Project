using System;
using System.Collections.Generic;
using ECS_Pong.GameEngine.Component;

namespace ECS_Pong.GameEngine.Entity
{
    class Entity : IEntity
    {
        #region Variables
        //DECLARE name for the entity
        private string _name;
        //DECLARE entitys indentification number
        private int _id;

        //DECLARE dictionary of components
        private Dictionary<string, IComponent> _components;
        #endregion

        public Entity(string name, int id)
        {
            //INITIALIZE variables
            _name = name;
            _id = id;
            _components = new Dictionary<string, IComponent>();
        }

        #region Add/Remove Components
        public void addComponent(string name, IComponent newComponent)
        {
            _components.Add(name, newComponent);
        }

        public void RemoveComponent(string name)
        {
            _components.Remove(name);
        }
        #endregion

        #region Get component

        //METHOD that returns component by searching through entitys private dictionary
        //Used to determin entitys behavior
        public IComponent GetComponent(string name)
        {
            //IF entity contains the desired component
            if(_components.ContainsKey(name) != false)
            {
                //RETURN requested component
                return _components[name];
            }
            else
            {
                //IF there is no such component display error component
                Console.WriteLine("There is no such component");
                return null;
            }
            
        }
        #endregion

        //METHOD returns dictionary of components
        public Dictionary<string, IComponent> GetComponents()
        {
            return _components;
        }
       
    }
}
