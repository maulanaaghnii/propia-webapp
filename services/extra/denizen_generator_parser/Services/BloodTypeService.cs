using System;

namespace denizen_generator_parser.Services
{
    public class BloodTypeService : IBloodTypeService
    {
        public string GenerateBloodType()
        {
            Random random = new Random();

            // Distribusi golongan darah sesuai persentase global
            (string bloodType, double probability)[] bloodDistribution =
            {
                ("1", 40), //O+
                ("2", 30), //A+
                ("3", 10), //B+
                ("4", 4),  //AB+
                ("5", 4),  //O-
                ("6", 3),  //A-
                ("7", 2),  //B-
                ("8", 1)   //AB-
            };
            
            double randValue = random.NextDouble() * 100;
            double cumulative = 0;
            
            foreach (var (blood, probability) in bloodDistribution)
            {
                cumulative += probability;
                if (randValue < cumulative)
                {
                    return blood;
                }
            }
            
            return bloodDistribution[^1].bloodType;
        }
    }
}
