using ECS_Pong.GameEngine.Component;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Systems
{
    class TextureSystem: ISystem
    {
        //DECLARE Dictionary of components
        private Dictionary<TextureComponent, PositionComponent> components;

        public TextureSystem()
        {
            components = new Dictionary<TextureComponent, PositionComponent>();
        }

        #region Add/Remove Components
        public void AddComponents(TextureComponent _tex, PositionComponent _pos)
        {
            if (!components.ContainsKey(_tex))
            {
                components.Add(_tex, _pos);
            }
            else
            {
                Console.WriteLine("Component already exist");
            }
            
        }

        public void RemoveComponent(TextureComponent _tex)
        {
            components.Remove(_tex);
        }
        #endregion

        #region Draw
        /*
         * METHOD that draws the entity textures in the scene 
         */

        public void Draw(SpriteBatch spriteBatch)
        {
            //FOR EACH key value pair of components in dictionary
            foreach (var item in components)
            {
                //Draw entity's texture on its location
                spriteBatch.Draw(item.Key.GetTexture(), item.Value.GetPosition(), item.Key.GetColor());
            }
        }
        #endregion
    }
}
