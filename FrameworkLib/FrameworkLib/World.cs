using FrameworkLib.Config;
using FrameworkLib.Logging;
using System;
using System.Diagnostics;

namespace GameFramework
{
    /// <summary>
    /// Represents the game world with a fixed width and height.
    /// </summary>
    public class World
    {
        /// <summary>
        /// The maximum X-coordinate of the world.
        /// </summary>
        public int MaxX { get; }

        /// <summary>
        /// The maximum Y-coordinate of the world.
        /// </summary>
        public int MaxY { get; }

        /// <summary>
        /// Initializes a new instance of the World class using configuration data.
        /// </summary>
        /// <param name="config">The configuration containing world size settings.</param>
        public World(GameConfig config)
        {
            MaxX = config.World.MaxX;
            MaxY = config.World.MaxY;

            Logger.Log($"[World] Initialized with size {MaxX} x {MaxY}");
        }

        /// <summary>
        /// Prints the world size to the console and logs it.
        /// </summary>
        public void PrintSize()
        {
            Console.WriteLine($"World size: {MaxX} x {MaxY}");
            Logger.Log($"[World] Printed size: {MaxX} x {MaxY}");
        }
    }
}
