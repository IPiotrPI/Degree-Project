using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ECS_Pong.GameEngine.Component
{
    class HitBoxComponent : IComponent
    {
        #region Variables
        //DECLARE position components
        private PositionComponent pos;
        //DECLARE texture component
        private TextureComponent tex;
        #endregion

        public HitBoxComponent(PositionComponent _pos, TextureComponent _tex)
        {
            pos = _pos;
            tex = _tex;
        }

        #region Get HitBox Component
        /*
         * METHOD responsible for creating the hitbox
         * hitbox is created as a rectangle in the position of component, and in size of texture
         */
        public Rectangle GetHitbox()
        {
            Rectangle hitbox = new Rectangle((int)pos.GetPositionX(), (int)pos.GetPositionY(), tex.GetTexture().Width, tex.GetTexture().Height);
            return hitbox;
        }
        #endregion
    }
}
