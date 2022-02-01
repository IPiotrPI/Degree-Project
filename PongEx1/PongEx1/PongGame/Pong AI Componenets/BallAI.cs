using Microsoft.Xna.Framework;
using System;


namespace PongEx1
{

    class BallAI : PongAI, ICollidable
    {
        #region Variables
        //DECLARE static Body
        public static IBody _body;
        //DECLARE Serve delegate
        public delegate void ServeDelegate();

        //INITIALIZE Delegates to pass update and serve logic
        public updateDelegate _update = new updateDelegate(update);
        public ServeDelegate _serve = new ServeDelegate(Serve);
        #endregion

        public BallAI(IBody _entity)
        {
            _body = _entity;

        }

        #region Serve
        /*
         * METHOS used to intiialize and restart the balls behavior
         */
        public static void Serve()
        {
            //DECLARE speed and random number generator
            int speed = 10;
            //DECLARE random number generator to determin ball's direction
            Random random = new Random();

            //place ball in the centre of the screen
            ((IEntity)_body).setPosition(Kernel.ScreenWidth / 2, Kernel.ScreenHeight / 2);
            //CALCULATE ball's movement
            float rotation = (float)(Math.PI / 2 + (random.NextDouble() * (Math.PI / 5.0f) - Math.PI / 3));
            _body.setVelocityX((float)Math.Sin(rotation));
            _body.setValocityY((float)Math.Cos(rotation));
            int rnd = random.Next(1, 3);
            //face the ball in a random direction
            if (rnd == 2)
            {
                _body.setVelocityX(_body.GetVelocity().X * -1);
            }

            ///Push the ball
            _body.setVelocityX(_body.GetVelocity().X +  speed);
        }
        #endregion


        public override IBody ReturnBody()
        {
            return _body;
        }


        #region Collision

        public Rectangle getHitBox(IBody entity)
        {
            //RETURN Rectangle that is of the size of the texture, and is positioned on the entity location
            return new Rectangle((int)entity.GetEntityLocn().X, (int)entity.GetEntityLocn().Y, entity.GetTexture().Width, entity.GetTexture().Height);
        }

        //METHOD  takes two ARGUMENTS as for collision we need two entities and their hitboxes
        public void onCollide(IBody entity1, IBody entity2)
        {
            if ((Entity)entity2 is Paddle)
            {
                //logic to bouce the ball off the paddle
                ReturnBody().setVelocityX((ReturnBody().GetVelocity().X + entity2.GetVelocity().X) / 2);
                ReturnBody().setValocityY((ReturnBody().GetVelocity().Y + entity2.GetVelocity().Y) / 2);
                ReturnBody().setVelocity(ReturnBody().GetVelocity() * -1);
                Console.WriteLine("BallColided");
            }

        }
        #endregion

        public static void update(IBody _entity)
        {
           
        }
    }
}
