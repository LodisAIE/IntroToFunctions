using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace HelloWorld
{

    class Game
    {
        bool _gameOver = false;
        string _playerName = "the player";
        int playerHealth = 100;
        //Type  Name       Argument/Parameter list
        void RequestName(ref string name)
        //body   
        {
            //Initialize input value
            char input = ' ';
            //Loop until valid input is given
            while (input != '1')
            {
                //Ask user for name
                Console.WriteLine("Please enter a new name for " + name);
                name = Console.ReadLine();
                //Give the user the option to change their name
                input = GetInput("Yes", "No", "Are you sure you want the name " + name + "?");
                if (input == '2')
                {
                    Console.WriteLine("Yeah thats a horrible name. Try again");
                }
            }
        }

        void Explore()
        {
            string petName = "the flying pitbull dragon thing";
            string enemyName = "jeff";
            char input = ' ';
            input = GetInput("Go Left", "Go right", "You came to a cross road");
            if (input == '1')
            {
                Console.WriteLine("A group of bandits appear! It's an ambush, and they wanna take all yo money" +
                    "Then a " + petName + "out, and shoots fire! All the bandits are dead. Except for one. He's just in pain." +
                    "It seems like the flying pitbull dragon thing wants to join you on your journey. What should you name it?");
                RequestName(ref enemyName);
                Console.WriteLine("New name is " + petName);
                Console.ReadKey();
            }
            else if (input == '2')
            {
                Console.WriteLine("You continue your journey and head towards Portland");
                Console.ReadKey();
            }
            Console.Clear();
            Console.WriteLine("The last bandit rushes towards you in rage! 'You killed my wife and kids!' He screams.");

            int enemyHealth = 75;
            _gameOver = StartBattle(ref playerHealth);
        }

        void EnterRoom(int roomNumber)
        {
            string exitMessage = "";
            switch (roomNumber)
            {
                case 0:
                    {
                        exitMessage = "You depart from Castle Grayskull";
                        Console.WriteLine("Before you stands the entrance to Castle Grayskull");
                        Console.WriteLine("A monster appears to block your path");
                        StartBattle(ref playerHealth);
                        break;
                    }
                case 1:
                case 2:
                    {
                        exitMessage = "You leave the kitchen";
                        Console.WriteLine("You enter the castle's kitchen. There's knives on the ground, rats everywhere, and moldy chicken");
                        break;
                    }

                default:
                    {
                        exitMessage = "You left the hallway";
                        Console.WriteLine("You enter a seemingly never ending hallway");
                        break;
                    }
            }
            Console.WriteLine("You are in room " + roomNumber);
            char input = ' ';
            input = GetInput("Go forward", "Go back", "Which direction would you like to go?");
            if(input == '1')
            {
                EnterRoom(roomNumber+1);
            }

            Console.WriteLine(exitMessage);
        }

        bool StartBattle(ref int character1Health, int character2Health = 100)
        {
            //initialize the input variable
            char input = ' ';
            //Create battle loop. Loops until the player or enemy is dead
            while (character1Health > 0 && character2Health > 0)
            {
                Console.WriteLine("Character 1 Health: " + character1Health);
                Console.WriteLine("Character 2 Health: " + character2Health);
                //Get input from player
                input = GetInput("Attack", "Defend", "What will you do?");
                //If input is 1 then the player attacks the enemy
                if (input == '1')
                {
                    character2Health -= 10;
                    Console.WriteLine("You attacked and did 10 damage");
                }
                //if input is 2 then the player blocked the enemy's attack
                else if (input == '2')
                {
                    Console.WriteLine("You blocked the enemy's attack!");
                    Console.ReadKey();
                    continue;
                }
                character1Health -= 20;
                Console.WriteLine("The enemy attacked and did 20 damage!");
                Console.ReadKey();
            }
            return character1Health <= 0;
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
            while (input != '1' && input != '2')
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
                if (input == '3')
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

            while (_gameOver == false)
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
            //RequestName(ref _playerName);
            EnterRoom(0);
        }

        //Performed once when the game ends
        public void End()
        {
            Console.WriteLine("\nThank you so much for to playing my game!");
        }
    }
}
