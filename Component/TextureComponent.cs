using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECS_Pong.GameEngine.Component
{
    class TextureComponent : IComponent
    {
        #region Variables
        //DECLARE texture
        private Texture2D _texture;
        //DECLARE color of the texture. White as default
        private Color _color;
        #endregion

        public TextureComponent(Texture2D texture)
        {
            _texture = texture;

            _color = Color.White;
        }

        #region Set/Get Texture
        public void SetTexture(Texture2D texture)
        {
            _texture = texture;
        }

        public Texture2D GetTexture()
        {
            return _texture;
        }
        #endregion

        #region Set/Get Color
        public Color GetColor()
        {
            return _color;
        }

        public void SetColor(Color color)
        {
            _color = color;
        }
        #endregion
    }
}
