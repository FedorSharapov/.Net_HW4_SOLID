using ConsoleProvider.Menu;
using GuessTheNumber.Games.Interfaces;
using GuessTheNumber.Generators;
using GuessTheNumber.Levels;
using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Rules;
using GuessTheNumber.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleProvider
{
    internal class Program
    {
        static void Main()
        {
            var gameProvider = ConfigureServices();

            try
            {
                var menu = gameProvider.GetService<IGameMenu>();
                menu.Start();
            }  
            catch(Exception ex)
            {
                ConsoleDisplayHelper.DisplayError(ex.Message + $"\r\n\r\nПодробное описание:\r\n{ex}");
                Console.ReadKey();
            }
        }

        private static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<INumberGenerator, NumberGenerator>();
            serviceCollection.AddSingleton<ILevelManager, ConsoleLevelManager>();
            serviceCollection.AddSingleton<ILevel, Level>();
            serviceCollection.AddSingleton<IUserLevelInit, UserLevelInit>();
            serviceCollection.AddSingleton<IGameDescription, GameDescription>();
            serviceCollection.AddSingleton<IGame, MultilevelGame>(); //serviceCollection.AddSingleton<IGame, BaseGame>();
            serviceCollection.AddSingleton<IUserGame, UserGame>();
            serviceCollection.AddSingleton<IGameMenu, ConsoleGameMenu>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}