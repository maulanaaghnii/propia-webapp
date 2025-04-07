using System;

namespace denizen_generator_parser.Services
{
    public class BirthTimeService : IBirthTimeService
    {
        private static Random random = new Random();
        public string GenerateBirthTime()
        {
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);
        
        return $"{hours:D2}{minutes:D2}{seconds:D2}";
        }
    }
}
