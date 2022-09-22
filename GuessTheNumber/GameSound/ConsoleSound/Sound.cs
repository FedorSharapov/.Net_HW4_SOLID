namespace GuessTheNumber.GameSound.ConsoleSound
{
    class Sound
    {
        public int Frequency { get; }
        public int Duration { get; }
        public int Pause { get; }

        public Sound(int frequency, int duration, int pause)
        {
            Frequency = frequency;
            Duration = duration;
            Pause = pause;
        }
    }
}
