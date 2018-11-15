using System;
namespace RPG{

    public abstract class BaseEnemy:BaseCharacter,ICallibrateToHero
    {
        public BaseHero enemy;
        public BaseEnemy(string name="unknown"){
            this.name=name;
            dexterity=25;
            strength=15;
            intelligence=10;
            health=100;
            criticalAttack=20;
            Mana=100;
        }
        public BaseEnemy(string name, int str,int intel, int dex,int HP,int CriticalAtk,int mana){

            this.name=name;
            this.dexterity=dex;
            this.strength=str;
            this.health=HP;
            this.intelligence=intel;
            this.criticalAttack=CriticalAtk;
            this.Mana=mana;

        }
        public void calibrateToHero(BaseHero hero){
            this.enemy=hero;
            Console.WriteLine("OK.. "+this.name+" is Calibrating on "+this.enemy.name);
            
        }
        public abstract void chosenAttack();

        public void NormalAttack()
        {
            enemy.TakeDamage(this.strength);
            Console.WriteLine(this.name+" did "+this.strength+" damage to you");                        
            
        }
    }
}