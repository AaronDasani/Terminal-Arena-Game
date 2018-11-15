using System;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            bool gameStarted=true;
            string HeroSelected=null;
            bool battleStarted;
            string attackOption=null;
            int round;

            while(gameStarted==true){
                Console.WriteLine("^^^^Welcome to the Aaron's Arena, Where Smashing your face come a reality.....^^^^");
                
                // User should choose a Hero...
                while (HeroSelected==null)
                {
                    Console.WriteLine("Select You Hero before entering the Arena... Choose Wisely !!!!");
                    
                    Console.WriteLine("Samurai            Ninja          Wizard");
                    HeroSelected=Console.ReadLine();
                    if (HeroSelected=="Samurai" || HeroSelected=="Ninja" || HeroSelected=="Wizard")
                    {
                        Console.WriteLine("You have selected a "+HeroSelected+".... Nice Choice. Good Luck out there..LOL \n");
                    }
                    else{
                        HeroSelected=null;
                    }
                }

                // Create the Hero, base on user input
                BaseHero Hero=null;
                switch (HeroSelected)
                {
                    case "Samurai":
                        Hero=new Samurai();
                        break;
                    case "Ninja":
                        Hero=new Ninja();              
                        break;
                    case "Wizard":
                        Hero=new Wizard();
                        break;
                }
                battleStarted=true;
                round=1;
                Random RandomMonster=new Random();
                BaseEnemy Monster=null;
                while (battleStarted==true)
                {   
                    bool RoundStart=true;
                    int result=RandomMonster.Next(1,4);
                    
                    switch (result)
                    {
                    case 1:
                        Monster=new Spider();
                        break;
                    case 2:
                        Monster=new Orgre();              
                        break;
                    case 3:
                        Monster=new Zombie();
                        break;
                    }   

                    while (RoundStart==true)
                    {
                        
                    

                        Hero.DisplayStatus();
                        Console.WriteLine(Monster.name+" health is "+Monster.health);
                        Console.WriteLine("........................ Round "+round+" ....................... \n");
                        Console.WriteLine("-------------------- "+Hero.name+" VS "+Monster.name+" ---------------\n");
                        Monster.calibrateToHero(Hero);
                        Hero.AttackOptions();
                        Console.Write("Your Move: ");
                        attackOption=Console.ReadLine();
                        Hero.chosenAttack(attackOption,Monster);
                        
                        Console.WriteLine(Monster.name+" is attaking you now.... Don't Die!!!");
                        Monster.chosenAttack();
                        Console.WriteLine("\n");
                        round++;

                        if (Hero.health<=0 || Monster.health<=0)
                        {
                            bool EndOfMatch=true;
                            RoundStart=false;
                            if (Hero.health>0)
                            {
                                
                                while(EndOfMatch==true){
                                    Console.WriteLine("The Winner is " +Hero.name+" Ohhh... You got lucky");
                                    Console.WriteLine("There is more Monsters if you want to crush them.... -->>Yes??");
                                    string answer=Console.ReadLine();
                                    if (answer=="Yes"||answer=="yes")
                                    {
                                        EndOfMatch=false;
                                        Hero.health=Hero.max_health;
                                        Hero.Mana=Hero.max_Mana;
                                    }
                                    else if(answer=="no"||answer=="No")
                                    {
                                        battleStarted=false;
                                        EndOfMatch=false;
                                        HeroSelected=null;
                                    }
                                    
                                }
                            }
                            else
                            {
                                while(EndOfMatch==true){
                                    Console.WriteLine("You Lost.... The Winner is "+Monster.name);
                                    Console.WriteLine("You can return to the home screen, by typing 'I Lost'");
                                    string answer=Console.ReadLine();
                                    if (answer=="i lost"||answer=="I Lost")
                                    {
                                        battleStarted=false;
                                        EndOfMatch=false;
                                        HeroSelected=null;
                                    }
                                }
                            }
                        }

                    }

                }

            }
            
            
            
        }
        
    }
}
