using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    public interface IBody
    {

        Vector2 GetEntityLocn();

        Texture2D GetTexture();

        void setVelocity(Vector2 _velocity);

        Vector2 GetVelocity();
        float setVelocityX(float _velX);

        float setValocityY(float _velY);

        float setEntitylocnY(float _lcnY);

        float setEntitylocnX(float _lcnX);

        void setEntitylocn(Vector2 entlcn);

    }
}
