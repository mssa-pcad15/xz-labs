using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part3
{
    internal class WhileChallenge
    {
        internal static void HeroMonster()
        {
            int heroHealth = 10;
            int monsterHealth = 10;
            Random random = new Random();
            int lostHealthMonster = random.Next(1, 11);
            int lostHealthHero = random.Next(1, 11);

            while (heroHealth > 0 && monsterHealth > 0)
            {
                monsterHealth -= lostHealthMonster;
                heroHealth -= lostHealthHero;
                Console.WriteLine($"Monster was damaged and lost {lostHealthMonster} health and now has {monsterHealth} health.");
                Console.WriteLine($"Hero was damaged and lost {lostHealthHero} health and now has {heroHealth} health.");
            }
            if (heroHealth > monsterHealth)
                Console.WriteLine("Hero wins!");
            else
                Console.WriteLine("Monster wins!");
        }
    }
}
