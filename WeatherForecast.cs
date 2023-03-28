namespace SilvershotCore
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }
        /// <summary>
        /// Temp in C
        /// </summary>
        public int TemperatureC { get; set; }
        /// <summary>
        /// Temp in F
        /// </summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        /// <summary>
        /// Summary
        /// </summary>
        public string? Summary { get; set; }
    }
}