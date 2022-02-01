using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    public interface IEntity
    {
        //UID property
        int id { get; set; }
        void setTexture(Texture2D texture2D);
        void setPosition(float x, float y);
        void Initialise(IMind _entity);
        void draw(SpriteBatch spriteBatch);
        void Update(IMind _entityAI);
    }
}
