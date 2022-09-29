using GuessTheNumber.Generators;
using GuessTheNumber.Settings;
using GuessTheNumber.Levels.Interfaces;

namespace GuessTheNumber.Levels
{
    public class Level : ILevel
    {
        private readonly ILevelManager _manager;
        private readonly INumberGenerator _secretNumber;

        public LevelSettings Settings { get; set; }

        public Level(ILevelManager manager, INumberGenerator secretNumber)
        {
            _manager = manager;
            _secretNumber = secretNumber;
        }

        public bool Start()
        {
            var attempt = 0;
            bool isWin = false;

            EasterEgg();

            string textRange = $"от {Settings.SecretNumberMin} до {Settings.SecretNumberMax}";
            string textNumOfAttempts = GetTextNumOfAttempts(Settings.AttemptMax);
            _manager.DisplayText($"Угадайте число {textRange} за {textNumOfAttempts} и тогда победа будет за вами!\r\n");

            int secretNumber = _secretNumber.Generate(Settings.SecretNumberMin, Settings.SecretNumberMax);

            while (Settings.AttemptMax > attempt)
            {
                attempt++;
                _manager.DisplayText($"Попытка {attempt}. Ваше число: ");

                var guessNumber = _manager.GetNumber();

                if (guessNumber < Settings.SecretNumberMin || guessNumber > Settings.SecretNumberMax)
                    _manager.DisplayError($"Загаданное число находится в диапазоне {textRange}!\r\n");
                else if (guessNumber > secretNumber)
                    _manager.DisplayText($"Число {guessNumber} больше загаданного\r\n");
                else if (guessNumber < secretNumber)
                    _manager.DisplayText($"Число {guessNumber} меньше загаданного\r\n");
                else
                {
                    isWin = true;
                    break;
                }
            }

            string text = $"число \"{secretNumber}\" за {GetTextNumOfAttempts(attempt)}!";
            if (isWin)
            {
                _manager.DisplayText($"Отлично! Вы угадали {text}\r\n");
                return true;
            }
            else
            {
                _manager.DisplayText($"Вам не удалось отгадать {text}\r\n");
                return false;
            }
        }

        /// <summary>
        /// Получить текст количества попыток
        /// </summary>
        /// <param name="number"> кол-во попыток </param>
        /// <returns>"{кол-во} попыт{окончание}"</returns>
        private string GetTextNumOfAttempts(int number)
        {
            var text = $"{number} попыт";
            var lastNumber = number % 10;

            if (lastNumber == 1)                            // за 1 попыт[ку]
                return text + "ку";
            else if (lastNumber > 1 && lastNumber < 5)      // за 2,3,4 попыт[ки]
                return text + "ки";
            else                                            // за 5,6,7,8,9,0 попыт[ок]
                return text + "ок";
        }

        private void EasterEgg()
        {
            if (Settings.AttemptMax != 1 ||
               (Settings.SecretNumberMax - Settings.SecretNumberMin) < 9)
                return;

            _manager.PlaySoundTrack();
        }
    }
}
