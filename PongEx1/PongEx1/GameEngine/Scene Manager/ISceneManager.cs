namespace PongEx1
{
    public interface ISceneManager
    {
        void Draw();
        void addEntity(IEntity entity, IMind mind);
        void removeEntity(IEntity entity);
        void Update();
    }
}
