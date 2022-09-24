namespace ConsoleProvider.Sounds
{
    class Sound
    {
        private int _frequency { get; }
        public int _duration { get; }
        public int _pause { get; }

        public Sound(int frequency, int duration, int pause)
        {
            _frequency = frequency;
            _duration = duration;
            _pause = pause;
        }

        public void Play()
        {
            Console.Beep(_frequency, _duration);
            Thread.Sleep(_pause);
        }
    }
}
