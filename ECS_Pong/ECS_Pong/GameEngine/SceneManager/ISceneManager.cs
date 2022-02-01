using ECS_Pong.GameEngine.Entity;
using ECS_Pong.GameEngine.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.SceneManager
{
    interface ISceneManager
    {
        void Draw(SpriteBatch spriteBatch);
        void AddSystem(string name, ISystem system);
        void RemoveSystem(string name);
        void Update(GameTime gametime);
    }
}
