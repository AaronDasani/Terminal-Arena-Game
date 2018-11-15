using System;
using System.Collections.Generic;

namespace RPG
{

    public abstract class BaseHero:BaseCharacter
    {
        public bool Armor{get;set;}
        public BaseHero(string name="unknown"){
            this.name=name;
            dexterity=25;
            strength=15;
            intelligence=10;
            health=100;
            criticalAttack=20;
            Mana=100;
        }
        public BaseHero(string name, int str,int intel, int dex,int HP,int CriticalAtk,int mana){

            this.name=name;
            this.dexterity=dex;
            this.strength=str;
            this.health=HP;
            this.intelligence=intel;
            this.criticalAttack=CriticalAtk;
            this.Mana=mana;

        }
        public void DisplayStatus(){
            Console.WriteLine("###################  The Arena of Death  ##################### \n");
            Console.WriteLine(">>>>>>>>>>>  "+"Health: "+this.health+"      Mana: "+this.Mana+"  <<<<<<<<<<<");
            
        }

        public abstract void AttackOptions();

        public abstract void chosenAttack(string attack,BaseEnemy enemy);
    }

}