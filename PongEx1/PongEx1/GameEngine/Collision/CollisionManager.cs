using System.Collections.Generic;
using System.Linq;

namespace PongEx1
{
    class CollisionManager : ICollisionManager, ICollisionSubscriber
    {
        #region Variables
        //DECLARE list of collidables
        private List<ICollidable> EntityList;
        //DECLARE List of entity's body
        private List<IBody> BodyList;
        #endregion

        public CollisionManager()
        {
            EntityList = new List<ICollidable>();
            BodyList = new List<IBody>();
        }

        #region Collision Check
        /*
         * METHOD that is responsible for detecting when collision occur and apply the behavior
         */
        public void CollideCheck()
        {
           //IF a members of the list collide with each other
            for (int i = 0; i < EntityList.Count - 1; i++)
            {
                for (int j = i + 1; j < EntityList.Count; j++)
                {
                    if (EntityList[i].getHitBox(BodyList.ElementAt(i)).Intersects(EntityList[j].getHitBox(BodyList.ElementAt(j) as IBody)))
                    {
                        //APPLY Collision logic
                        EntityList[i].onCollide(BodyList[i], BodyList[j]);
                        EntityList[j].onCollide(BodyList[j], BodyList[i]);
                    }
                }

            }
        }
        #endregion

        #region Subscribe/Unsubscribe body and collidables
        public void Subscribe(ICollidable collidable)
        {
            EntityList.Add(collidable);
        }

        public void SubscribeBody(IBody body)
        {
            BodyList.Add(body);
        }

        public void Unsubscribe(ICollidable collidable)
        {
            EntityList.Remove(collidable);
        }

        public void UnsubscribeBody(IBody body)
        {
            BodyList.Remove(body);
        }
        #endregion

        public void Update()
        {
            CollideCheck();
        }
    }
}
