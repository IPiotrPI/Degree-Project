using System;

namespace PongEx1
{
    class EntityManager : IEntityManager
    {
        //DECLARE scene manager
        ISceneManager sceneManager;

        #region Create entity methods and terminate method

        //Creates a IEntity object with a dynamic type of ball.
        public IEntity createBall(int id)
        {
            IEntity ball = new Ball(id);
            return ball;
        }
       
        //Creates a IEntity object with a dynamic type of paddle.
        public IEntity createPaddle()
        {
            IEntity paddle = new Paddle();
            //give the object a UID
            return paddle;
        }

        //Creates a IMind object with a dynamic type of BallAI
        public IMind CreateBallMind(IBody entity)
        {
            IMind ball = new BallAI(entity);
            return ball;
        }

        //Terminate an entity from the game world
        public void Terminate(IEntity entity, ISceneManager pSceneManager)
        {
            sceneManager = pSceneManager;
            sceneManager.removeEntity(entity);

        }
        #endregion
    }
}
