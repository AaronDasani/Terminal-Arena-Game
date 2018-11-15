using System;

namespace RPG{

    public abstract class HeroAction
    {
        public string HeroOption;
        public int ManaCost;

        public string HeroOptionFullName;

        public HeroAction(string heroOption,string fullName, int ManaCost){
            this.HeroOption=heroOption;
            this.ManaCost=ManaCost;
            this.HeroOptionFullName=fullName;
        }

        public abstract void Hero_action(BaseEnemy enemy, BaseHero hero);
    }

    // This Attack is use by all Heroes.........
    public class NormalAttack:HeroAction
    {
        public NormalAttack():base("NA","Normal Attack",0){
        
        }
        public override void Hero_action(BaseEnemy enemy,BaseHero hero){
            enemy.TakeDamage(hero.strength);
            Console.WriteLine("You did "+hero.strength+" damage to " +enemy.name);            
            
        }
    }


    // ------------------Ninja Attacks And Passive Abilities---------------------
    // Attacks
    
    public class KatanaStrike:HeroAction
    {

        public KatanaStrike():base("KS","Katana Strike",25){
        
        }
        public override void Hero_action(BaseEnemy enemy,BaseHero hero){
            if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else{
                Random rand= new Random();
                int luckdamage=rand.Next(hero.luck+10,80);
                enemy.TakeDamage(luckdamage);                
                // mana cost
                hero.Mana-=ManaCost;
                // reset luck to default
                hero.luck=20;
                Console.WriteLine(enemy.name+" health went down by "+ luckdamage);

            }
        }
    }
    public class TrowingStars:HeroAction
    {

        public TrowingStars():base("TS","Throwing Stars",15){
        
        }
        public override void Hero_action(BaseEnemy enemy,BaseHero hero){
        
            Console.WriteLine(ManaCost);
            if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else{
                Random rand= new Random();
                int luckdamage=rand.Next(hero.luck,51);
                
                enemy.TakeDamage(luckdamage);
                // mana cost
                hero.Mana-=ManaCost;
                // reset luck to default
                hero.luck=20;
                Console.WriteLine(enemy.name+" health went down by "+ luckdamage);
    
            }
            

        }
    }

    public class StealHealth:HeroAction
    {
        public StealHealth():base("SH","Steal Health",20){
        
        }
        public override void Hero_action(BaseEnemy enemy,BaseHero hero){
            
            if (hero.health==hero.max_health)
            {
                Console.WriteLine("You don't need healing, You are already in good health... Steal Something Else!!");
            }
            else
            {
                if (hero.Mana<0 || hero.Mana<ManaCost)
                {
                    Console.WriteLine("You do not have enough mana");
                }
                else{
                    Random rand= new Random();
                    int luckHealth=rand.Next(hero.luck,51);
                    int healthAmountReceived=luckHealth;
                    int healthNeeded=hero.max_health-hero.health;
                    // damage enemy as passive effect of stealing health
                    enemy.TakeDamage(hero.dexterity/4);
                    // mana cost
                    hero.Mana-=ManaCost;
                    if (healthAmountReceived>healthNeeded){hero.health+=healthNeeded;} else{hero.health+=healthAmountReceived;}
                    Console.WriteLine("Your Health is now: "+hero.health);
                    Console.WriteLine(enemy.name+" health went down by "+ 10);
                }
            }

        }
    }

    // Passive Abilities
    public class ActivateLuck:HeroAction
    {
        public ActivateLuck():base("AL","Activate Luck",40){
        
        }
        public override void Hero_action(BaseEnemy enemy,BaseHero hero){
            hero.luck+=30;
            hero.Mana-=ManaCost;
            Console.WriteLine("Your luck increased by 30 for one round...Choose a wise Attack");
        }
        
    }

// --------------------------End of Ninja Moves Option--------------------------


// --------------------------Wizard Attacks and Passive Abilities-------------------------


public class FrostStorm:HeroAction
{

    public FrostStorm():base("FS","Frost Storm",35){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){
 
        if (hero.Mana<0 || hero.Mana<ManaCost)
        {
            Console.WriteLine("You do not have enough mana");
        }
        else{
            Random randDamage=new Random();
            int topDamage=50+hero.intelligence;
            int damageDone=randDamage.Next(30,topDamage);
            
            enemy.TakeDamage(damageDone);

            hero.Mana=hero.Mana-ManaCost;
            Console.WriteLine("The Forst Storm did "+damageDone+" damage to the"+enemy.name);
 
        }

        
    }
}

public class FireballAttack:HeroAction
{

    public FireballAttack():base("FB","Fireball",35){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){

        if (hero.Mana<0 || hero.Mana<ManaCost)
        {
            Console.WriteLine("You do not have enough mana");
        }
        else{
            Random randDamage=new Random();
            int topDamage=50+hero.intelligence;
            int damageDone=randDamage.Next(20,topDamage);
            enemy.TakeDamage(damageDone);
     
            hero.Mana=hero.Mana-ManaCost;
            Console.WriteLine("The Fireball did "+damageDone+" damage to the "+enemy.name);
        }

        
    }
}

public class ReplenishMana:HeroAction
{
    public ReplenishMana():base("RM","Replenish Mana",35){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){
        if (hero.Mana==hero.max_Mana)
        {
            Console.WriteLine("You already have max mana... Stop wasting turns.");
        }
        else
        {
            if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else{
                int ManaAmountReceived=hero.intelligence;
                int ManaNeeded=hero.max_Mana-hero.Mana;
                hero.Mana=hero.Mana-ManaCost;
                if (ManaAmountReceived>ManaNeeded){hero.Mana+=ManaNeeded;} else{hero.Mana+=ManaAmountReceived;}
                Console.WriteLine("Your Mana increased by: "+ManaAmountReceived);
            }
            
        }

        
    }
}
public class Heal:HeroAction
{
    public Heal():base("H","Heal",35){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){
        if (hero.health==hero.max_health)
        {
            Console.WriteLine("You don't need healing, You are already in good health... Stop wasting Mana");
        }
        else
        {
            if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else{
                int healthAmountReceived=hero.health+hero.intelligence;
                int healthNeeded=hero.max_health-hero.health;
                hero.Mana=hero.Mana-ManaCost;
                if (healthAmountReceived>healthNeeded){hero.health+=healthNeeded;} else{hero.health+=healthAmountReceived;}
                Console.WriteLine("You got some Health");
            }
        }

        
    }
}
// --------------------------End of Wizard Moves Option--------------------------



// ---------------------------Samurai Attacks and Abilities----------------------

public class death_blow:HeroAction
{
    public death_blow():base("DB","death_blow",35){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){

         if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else{
                hero.Mana-=ManaCost;
                // this.health-=10;
                hero.TakeDamage(10);
                if (enemy.health<=50)
                {
                    enemy.health=0;
                    Console.WriteLine("Enemy {0} Executed",enemy.name);
                }
                else
                {
                    // enemy.health-=50;
                    enemy.TakeDamage(50);   
                    Console.WriteLine("Enemy {0} health is now {1}..Stike The Vermine",enemy.name,enemy.health);
                }
            }

        
    }
}

public class LightingStrike:HeroAction
{
    public LightingStrike():base("LS","Lighting Strike",20){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){

        if (hero.Mana<0 || hero.Mana<ManaCost)
        {
            Console.WriteLine("You do not have enough mana");
        }
        else{
            hero.Mana-=20;
            // enemy.health-=20;
            enemy.TakeDamage(ManaCost);  
            enemy.Mana-=ManaCost;
            Console.WriteLine("The {0} is bleeding {1} Mana and Health...",enemy.name,ManaCost);
        }
    
    }
}

public class ArmorBuffer:HeroAction
{
    public ArmorBuffer():base("AB","Armor Buffer",10){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){

        if (hero.Mana<0 || hero.Mana<ManaCost)
        {
            Console.WriteLine("You do not have enough mana");
        }
        else
        {
            hero.Armor=true;
            hero.Mana-=ManaCost;
            Console.WriteLine("Armor Activate... it will take half the damage..");
        }
    
    }
}
public class meditate:HeroAction
{
    public meditate():base("M","Meditate",20){
    
    }
    public override void Hero_action(BaseEnemy enemy,BaseHero hero){

        if (hero.Mana<0 || hero.Mana<ManaCost)
            {
                Console.WriteLine("You do not have enough mana");
            }
            else
            {
                hero.health=hero.max_health;
                hero.Mana-=40;
                Console.WriteLine("You are fully healed");
            }
    
    }
}
// --------------------------End of Samurai Moves Option--------------------------



}
