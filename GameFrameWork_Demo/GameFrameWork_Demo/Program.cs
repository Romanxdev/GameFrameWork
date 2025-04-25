using System;
using System.Diagnostics;
using FrameworkLib;
using FrameworkLib.Config;
using FrameworkLib.Creatures;
using FrameworkLib.Items;
using FrameworkLib.Logging;

namespace GameFramework_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // === GameFramework Demo ===
            Console.WriteLine("=== GameFramework Demo ===\n");

            // Add logging to both console and file
            Trace.Listeners.Add(new ConsoleTraceListener());
            Trace.Listeners.Add(new TextWriterTraceListener("log.txt"));

            // Load configuration
            GameConfig config;
            try
            {
                config = ConfigLoader.Load("config.xml");
                Console.WriteLine($"Game Level: {config.GameLevel}");
                Console.WriteLine($"World Size: {config.World.MaxX} x {config.World.MaxY}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading config: " + ex.Message);
                return;
            }

            // Create Player and Enemy
            var enemy = new Enemy("Goblin", 40);
            var player = new Player("Hero", 60, enemy);
            enemy = new Enemy("Goblin", 40, player); // Set player as target

            // Observer pattern – show damage when enemy is hit
            enemy.OnHit += (c, dmg) => Console.WriteLine($"{c.Name} took {dmg} damage");

            // Strategy pattern – use a basic attack strategy
            player.AttackStrategy = new BasicAttackStrategy();
            enemy.AttackStrategy = new BasicAttackStrategy();

            Console.WriteLine("Starting demo round...\n");

            // First turn
            player.PerformTurn();
            player.Attack(enemy);

            enemy.PerformTurn();
            enemy.Attack(player);

            // Show status
            Console.WriteLine($"\nHero HP: {player.Health}");
            Console.WriteLine($"Goblin HP: {enemy.Health}");

            Console.WriteLine("\nFramework demo complete. Press any key to exit.");
            Console.ReadKey();

            // Flush all loggers
            Trace.Flush();
        }
    }
}
