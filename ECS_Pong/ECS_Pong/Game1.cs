using ECS_Pong.GameCode;
using ECS_Pong.GameEngine.Component;
using ECS_Pong.GameEngine.Entity;
using ECS_Pong.GameEngine.Systems;
using ECS_Pong.SceneManager;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ECS_Pong
{
    public class Game1 : Game
    {
        #region Variables
        //DECLARE GraphicsDeviceManager
        private GraphicsDeviceManager _graphics;
        //DECLARE SpriteBatch
        private SpriteBatch _spriteBatch;
        //DECLARE Scene Manager
        private ISceneManager _sceneManager;
        //DECLARE texture system
        private ISystem tex_system;
        //DECLARE position system
        private ISystem pos_system;
        //DECLARE movement system
        private ISystem move_system;
        //DECLARE ball controler system
        private ISystem ball_system;
       //DECLARE paddle input system
        private ISystem paddle_input_system;
        //DECLARE paddle boundries on the map system
        private ISystem paddle_boundries_system;
        //DECLARE collision system - used only in pong game
        private ISystem ball_collision_System;
        //DECLARE List of entities
        private List<Entity> _test_entity_list;
#endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        #region Initialize
        protected override void Initialize()
        {
            
            //INITIALIZE scene manager
            _sceneManager = new SceneManagerClass();

            //Initialize list of entities used for tets
            _test_entity_list = new List<Entity>();

            /*
             * __________Entities used in Pong game_____________
             * 
             *_Ball = new Entity("Ball", 1);
             *_Paddle1 = new Entity("Paddle1", 2);
              _Paddle2 = new Entity("Padddle2", 3);*/

  
            //INITILIZE texture system
            tex_system = new TextureSystem();
            //INITIAZLIZE position syste
            pos_system = new PositionSystem();
            //INITIALIZE movement system
            move_system = new MoveSystem();
            //INITIALIZE ball movement system
            ball_system = new Ball_Movement_System();
            //INITIALIZE paddle input system
            paddle_input_system = new Paddle_Input_System();
            //INITIALIZE paddle boundries system
            paddle_boundries_system = new Paddle_Boundries_System();
            //ADD intilized system to the scene manager
            _sceneManager.AddSystem("texture", tex_system);
            _sceneManager.AddSystem("position", pos_system);
            _sceneManager.AddSystem("move", move_system);
            _sceneManager.AddSystem("ball", ball_system);
            _sceneManager.AddSystem("paddle", paddle_input_system);
            _sceneManager.AddSystem("paddle_boundries", paddle_boundries_system);

            base.Initialize();
        }
        #endregion

        #region Load Content
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            /*For loop that decides how many times spawn the game object
             * used in performing the tests. 
             * Maximum number of loops equals number of entities spawned in the simulation
             */
            
            for (int i = 0; i <= 100000; i++)
            {
               //DECLARE and INTIIALIZE the test entity
                Entity test_ball = new Entity("test_ball" + " " + i, i);

                //ALLOCATE the components used in tests
                test_ball.addComponent("position", new PositionComponent(100 + (i * 10), 100 + (i * 10)));
                test_ball.addComponent("texture", new TextureComponent(Content.Load<Texture2D>("square")));
                test_ball.addComponent("move", new MoveComponent((test_ball.GetComponent("position") as PositionComponent), new Vector2(10, 0)));


                //ADD components to collections inside systems to make entity perform calculation in run time
                ((TextureSystem)tex_system).AddComponents(test_ball.GetComponent("texture") as TextureComponent, test_ball.GetComponent("position") as PositionComponent);
                ((PositionSystem)pos_system).AddComponents(test_ball.GetComponent("position") as PositionComponent);
                ((MoveSystem)move_system).AddComponents(test_ball.GetComponent("position") as PositionComponent, test_ball.GetComponent("move") as MoveComponent);
           

                //ADD entity to the list list
                _test_entity_list.Add(test_ball);
                Console.WriteLine(_test_entity_list.Count);
            }
        
        }
        #endregion

        #region Update
        protected override void Update(GameTime gameTime)
         {
            //INPUT when Esc is clicked exit the software
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //UPDATE the scene manager
            _sceneManager.Update(gameTime);           

            base.Update(gameTime);
        }
        #endregion

        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            //DRAW the scene using Scene Manager
            _sceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion
    }
}
