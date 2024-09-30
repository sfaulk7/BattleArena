using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BattleArena
{
    internal class Game
    {
        private bool playing = true;
        private bool _gameOver = false;
        public bool GameOver
        {
            get { return _gameOver; }

            set { _gameOver = value; }
        }

        private int GetInput(string Description, string option1, string option2)
        {
            ConsoleKeyInfo key;
            int inputRecieved = 0;

            while (inputRecieved != 1 && inputRecieved != 2)
            {
                Console.WriteLine(Description);
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.Write("> ");
                //Get input
                key = Console.ReadKey();
                //if first option
                if (key.KeyChar == '1')
                {
                    inputRecieved = 1;
                    Console.Clear();
                }
                //if second option
                else if (key.KeyChar == '2')
                {
                    inputRecieved = 2;
                    Console.Clear();
                }
                //if neither option error
                else
                {
                    Console.WriteLine("\nInvalid input");
                    Console.ReadKey();
                }
            }
            return inputRecieved;
        }

        private void Start()
        {

        }

        private void Update()
        {
            //Creates player
            Character player = new Character(name: "Player", maxHealth: 100, attackPower: 20, defensePower: 5);
            int enemiesDefeated = 0;

            //Defines Battle
            void Battle(Enemy enemy)
            {
                //Heal player to full at the start of a battle
                while (player.Health < player.MaxHealth)
                {
                    player.Heal();
                }

                //Scale player stats
                player.IncreaseStats(Increaser: enemiesDefeated);

                //Loops until either the enemy or player dies
                while (player.Health > 0 && enemy.Health > 0)
                {
                    Console.Clear();
                    player.PrintStats();
                    Console.WriteLine();
                    enemy.PrintStats();

                    Console.WriteLine();

                    int userInput = GetInput("What would you like to do?", "Attack", "Heal (25%)");
                    //Player Attacks
                    if (userInput == 1)
                    {
                        player.Attack(enemy);
                        Console.WriteLine();
                    }

                    //Player Heals
                    else if (userInput == 2)
                    {
                        player.Heal();
                    }

                    //Enemy attacks ONLY if it is alive
                    if (enemy.Health > 0)
                    {
                        float enemyDamage = enemy.Attack(player);
                        Console.WriteLine();
                    }

                    Console.ReadKey();

                    //End game if player dies
                    if (player.Health == 0)
                    {
                        Console.WriteLine("You died!");
                        Console.WriteLine("Enemies Defeated: " + enemiesDefeated);
                        Console.WriteLine("Game over!");
                        Console.ReadKey();

                    }
                    //Continue if enemy dies
                    else if (enemy.Health == 0)
                    {
                        enemiesDefeated += 1;
                        Console.WriteLine("You defeated the enemy!");
                        Console.WriteLine("Enemies Defeated: " + enemiesDefeated);
                        Console.WriteLine("Onto the next!");

                        Console.ReadKey();
                    }
                }
            }

            //Loops until the player dies
            while (player.Health > 0)
            {
                //Chooses enemy
                int ChooseEnemy()
                {
                    Random randomNumber = new Random();
                    int result = randomNumber.Next(1, 4);

                    return result;
                }
                int enemyChosen = ChooseEnemy();

                //Makes enemy Swordsman
                if (enemyChosen == 1)
                {
                    Enemy swordsman = new Swordsman(name: "Swordsman", maxHealth: 100 + enemiesDefeated * 2, attackPower: 20 + enemiesDefeated / 2, defensePower: 2 + enemiesDefeated / 4);
                    //Initiates Battle
                    Battle(swordsman);
                }
                //Makes enemy Tank
                else if (enemyChosen == 2)
                {
                    Enemy tank = new Tank(name: "Tank", maxHealth: 150 + enemiesDefeated * 2, attackPower: 10 + enemiesDefeated / 4, defensePower: 4 + enemiesDefeated / 2);
                    //Initiates Battle
                    Battle(tank);
                }
                //Makes enemy MinMaxer
                else if (enemyChosen == 3)
                {
                    //Choose MinMaxer's minmaxed stat
                    Random randomNumber = new Random();
                    int result = randomNumber.Next(1, 4);

                    //Assign MinMaxer's minmaxed stat to health
                    if (result == 1)
                    {
                        Enemy minmaxer = new MinMaxer(name: "MinMaxer", maxHealth: 150 + enemiesDefeated * 3, attackPower: 10 + enemiesDefeated / 5, defensePower: 2 + enemiesDefeated / 5);
                        //Initiates Battle
                        Battle(minmaxer);
                    }
                    //Assign MinMaxer's minmaxed stat to damage
                    if (result == 2)
                    {
                        Enemy minmaxer = new MinMaxer(name: "MinMaxer", maxHealth: 150 + enemiesDefeated / 5, attackPower: 10 + enemiesDefeated * 3, defensePower: 2 + enemiesDefeated / 5);
                        //Initiates Battle
                        Battle(minmaxer);
                    }
                    //Assign MinMaxer's minmaxed stat to defense
                    if (result == 3)
                    {
                        Enemy minmaxer = new MinMaxer(name: "MinMaxer", maxHealth: 150 + enemiesDefeated / 5, attackPower: 10 + enemiesDefeated / 5, defensePower: 2 + enemiesDefeated * 3);
                        //Initiates Battle
                        Battle(minmaxer);
                    }
                }
            }

            //Ends game
            GameOver = true;

        }

        private void End()
        {
            int userInput = GetInput("Play again?", "Yes", "No");

            //Restart game
            if (userInput == 1)
            {
                GameOver = false;
                Console.WriteLine("Good Luck");
                Console.ReadKey();
            }
            //End game
            else if (userInput == 2)
            {
                playing = false;
            }
        }

        public void Run()
        {
            while (playing == true)
            {
                Start();

                while (!GameOver)
                {
                    Update();
                }

                End();
            }
        }

    }
}