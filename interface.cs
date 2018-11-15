using System.Collections.Generic;

namespace RPG{
    
    public interface ICallibrateToHero
    {
        void calibrateToHero(BaseHero hero);
    }

    public interface IDestructable{
       
        void TakeDamage(int amount);
    }
    public interface IHeroAttacks
    {
        void AttackOptions();
        void chosenAttack(string attack,BaseEnemy enemy);
    }


}