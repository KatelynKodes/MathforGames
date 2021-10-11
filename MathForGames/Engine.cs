using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace MathForGames
{
    class Engine
    {
        private static bool _shouldApplicationclose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            //Loop until application is told to close
            while (!_shouldApplicationclose)
            {
                Update();
                Draw();
                Thread.Sleep(150);
            }

            //Calll at the end of the entire application.
            End();
        }

        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            Scene scene = new Scene();
            Actor _actor = new Actor('P', new MathLibrary.Vector2 { X = 0, Y = 0 });
            scene.AddActor(_actor);
            _currentSceneIndex = AddScene(scene);
            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();

        }

        /// <summary>
        /// Called At the end of the application
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();

        }

        /// <summary>
        /// Called everytime the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();
        }

        /// <summary>
        /// Adds a new scene to the engines scene array
        /// </summary>
        /// <param name="scene"></param>
        /// <returns></returns>
        public int AddScene(Scene scene)
        {
            //Create Temporary Array
            Scene[] TempArray = new Scene[_scenes.Length + 1];

            //Copy all values into temporary array
            for (int i = 0; i < _scenes.Length; i++)
            {
                TempArray[i] = _scenes[i];
            }

            //Set the last index to be the new scene
            TempArray[_scenes.Length] = scene;

            //set the old array to the new array
            _scenes = TempArray;

            //Return the last index
            return _scenes.Length - 1;
        }
    }
}
