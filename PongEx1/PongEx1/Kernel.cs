using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace PongEx1
{
   
    public class Kernel : Game
    {
        #region Variables
        //DECLARE graphics device manager
        GraphicsDeviceManager graphics;
        //DECLARE sprite batch
        SpriteBatch spriteBatch;
        //DECLARE Screen Size
        public static int ScreenWidth;
        public static int ScreenHeight;
        //DECLARE Scene Manager
        SceneManager sceneManager;
        //DECLARE entity manager
        IEntityManager entityManager;
        //DECLARE Collision Manager
        private ICollisionManager collisionManager;

        /************Pong Demo Variables****************/
        /* private IMind paddle1ComponentManager;
         private IMind paddle2ComponentManager;
         private IMind ballComponentManager;*/
        //DECLARE Entitys
        /*private IEntity ball;
        private IEntity paddle1;
        private IEntity paddle2;*/

        private List<IEntity> _test_entities;
        #endregion

        public Kernel()
        {
            //INITIALIZE Graphic manager
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 900;
            graphics.PreferredBackBufferWidth = 1600;
            Content.RootDirectory = "Content";
        }

        #region Initialize
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //INITIALIZE screen size
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            //INITIALIZE EntityManager
            entityManager = new EntityManager();
            //INITIALIZE Sprite Batch
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //INITIALIZE Scene Manager
            sceneManager = new SceneManager(spriteBatch);
            //INITIALIZE Collision Manager
            collisionManager = new CollisionManager();
            //INITIALIZE list of test entitys
            _test_entities = new List<IEntity>();

            /*************PONG DEMO****************/
            //initialise reference to ball class
            /* ball = entityManager.createBall();
             //initialise reference to paddle class
             paddle1 = entityManager.createPaddle();
             paddle2 = entityManager.createPaddle();

             //INITIALIZE: AI Components 
             paddle1ComponentManager = new PaddleAI(paddle1 as IBody);
             paddle2ComponentManager = new PaddleAI(paddle2 as IBody);
             ballComponentManager = new BallAI(ball as IBody);*/

            //ASSIGN entity minds to entity bodys
            /*((IAssignMind)ball).AssignMind(ballComponentManager);
            ((IAssignMind)paddle1).AssignMind(paddle1ComponentManager);
            ((IAssignMind)paddle2).AssignMind(paddle2ComponentManager);*/

            //SUBSCRIBE: Ai Componenets to the array of collidables
            /*((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)ballComponentManager);
            ((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)paddle1ComponentManager);
            ((ICollisionSubscriber)collisionManager).Subscribe((ICollidable)paddle2ComponentManager);*/

            //SUBSCRIBE: entities to the array of bodies
            /*((ICollisionSubscriber)collisionManager).SubscribeBody(ball as IBody);
            ((ICollisionSubscriber)collisionManager).SubscribeBody(paddle1 as IBody);
            ((ICollisionSubscriber)collisionManager).SubscribeBody(paddle2 as IBody);
            //add entities to list
            sceneManager.addEntity(ball);
            sceneManager.AddMind(ballComponentManager);
            sceneManager.addEntity(paddle1);
            sceneManager.AddMind(paddle1ComponentManager);
            sceneManager.addEntity(paddle2);
            sceneManager.AddMind(paddle2ComponentManager);
            sceneManager.spriteBatch = spriteBatch;


           
            //set starting position of paddle 1
            paddle1.setPosition(0, 0);
            //set starting position of paddle 2
            paddle2.setPosition(1550, 0);


            //INPUT
            _oldState = Keyboard.GetState();

            //serve the ball
            ball.Initialise(ballComponentManager);*/
            /***********END OF PONG DEMO************/

            base.Initialize();

        }
        #endregion

        #region Load Content
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            /********************PONG DEMO**********************/
            //load texture for paddle 1 object
            /*paddle1.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for paddle 2 object
            paddle2.setTexture(Content.Load<Texture2D>("paddle"));
            //load texture for ball object
            ball.setTexture(Content.Load<Texture2D>("square"));*/
            /***************END OF PONG DEMO********************/


            //for loop that controls how many gamne objects to spawn
            for (int i = 0; i <= 1; i++)
            {
                //create new entity mind
                IMind test_ball_mind = entityManager.CreateBallMind(entityManager.createBall(i) as IBody);

                
                //set game object proprties 
                ((IEntity)test_ball_mind.ReturnBody()).setPosition(10 + (i * 10), 10 + (i * 10));
                ((IEntity)test_ball_mind.ReturnBody()).setTexture(Content.Load<Texture2D>("square"));
               

                //add entity to the scene manager
                //_test_entities.Add(test_ball_mind.ReturnBody() as IEntity);
                ((IEntity)test_ball_mind.ReturnBody()).Initialise(test_ball_mind);
                //sceneManager.AddMind(test_ball_mind);
                sceneManager.addEntity(test_ball_mind.ReturnBody() as IEntity, test_ball_mind);

            }
        }
        #endregion

        #region Unload Content
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            base.UnloadContent();
        }
        #endregion

        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            //SET Graphic device color
            GraphicsDevice.Clear(Color.CornflowerBlue);
                     
            spriteBatch.Begin();
            //Draw all entitys in the scene
            sceneManager.Draw();
            spriteBatch.End();
            base.Draw(gameTime);
        }
        #endregion

        #region update
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //IF Esc is pressed leave the game
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //UPDATE scene manager
            sceneManager.Update();
            //ASSIGN screen size
            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;
            //UPDATE collision manager
            collisionManager.Update();
            base.Update(gameTime);
        }
        #endregion
    }
}
