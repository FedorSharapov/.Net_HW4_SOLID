using ConsoleProvider.Menu;
using GuessTheNumber.Generators;
using GuessTheNumber.Levels;
using GuessTheNumber.Levels.Interfaces;
using GuessTheNumber.Rules;
using GuessTheNumber.Services;
using GuessTheNumber.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleProvider
{
    public delegate IGamePlay GamePlayProvider(string key);

    internal class Program
    {
        static void Main()
        {
            try
            {
                var gameProvider = ConfigureServices();
            
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
            
            serviceCollection.AddSingleton<MultilevelGame>();
            serviceCollection.AddSingleton<UserGame>();
            
            serviceCollection.AddSingleton<IGameInit>(s => s.GetService<UserGame>());

            serviceCollection.AddSingleton<GamePlayProvider>(serviceProvider => key =>
            {
                switch (key)
                {
                    case "multi":
                        return serviceProvider.GetService<MultilevelGame>();
                    case "user":
                        return serviceProvider.GetService<UserGame>();
                    default:
                        throw new KeyNotFoundException();
                }
            });

            serviceCollection.AddSingleton<IGameDescription, GameDescription>();
            serviceCollection.AddSingleton<IGameMenu, ConsoleGameMenu>();

            return serviceCollection.BuildServiceProvider();
        }
    }
}