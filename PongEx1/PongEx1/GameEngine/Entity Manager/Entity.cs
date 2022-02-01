using Microsoft.Xna.Framework.Graphics;
namespace PongEx1
{
    abstract class Entity : IEntity
    {
        //index number declaration
        public virtual int id { get; set; }

        //store texture for entity
        public abstract void setTexture(Texture2D texture2D);
        //store position of entity
        public abstract void setPosition(float x, float y);

        //pass the spriteBatch
        public abstract void draw(SpriteBatch spriteBatch);
        //initialise entity
        public abstract void Initialise(IMind _entity);
        //Update method
        public abstract void Update(IMind _entityAI);


    }
}
