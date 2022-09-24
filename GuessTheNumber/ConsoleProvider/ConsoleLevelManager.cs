using ConsoleProvider.Sounds;
using GuessTheNumber.Levels.Interfaces;

namespace ConsoleProvider
{
    class ConsoleLevelManager : ILevelManager
    {
        CancellationTokenSource _cancelTokenSource;

        public void DisplayError(string message)
        {
            PrintText(message,ConsoleColor.Red);
        }
        public void DisplayText(string message)
        {
            PrintText(message);
        }
        public int GetNumber()
        {
            int number;
            bool isNumber;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                isNumber = int.TryParse(Console.ReadLine(), out number);
                if (!isNumber)
                    DisplayError("Необходимо ввести число!\r\n");
            }
            while (!isNumber);

            Console.ForegroundColor = ConsoleColor.White;

            return number;
        }
        
        public void PlaySoundTrack()
        {
            _cancelTokenSource?.Cancel();

            _cancelTokenSource = new CancellationTokenSource();
            Task.Factory.StartNew(() => PlaySoundTrack(SoundTracks.MissionImpossible, _cancelTokenSource.Token), 
                _cancelTokenSource.Token);
        }

        /// <summary>
        /// Печать текста в консоль
        /// </summary>
        /// <param name="text">сообщение игроку</param>
        /// <param name="color">цвет текста</param>
        private void PrintText(string text,ConsoleColor color = ConsoleColor.White)
        {
            char[] chars = text.ToCharArray();
            var delayGen = new Random();

            Console.ForegroundColor = color;
            foreach (char c in chars)
            {
                Console.Write(c);
                Thread.Sleep(delayGen.Next(5, 40));
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Проиграть звуковую дорожку
        /// </summary>
        /// <param name="soundTrack"> звуковая дорожка</param>
        /// <param name="playSoundTrack">токен отмены</param>
        private void PlaySoundTrack(SoundTrack soundTrack, CancellationToken playSoundTrack)
        {
            foreach(var sound in soundTrack.Track)
            {
                if (playSoundTrack.IsCancellationRequested)
                    return;

                sound.Play();
            }
        }
    }
}
