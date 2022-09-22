﻿namespace GuessTheNumber.Generator
{
    class NumberGenerator : INumberGenerator
    {
        public int Generate(int minValue, int maxValue)
        {
            return new Random().Next(minValue, maxValue + 1);
        }
    }
}
