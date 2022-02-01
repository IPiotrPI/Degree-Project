namespace PongEx1
{
    public interface IMind
    {
        IBody ReturnBody();
        void onCollide(IBody entity);

        void update();
    }
}
