using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{

    abstract class PongEntity : Entity
    {
        #region Variables
        //DECLARE vector2 used to store the location of each 2d entity, call it entityLocn
        public Vector2 entityLocn;
        //DECLARE Texture2D used to store the texture of each 2d entity, call it texture
        protected Texture2D texture;
        //DECLARE double used to make the ball movement more realistic, by giving it spin, call it Spin
        public float Spin = 5.5f;
        //DECLARE Vector2 used to change the velocity of entities, call it velocity
        public Vector2 velocity;
        //DECLARE entity's index number
        public override int id { get; set; }
        #endregion

        public PongEntity()
        {

        }

        #region Getters and Setters
        public override void setPosition(float x, float y)
        {
            entityLocn.X = x;
            entityLocn.Y = y;
        }

        ////DECLARE Vector2 for dealing with speed and direction of ball, name it velocity
        public abstract void setVelocity(Vector2 pVelocity);
   
        public override void setTexture(Texture2D pTexture)
        {
            texture = pTexture;
        }
        #endregion

        #region draw
        public override void draw(SpriteBatch pSpriteBatch)
        {
            //draw the entity using the spritebatch
            pSpriteBatch.Draw(texture, entityLocn, Color.AntiqueWhite);

        }
        #endregion

        public override void Update(IMind _entityAI)
        {

        }
    }




}
