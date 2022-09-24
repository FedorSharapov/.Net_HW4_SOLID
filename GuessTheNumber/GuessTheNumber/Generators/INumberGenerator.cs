namespace GuessTheNumber.Generators
{
    public interface INumberGenerator
    {
        /// <summary>
        /// Сгенерировать число в заданном диапазоне
        /// </summary>
        /// <param name="minValue">Нижняя граница диапазона</param>
        /// <param name="maxValue">Верхняя граница диапазона</param>
        /// <returns>число в заданном диапазоне</returns>
        int Generate(int minValue, int maxValue);
    }
}
