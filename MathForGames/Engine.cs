using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary;

namespace MathForGames
{
    class Engine
    {
        private static bool _shouldApplicationclose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _buffer;

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
            Actor _actor = new Actor('G', new MathLibrary.Vector2 { X = 0, Y = 0 }, "Actor", ConsoleColor.DarkGreen);
            Actor _actor2 = new Actor('A', new MathLibrary.Vector2 { X = 10, Y = 10 }, "Actor2", ConsoleColor.Magenta);
            Player _player = new Player('P', 5, 5, 1, "Player", ConsoleColor.Cyan);
            scene.AddActor(_actor);
            scene.AddActor(_actor2);
            scene.AddActor(_player);
            _currentSceneIndex = AddScene(scene);
            _scenes[_currentSceneIndex].Start();
            Console.CursorVisible = false;
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
            //Clear the stuff that was on the screen in the last frame
            _buffer = new Icon[Console.WindowWidth, Console.WindowHeight-1];

            //Reset the cursor position
            Console.SetCursorPosition(0, 0);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();

            //Iterate through buffer
            for (int y = 0; y < _buffer.GetLength(1); y++)
            {
                for (int x = 0; x < _buffer.GetLength(0); x++)
                {
                    if (_buffer[x, y].Symbol == '\0')
                    {
                        _buffer[x, y].Symbol = ' ';
                    }
                    //Set console color
                    Console.ForegroundColor = _buffer[x, y].color;
                    //Print the symbol of the item in the buffer
                    Console.Write(_buffer[x, y].Symbol);
                }
                //Skip a line once row is complete
                Console.WriteLine();
            }
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


        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetConsoleKey()
        {
            //If there is No Key being pressed...
            if (!Console.KeyAvailable)
            {
                //...Return
                return 0;
            }

            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Addds the icon to the buffer to print to the screen in the next draw call.
        /// prints the icon at the given position in the buffer.
        /// </summary>
        /// <param name="icon"> The icon to draw</param>
        /// <param name="position"> the position of the icon in the buffer</param>
        /// <returns>False if the position is outside the bounds of the buffer</returns>
        public static bool Render(Icon icon, Vector2 position)
        {
            //If the position is out of bounds...
            if (position.X < 0 || position.X >= _buffer.GetLength(0) || position.Y < 0 || position.Y >= _buffer.GetLength(1))
            {
                //...Returns false
                return false;
            }

            //set the buffer at the position index to the icon.
            _buffer[(int)position.X, (int)position.Y] = icon;
            return true;
        }
    }
}
