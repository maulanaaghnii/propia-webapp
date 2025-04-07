using System;

namespace denizen_generator_parser.Services
{
    public class HandednessService : IHandednessService
    {
        public string GenerateHandedness()
        {
            Random random = new Random();

            // Distribusi dominasi tangan sesuai persentase global
            (string handedness, double probability)[] handednessDistribution =
            {
                ("1", 90.0),    // Right-handed
                ("2", 9.0),     // Left-handed
                ("3", 1.0)      // Ambidextrous
            };
            
            double randValue = random.NextDouble() * 100;
            double cumulative = 0;
            
            foreach (var (hand, probability) in handednessDistribution)
            {
                cumulative += probability;
                if (randValue < cumulative)
                {
                    return hand;
                }
            }
            
            return handednessDistribution[^1].handedness; // Selalu mengembalikan nilai valid
        }
    }
}
