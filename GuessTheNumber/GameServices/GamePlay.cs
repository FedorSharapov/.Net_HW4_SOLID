using GuessTheNumber.GameManager;
using GuessTheNumber.Generator;
using GuessTheNumber.Games.Interfaces;

namespace GuessTheNumber.Games
{
    class GamePlay : IGamePlay
    {
        private protected readonly IGameManager _manager;
        private readonly INumberGenerator _secretNumber;
        private protected GameSettings _settings;

        public GamePlay(IGameManager manager, INumberGenerator secretNumber)
        {
            _manager = manager;
            _secretNumber = secretNumber;
            _settings = new GameSettings
            {
                SecretNumberMin = 0,
                SecretNumberMax = 100,
                AttemptMax = 15
            };
        }

        public void Play()
        {
            var attempt = 0;   
            bool isWin = false;

            EasterEgg();

            string textRange = $"от {_settings.SecretNumberMin} до {_settings.SecretNumberMax}";
            string textNumOfAttempts = GetTextNumOfAttempts(_settings.AttemptMax);
            _manager.DisplayText($"Угадайте число {textRange} за {textNumOfAttempts} и тогда победа будет за вами!\r\n");

            int secretNumber = _secretNumber.Generate(_settings.SecretNumberMin, _settings.SecretNumberMax);

            while (_settings.AttemptMax > attempt)
            {
                attempt++;
                _manager.DisplayText($"Попытка {attempt}. Ваше число: ");

                var guessNumber = _manager.GetNumber();

                if (guessNumber < _settings.SecretNumberMin || guessNumber > _settings.SecretNumberMax)
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
                _manager.DisplayText($"Отлично! Вы угадали {text}\r\n");
            else
                _manager.DisplayText($"Вам не удалось отгадать {text}\r\n");
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
            if (_settings.AttemptMax != 1 ||
               (_settings.SecretNumberMax - _settings.SecretNumberMin) < 98)
                return;

            _manager.PlaySoundTrack();
        }
    }
}
