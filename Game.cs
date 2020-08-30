using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        //Ends the game when true
        private bool _gameOver = false;
        
        //Run the game
        public void Run()
        {
            //Perform initialization tasks
            Start();
            //Loop update routine until the game is over
            while (!_gameOver)
            {
                Update();
            }
            //Perform cleanup tasks
            End();
        }

        //Performed once when the game begins
        public void Start()
        {

        }

        //Repeated until the game ends
        public void Update()
        {

        }

        //Performed once when the game ends
        public void End()
        {

        }
    }
}
