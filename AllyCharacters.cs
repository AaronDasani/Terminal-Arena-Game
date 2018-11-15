using System;
using System.Collections.Generic;

namespace RPG{
    public class Wizard:BaseHero,IHeroAttacks
    { 
        public List<HeroAction> heroAction= new List<HeroAction>();
        public Wizard(string name="Wizard"):base(name){
            this.name=name;
            intelligence=35;
            health=120;
            max_health=health;
            this.Mana=200;
            max_Mana=Mana;
            heroAction.Add(new FireballAttack());
            heroAction.Add(new FrostStorm());
            heroAction.Add(new Heal());
            heroAction.Add(new ReplenishMana());
            heroAction.Add(new NormalAttack());
            
        }
        public Wizard(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=hp;
            max_Mana=mana;
            heroAction.Add(new FireballAttack());
            heroAction.Add(new FrostStorm());
            heroAction.Add(new Heal());
            heroAction.Add(new ReplenishMana());
            heroAction.Add(new NormalAttack());

        }
        // Take Damage
        public override void TakeDamage(int amount){
            this.health-=amount;
        }

        // Display Attack Option
        public override void AttackOptions(){
            Console.WriteLine("************************* Your Attacks *************************");
            foreach (var item in heroAction)
            {
                Console.WriteLine("["+item.HeroOption+"]"+item.HeroOptionFullName+" ----->>> "+item.ManaCost+" Mana");
            }
            Console.WriteLine("***************************** Arena *************************");
            
        }
        // // Selected Attack...
        public override void chosenAttack(string option,BaseEnemy enemy){
            
            foreach (var item in heroAction)
            {
                if (option==item.HeroOption){item.Hero_action(enemy,this);return;}
                 
                
            }
        }
    }

    // Ninja
    public class Ninja:BaseHero,IHeroAttacks
    {
        public List<HeroAction> heroAction= new List<HeroAction>();
        public Ninja(string name="Ninja"):base(name){
            this.name=name;
            dexterity=100;
            intelligence=20;
            criticalAttack=50;
            max_health=health;
            max_Mana=Mana;
            luck=20;
            heroAction.Add(new KatanaStrike());
            heroAction.Add(new TrowingStars());
            heroAction.Add(new StealHealth());
            heroAction.Add(new NormalAttack());
            heroAction.Add(new ActivateLuck());
 
        }
        public Ninja(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=hp;
            max_Mana=mana;
            heroAction.Add(new KatanaStrike());
            heroAction.Add(new TrowingStars());
            heroAction.Add(new StealHealth());
            heroAction.Add(new NormalAttack());
            heroAction.Add(new ActivateLuck());
        }

        // Take Damage
        public override void TakeDamage(int amount){
            this.health-=amount;
        }
        // Display Attack Option
        public override void AttackOptions(){
            Console.WriteLine("************************* Your Attacks *************************");
            foreach (var item in heroAction)
            {
                Console.WriteLine("["+item.HeroOption+"]"+item.HeroOptionFullName+" ----->>> "+item.ManaCost+" Mana");
            }
            Console.WriteLine("***************************** Arena *************************");
            
        }
        // Selected Attack...
        public override void chosenAttack(string option,BaseEnemy enemy){
            
            foreach (var item in heroAction)
            {
                if (option==item.HeroOption){item.Hero_action(enemy,this);return;}
                 
                
            }
        }

    }
    // Samurai
    public class Samurai:BaseHero,IHeroAttacks
    {

        public List<HeroAction> heroAction= new List<HeroAction>();
        public Samurai(string name="Samurai"):base(name){
            this.name=name;
            health=160;
            criticalAttack=80;
            max_health=health;
            max_Mana=Mana;
            heroAction.Add(new ArmorBuffer());
            heroAction.Add(new death_blow());
            heroAction.Add(new LightingStrike());
            heroAction.Add(new meditate());
            heroAction.Add(new NormalAttack());

     
        }
        public Samurai(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=hp;
            max_Mana=mana;
            heroAction.Add(new ArmorBuffer());
            heroAction.Add(new death_blow());
            heroAction.Add(new LightingStrike());
            heroAction.Add(new meditate());
            heroAction.Add(new NormalAttack());
        }

        // Take Damage
        public override void TakeDamage(int amount){
            if (this.Armor==true)
            {
                amount=amount/2;
                Armor=false;
            }
            this.health-=amount;
        }
        // Display Attack Option
        public override void AttackOptions(){
            Console.WriteLine("************************* Your Attacks *************************");
            foreach (var item in heroAction)
            {
                Console.WriteLine("["+item.HeroOption+"]"+item.HeroOptionFullName+" ----->>> "+item.ManaCost+" Mana");
            }
            Console.WriteLine("***************************** Arena *************************");
            
        }
        public override void chosenAttack(string option,BaseEnemy enemy){
            
            foreach (var item in heroAction)
            {
                if (option==item.HeroOption){item.Hero_action(enemy,this);return;}
                 
                
            }
        }
    }
}