using Microsoft.Xna.Framework;

namespace PongEx1
{

    class PaddleAI : PongAI, ICollidable, IInputListener
    {
        //DECLARE a delegate to pass the update logic to the ball
        public updateDelegate _update = new updateDelegate(Update);

        public static new IBody _body;

        public PaddleAI(IBody entity)
        {
            _body = entity;



        }

        public override IBody ReturnBody()
        {
            return _body;
        }
        /**
         * From now on all the methods will take an argument of type IAIUser entity, to be able to orchestrate the body. 
         **/

        //******************************COLLISION LOGIC**************************//
        public Rectangle getHitBox(IBody entity)
        {
            //RETURN Rectangle that is of the size of the texture, and is positioned on the entity location
            return new Rectangle((int)entity.GetEntityLocn().X, (int)entity.GetEntityLocn().Y, entity.GetTexture().Width, entity.GetTexture().Height);
        }

        //METHOD  takes two ARGUMENTS as for collision we need two entities and their hitboxes
        public void onCollide(IBody entity1, IBody entity2)
        {


        }

        //Set the velocity method, used by input manager to change the position of the body
        public void setVelocity(Vector2 velocity, IBody entity)
        {
            entity.setVelocity(velocity);
        }

        //METHOD paddles update
        public static void Update(IBody _entity)
        {
            //update the paddles position
            _body.setEntitylocnY(_body.GetEntityLocn().Y + _body.setValocityY(_body.GetVelocity().Y * 2));

            //if the paddle reaches the bottom of the screen, stop the Y from decreasing further
            if (_body.GetEntityLocn().Y < 0)
            {

                _body.setEntitylocnY(0);


            }
            //if the paddle reaches the top of the screen, then stop the y from increasing further
            else if (_body.GetEntityLocn().Y >= Kernel.ScreenHeight - 150)
            {

                _body.setEntitylocnY(Kernel.ScreenHeight - 150);
            }

        }
    }
}
