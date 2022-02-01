using Microsoft.Xna.Framework;

namespace PongEx1
{
    public interface ICollidable
    {
        Rectangle getHitBox(IBody entity);
        void onCollide(IBody entity1, IBody entity2);
    }
}
