using Microsoft.Xna.Framework;

namespace PongEx1
{
    interface IInputListener
    {
        void setVelocity(Vector2 velocity, IBody entity);
    }
}
