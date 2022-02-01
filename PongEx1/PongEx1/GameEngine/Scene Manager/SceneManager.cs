using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace PongEx1
{
    class SceneManager : ISceneManager
    {
        #region Variables
        //DECLARE dictionary of key value pair that consist of entity body and mind
        public Dictionary<IEntity, IMind> EntityList;
        //DECLARE sprite batch
        public SpriteBatch spriteBatch;
        #endregion

        public SceneManager(SpriteBatch sprite)
        {
            EntityList = new Dictionary<IEntity, IMind>();
            spriteBatch = sprite;
        }

        #region Add/Remove Entity
        public void addEntity(IEntity entity, IMind mind)
        {   //add entities to List
            EntityList.Add(entity, mind);

        }

        public void removeEntity(IEntity entity)
        {   //add entities to List
            EntityList.Remove(entity);

        }
        #endregion

        #region Draw
        public void Draw()
        {
            foreach (KeyValuePair<IEntity, IMind> entity in EntityList)
            {
                entity.Key.draw(spriteBatch);
            }
        }
        #endregion

        #region Update
        public void Update()
        {
            foreach (KeyValuePair<IEntity, IMind> entity in EntityList)
            {
                entity.Key.Update(entity.Value);
            }

        }
        #endregion
    }
}
