using System;
using System.Collections.Generic;
namespace RPG{
    public abstract class BaseCharacter:IDestructable
    {
        public string name{get;set;}
        public int strength{get;set;}
        public int dexterity{get;set;}
        public int intelligence{get;set;}
        public int health{get;set;}
        public int max_health{get;set;}
        public int luck {get;set;}
        public int criticalAttack{get;set;}
        public int Mana {get;set;}
        public int max_Mana{get;set;}
        public bool IsEnemy {get;set;}

       
        public abstract void TakeDamage(int amount);

    
    }
}