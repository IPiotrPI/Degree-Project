using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class Paddle : PongEntity, IBody
    {


        //initialise the paddle
        public override void Initialise(IMind _entity)
        {

        }

        #region Getters and Setters
        public Vector2 GetEntityLocn()
        {
            return this.entityLocn;
        }

        public Texture2D GetTexture()
        {
            return this.texture;
        }

        public Vector2 GetVelocity()
        {
            return this.velocity;
        }
        public override void setVelocity(Vector2 velocity)
        {
            this.velocity = velocity;
        }

        public float setVelocityX(float _velX)
        {
            this.velocity.X = _velX;
            return this.velocity.X;
        }

        public float setValocityY(float _velY)
        {
            this.velocity.Y = _velY;
            return this.velocity.Y;
        }

        public void setEntitylocn(Vector2 entlcn)
        {
            entityLocn = entlcn;
        }

        public float setEntitylocnX(float _lcnX)
        {
            this.entityLocn.X = _lcnX;
            return this.entityLocn.X;
        }

        public float setEntitylocnY(float _lcnY)
        {
            this.entityLocn.Y = _lcnY;
            return this.entityLocn.Y;
        }
        #endregion


        #region Update
        //paddle update method
        public override void Update(IMind _entityAI)
        {
            //Update the delegate of the mind to change paddles behaviour
            ((PaddleAI)_entityAI)._update.Invoke(this);

        }
        #endregion

    }
}
