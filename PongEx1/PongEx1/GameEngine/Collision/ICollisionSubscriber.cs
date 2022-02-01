namespace PongEx1
{
    interface ICollisionSubscriber
    {
        void Subscribe(ICollidable collidable);
        void Unsubscribe(ICollidable collidable);

        void SubscribeBody(IBody body);
        void UnsubscribeBody(IBody body);
    }
}
