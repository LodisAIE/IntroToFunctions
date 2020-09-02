using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace HelloWorld
{
    
    class Game
    {
        bool _gameOver = false;
        string _playerName = "";
        
        void RequestName()
        {
            //If player already has a name, return from function
            if(_playerName != "")
            {
                return;
            }
            //Initialize input value
            char input = ' ';
            //Loop until valid input is given
            while (input != '1')
            {
                //Clear previous text
                Console.Clear();
                //Ask user for name
                Console.WriteLine("Please enter your name.");
                _playerName = Console.ReadLine();
                //Display username 
                Console.WriteLine("Hello " + _playerName);
                //Give the user the option to change their name
                input = GetInput("Yes", "No", "Are you sure you want the name " + _playerName + "?");
                if(input == '2')
                {
                    Console.WriteLine("Yeah thats a horrible name. Try again");
                }
            }
        }

        void Explore()
        {
            char input = ' ';
            input = GetInput("Go Left", "Go right", "You came to a cross road");
            if(input == '1')
            {
                Console.WriteLine("You decide to go left and a trap is sprung. " +
                    "You're covered up to your chin in quick sand");
                _gameOver = true;
            }
            else if(input == '2')
            {
                Console.WriteLine("You continue your journey and head towards Portlad");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("Start fight encounter");
            int enemy = 180;
            int playerHealth = 120;
            _gameOver = StartBattle(ref playerHealth, enemy);
        }

        bool StartBattle(ref int playerHealth, int enemyHealth)
        {
            char input = ' ';
            while(playerHealth > 0 && enemyHealth > 0)
            {
                input = GetInput("Attack", "Defend", "What will you do?");
                if(input == '1')
                {
                    enemyHealth -= 10;
                    Console.WriteLine("You did 10 damage to the enemy");
                }
                else if(input == '2')
                {
                    Console.WriteLine("You blocked the enemies attack");
                    Console.ReadKey();
                    continue;
                }
                playerHealth -= 20;
                Console.WriteLine("The enemy did 20 damage to you");
                Console.ReadKey();
            }
            if(playerHealth <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void ViewStats()
        {
            //Prints player stats to screen
            Console.WriteLine(_playerName);
            Console.WriteLine("\nPress any key to continue");
            Console.Write("> ");
            Console.ReadKey();
        }

        char GetInput(string option1, string option2, string query)
        {
            
            //Initialize input value
            char input = ' ';
            //Loop until a valid input is received
            while(input != '1' && input != '2')
            {
                Console.WriteLine(query);
                //Display options
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. View Stats");
                Console.Write("> ");
                //Get input from user
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();
                //If the player input 3, call the view stats function
                if(input == '3')
                {
                    ViewStats();
                }
            }
            //return input received from user
            return input;
        }

        //Run the game
        public void Run()
        {
            Start();
            
            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        //Performed once when the game begins
        //Used for initializing variables 
        //Also used for performing start up tasks that should only be done once 
        public void Start()
        {
            Console.WriteLine("Welcome to my game!!!!!!!!!");
        }

        //Repeated until the game ends
        //Used for all game logic that will repeat
        public void Update()
        {
            RequestName();
            Explore();
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThank you so much for to playing my game!");
        }
    }
}
