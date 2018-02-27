using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeathDungeon.Models;

namespace DeathDungeon.Models
{
    public class BattleClass
    {
        //----------------------------------------------------------------------
        public bool _gameactive { get; set; }
        bool AutoPlay;
        private static BattleClass _instance;

        public static BattleClass Instance
        {
            get
           {
               if (_instance == null)
                {
                    _instance = new BattleClass();
                }
                return _instance;
            }
        }
       
        public BattleClass()
        {
            _gameactive = false;//set active game
            AutoPlay = false;

        }
        //------------------Game Modes------------------------------------------
        //private static ItemsController _instance;

        //public static ItemsController Instance
        //{
        //    get
        //    {
        //        if (_instance == null)
        //        {
        //            _instance = new ItemsController();
        //        }
        //        return _instance;
        //    }
        //}
        //needed to intialize the game
        public void BeginGame(){
            _gameactive=true;
            //START NEW SCORE
            //START NEW BATTLE HISTORY
            //TODO begin game
        }
        //will begin running game
        public void EndGame(){
            //RECORD SCORES
            //DISPLAY BATTLE HISTORY
            _gameactive=false;
        }
        //will end game
        public bool AutoPlayGame(bool yes_auto){
            if (yes_auto)
            {
                AutoPlay = true;
                return true;
            }
            else
                return false;
            //TODO will let game keep playing if on, 
            //method for battle shoudl implment auto methods, but subject to 
            //human maniuplation if false
        }
        //------------------TURN MANAGEMENT-------------------------------------
        //will autoplay if active
        //QUEUE that should compare speed levels of current characters and mosnter
        List<Character> ListCharacters = new List<Character>();
        List<Monster> ListMonsters = new List<Monster>();
        public void battleInstance(){
            //populate both list with current living character and  random monsters
            //order them according to speed
            //ListCharacters = characters.orderby speed(least to greatest)
            //ListMonsters = monsters.orderby speed
           
            //turn by turn attack. if character or monster die, romove them from queue and game
            //battle is over once one of the queue is empty
            //while(!ListCharacters.Any()||!ListMonsters.Any()){
            //scan through list until end then return to start of list
            //remove entity, shift if dead character
            //empty list end of battle to be used again next time
            if(!ListCharacters.Any()){
                EndGame();//will end game if no more characters active
            }
            //}
        }
        //------------COMBAT----------------------------------------------------

        //Apply damage to character from monster attack
        public void ApplyDamageToCharacter(Character character, int monsterDamage){
            if (character.IsLiving())
            {
                character.ApplyIncomingDamage(monsterDamage);
                if (character.CurrentHealth <= 0)
                {
                    character.Living = false;
                }
                //maybe display monster damage character for monsterDmage

            }
        }

        //Apply damage to monster from character attack
        public void ApplyDamageToMonster(Monster monster,
                                         int characterDamage){
            if (monster.IsLiving())
            {
                monster.ApplyIncomingDamage(characterDamage);
                if(monster.CurrentHealth<0)
                {
                    monster.Living = false;
                }
                //maybe display character damage monster for characterDamage

            }
        }


        public void CharacterAttacks(Character character,Monster monster)
        {
            int applyDamage = character.Attack; //will calculate if character attack with modifiers
            //roll and if roll is greater than monster damage land attack
            int monsterEXP=monster.GivenExperience(applyDamage);
            ApplyDamageToMonster( monster,applyDamage);
            character.AddExperience(monsterEXP);
            character.CheckExperience();
        }

        //
        public void MonsterAttacks(Character character, Monster monster)
        {
            int applyDamage = monster.Attack; //will calculate monster attack with modifiers
            ApplyDamageToCharacter(character,  applyDamage);
        }
        //allow monster to attack monster
        //----------------------------------------------------------------------

    }


}
