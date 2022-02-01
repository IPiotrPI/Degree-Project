namespace PongEx1
{
    /*
     * Mind class is a abstract construct that is used as the parent 
     * from which all mind classes inherit the methods
     */
    abstract class Mind : IMind
    {

        public abstract void onCollide(IBody _entity);

        public delegate void updateDelegate(IBody _entity);

        public abstract IBody ReturnBody();

        public abstract void update();

    }
}
