using System;

namespace denizen_generator_parser.Services
{
    public class EyeColorService : IEyeColorService
    {
        public string GenerateEyeColor()
        {
            Random random = new Random();

            // Distribusi warna mata sesuai persentase global
            (string eyeColor, double probability)[] eyeColorDistribution =
            {
                ("1", 79.0),    // Brown
                ("2", 9.0),     // Blue
                ("3", 5.0),     // Hazel
                ("4", 3.0),     // Green
                ("5", 1.0),     // Gray
                ("6", 0.5),     // Amber
                ("7", 0.1),     // Red/Violet (Albino)
                ("8", 0.8)      // Heterochromia
            };
            
            double randValue = random.NextDouble() * 100;
            double cumulative = 0;
            
            foreach (var (color, probability) in eyeColorDistribution)
            {
                cumulative += probability;
                if (randValue < cumulative)
                {
                    return color;
                }
            }
            
            return eyeColorDistribution[^1].eyeColor; // Selalu mengembalikan nilai valid
        }
    }
}
