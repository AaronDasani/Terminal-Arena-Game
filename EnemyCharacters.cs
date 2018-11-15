

using System;

namespace RPG{
    public class Orgre:BaseEnemy
    {
        
        
        public Orgre(string name="Orgre"):base(name){
            this.name=name;
            health=200;
            max_health=health;
            

        }
        public Orgre(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=health;
            
        }
        // Take Damage
        public override void TakeDamage(int amount){
            
            this.health-=amount;
        }

        public void EyeLaser(){
            int damage=15;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by using its Eye Laser");
        }
        public void GreasyKick(){
            int damage=25;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by kicking in the face with its Greasy Foot");
        }
        public void Smash(){
            int damage=40;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by Smashing you");
        }

        public override void chosenAttack(){
            
            Random RandomAttack=new Random();
            int result=RandomAttack.Next(1,5);
            if (result==1){EyeLaser();}
            else if(result==2){GreasyKick();}
            else if(result==3){Smash();}
            else if(result==4){NormalAttack();}

        }


    }
    // Zombies
    public class Zombie:BaseEnemy
    {

        public Zombie(string name="Zombie"):base(name){
            this.name=name;
            max_health=health;
            

        }
        public Zombie(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=health;
            
        }
        // Take Damage
        public override void TakeDamage(int amount){
            this.health-=amount;
        }
        public void Bite(){
            int damage=12;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by Biting you");
        }
        public void Scratch(){
            int damage=6;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by Scratching you");
        }
        public void Vomiting(){
            int damage=30;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by Vommiting on you....Swipe that off!!! it's acid");
        }
        public override void chosenAttack(){
            
            Random RandomAttack=new Random();
            int result=RandomAttack.Next(1,5);
            if (result==1){Bite();}
            else if(result==2){Vomiting();}
            else if(result==3){Scratch();}
            else if(result==4){NormalAttack();}

        }

    }

    // BIG spider
    public class Spider:BaseEnemy
    {

        public Spider(string name="Spider"):base(name){
            this.name=name;
            health=140;
            max_health=health;

        }
        public Spider(string name ,int str, int intel, int dex, int hp,int CriticalAtk,int mana)
        :base(name,str,intel,dex,hp,CriticalAtk,mana){
            max_health=health;

        }
        // Take Damage
        public override void TakeDamage(int amount){
            this.health-=amount;
        }
        public void Poison(){
            int damage=30;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by Poisoning you...");
        }
        public void LegStab(){
            int damage=10;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by stabing you with its gigantic leg... Be careful!!");
        }
        public void WebShooter(){
            int damage=10;
            enemy.health-=damage;
            Console.WriteLine(this.name +" inflicted "+damage+" damage to you by web shooting you... Be Careful, Ain't SpiderMan cool webs..");
        }
        public override void chosenAttack(){
            
            Random RandomAttack=new Random();
            int result=RandomAttack.Next(1,5);
            if (result==1){WebShooter();}
            else if(result==2){Poison();}
            else if(result==3){LegStab();}
            else if(result==4){NormalAttack();}

        }

    }
}