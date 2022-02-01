namespace PongEx1
{
    interface IEntityManager
    {
        IEntity createBall(int id);
        IEntity createPaddle();
        IMind CreateBallMind(IBody entity);
        void Terminate(IEntity entity, ISceneManager sceneManager);
    }
}
