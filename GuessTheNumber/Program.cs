using Microsoft.Extensions.DependencyInjection;
using GuessTheNumber.GameManager;
using GuessTheNumber.Generator;
using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Games;
using GuessTheNumber.GameMenu;

namespace GuessTheNumber
{
    static class Program
    {
        static void Main(string[] args)
        {
            var gameProvider = ConfigureServices();
            var menu = gameProvider.GetService<IGameMenu>();

            menu.Start();
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IGameManager, ConsoleGameManager>();
            serviceCollection.AddTransient<INumberGenerator, NumberGenerator>();
            serviceCollection.AddSingleton<IGameInit, GameInit>();
            serviceCollection.AddSingleton<IGame, Game>();
            serviceCollection.AddSingleton<IGameMenu, ConsoleGameMenu>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}