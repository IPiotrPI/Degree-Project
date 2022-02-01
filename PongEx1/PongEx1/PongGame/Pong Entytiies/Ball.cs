using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PongEx1
{
    class Ball : PongEntity, IBody
    {
        public Ball(int ids)
        {
            id = ids;

        }

        #region Initialize
        public override void Initialise(IMind _entityAI)
        {
            //To initilize the body use the serve delegate
            ((BallAI)_entityAI)._serve.Invoke();
        
        }
        #endregion

        #region Check Wall Collosion
        public void CheckWallCollision(IMind _entityAI)
        {
            //IF entity reach left wall
            if (GetEntityLocn().X <= 0)
            {
                //REINITIALIZE
                ((BallAI)_entityAI)._serve.Invoke();
            }
            //IF Entity reach right wall
            if (GetEntityLocn().X >= 1500)
            {
                //REINITIALIZE
                ((BallAI)_entityAI)._serve.Invoke();
            }
            //IF entity reach up wall
            if (GetEntityLocn().Y <= 0)
            {
                //Bounce ball back to the centre of the screen
                setValocityY(GetVelocity().Y * -1);
            }
            //IF entity reach down wall
            if (GetEntityLocn().Y >= 900)
            {
                //Bounce ball back to the centre of the screen
                setValocityY(GetVelocity().Y * -1);
            }
        }
        #endregion

        #region Getters and Setters
        public Vector2 GetEntityLocn()
        {
            return entityLocn;
        }

        public Texture2D GetTexture()
        {
            return texture;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }

        public override void setVelocity(Vector2 _velocity)
        {
            velocity = _velocity;
        }

        public float setVelocityX(float velx)
        {
            velocity.X = velx;
            return velocity.X;
        }

        public float setValocityY(float _velY)
        {
            velocity.Y = _velY;
            return velocity.X;
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
        public override void Update(IMind _entityAI)
        {
            //check wall collision in run time to allow the balls behavior
            CheckWallCollision(_entityAI);
            //use invoke to update rest of the balls behaviors
            ((BallAI)_entityAI)._update.Invoke(this);
            //UPDATE location of the ball using velocity
            setEntitylocn(GetEntityLocn() + GetVelocity());
        }
        #endregion
    }
}
