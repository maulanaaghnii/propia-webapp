using System;

class Program
{
    static Random random = new Random();
    
    static void Main()
    {
        Console.WriteLine(GenerateBloodType());
    }

    static string GenerateBloodType()
    {
        // Distribusi golongan darah sesuai persentase global
        (string bloodType, double probability)[] bloodDistribution =
        {
            ("O+", 40),
            ("A+", 30),
            ("B+", 10),
            ("AB+", 4),
            ("O-", 4),
            ("A-", 3),
            ("B-", 2),
            ("AB-", 1)
        };
        
        double randValue = random.NextDouble() * 100; // Nilai antara 0-100
        double cumulative = 0;
        
        foreach (var (blood, probability) in bloodDistribution)
        {
            cumulative += probability;
            if (randValue < cumulative)
            {
                return blood;
            }
        }
        
        return bloodDistribution[^1].bloodType; // Selalu mengembalikan nilai valid
    }
}
