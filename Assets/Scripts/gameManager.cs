using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    HashSet<string> spokenToNPCs = new HashSet<string>();
    Dictionary<string, string> gear = new Dictionary<string, string>();
    bool chapter1Completed = false;
    public float duration = 5f;
    //private bool gamePlay = true;


    public TMP_Text consoleText;
    public TextMeshProUGUI displayText;  // TextMeshPro Text component

    public TMP_Text consoleInput;

    public TypewriterEffect typewriterEffect;
    public TMP_InputFieldHandler inputFieldHandler;




    // Start is called before the first frame update
    void Start()
    {
        inputFieldHandler = FindObjectOfType<TMP_InputFieldHandler>();
        typewriterEffect = FindObjectOfType<TypewriterEffect>();

        int choice = 0;

        if (typewriterEffect != null)
        {
            // Call the StartTypewriterEffect method with a message and color
            typewriterEffect.ConsoleWriteLine("Welcome to the Fantasy RPG!", Color.green, true);
        }

        // Game Loop
        //
        //

        // Character Creation
        Player player = CreateCharacter();

        typewriterEffect.ConsoleWriteLine("What would you like to do?", Color.green, false);
        typewriterEffect.ConsoleWriteLine("1. Explore", Color.green, false);
        typewriterEffect.ConsoleWriteLine("2. Check Inventory", Color.green, false);
        typewriterEffect.ConsoleWriteLine("3. Quests", Color.green, false);
        typewriterEffect.ConsoleWriteLine("4. Quit", Color.green, false);

        /*
        while (choice == 0)
        {

            choice = inputFieldHandler.ConsoleReadLine<int>();

            
            switch (choice)
            {
                case 1:
                    Explore(player);
                    break;
                case 2:
                    ViewInventory(player);
                    break;
                case 3:
                    ViewQuests(player);
                    break;
                case 4:
                    GameOver();
                    break;
                default:
                    typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                  break;
            
            }
           
        }
         */

        ClearDisplayText();


    }



    // Update is called once per frame
    void Update()
    {

    }

    public void ClearDisplayText()
    {
        if (typewriterEffect != null)
        {
            typewriterEffect.ClearText();
        }
    }


    public void GameOver()
    {
            typewriterEffect.ConsoleWriteLine("Exiting game...");

    }
    /*
   

    public string  typewriterEffect.ConsoleWriteLine(string typeLine,  string textColour)
    {
        string prefix;
        string suffix;

        switch (textColour)
        {
            case "Red":
                prefix = "<color='red'>";
                suffix = "</color>";
                break;
            case "Green":
                prefix = "<color='green'>";
                suffix = "</color>";
                break;
            default:
                prefix = "<color='white'>";
                suffix = "</color>";
                break;
        }

        typeLine = consoleText.text + "\n" + prefix + typeLine + suffix;

        //consoleText.text = consoleText.text  + "\n" + prefix + typeLine + suffix;
       
        //StartCoroutine(WaitPeriod(duration));
    }

    */
    IEnumerator WaitPeriod(float duration)
    {
        Debug.Log($"Started at {Time.time}, waiting for {duration} seconds");
        yield return new WaitForSeconds(duration);
        Debug.Log($"Ended at {Time.time}");
    }

     Player CreateCharacter()
    {
        typewriterEffect.ConsoleWriteLine("Create your character:");
        typewriterEffect.ConsoleWriteLine("Enter name: ");

        string name = inputFieldHandler.ConsoleReadLine<string>();

        RaceClass race = 0;
        while (race == 0)
        {
             typewriterEffect.ConsoleWriteLine("Choose your race:");
             typewriterEffect.ConsoleWriteLine("1. Human");
             typewriterEffect.ConsoleWriteLine("2. Orc");
             typewriterEffect.ConsoleWriteLine("3. Vampire");
             typewriterEffect.ConsoleWriteLine("4. Elf");
             typewriterEffect.ConsoleWriteLine("5. Dwarf");
             typewriterEffect.ConsoleWriteLine("6. Dragonborn");
             typewriterEffect.ConsoleWriteLine("7. Tiefling");
             typewriterEffect.ConsoleWriteLine("8. Goblin");

             race = inputFieldHandler.ConsoleReadLine<RaceClass>();

            if (IsValidRaceClass(race))
            {
                typewriterEffect.ConsoleWriteLine("Invalid choice. Please choose a valid race number.");
                race = 0;
            }
                
                
       
        }

        CharacterClass charClass = 0;
        while (charClass == 0)
        {
             typewriterEffect.ConsoleWriteLine("Choose your class:");
             typewriterEffect.ConsoleWriteLine("1. Warrior");
             typewriterEffect.ConsoleWriteLine("2. Mage");
             typewriterEffect.ConsoleWriteLine("3. Rogue");
             typewriterEffect.ConsoleWriteLine("4. Archer");


            charClass = inputFieldHandler.ConsoleReadLine<CharacterClass>();

            if (IsValidCharacterClass(charClass))
            {
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please choose a valid class number.");
                charClass = 0;
            }
        }

         typewriterEffect.ConsoleWriteLine($"Welcome {name} the {race} {charClass} to the world of Verdantia!");

         typewriterEffect.ConsoleWriteLine("\nYou awaken in a dimly lit chamber, shackled and disoriented. Memories flood back, memories of betrayal and injustice. You, once a proud knight, were accused and convicted of a crime you didn't commit — the murder of an innocent. Now, the king summons you before him for your punishment.");

         typewriterEffect.ConsoleWriteLine("\nAs you stand before the throne, the king's voice echoes through the hall.");
         typewriterEffect.ConsoleWriteLine("You have been branded a disgrace, a traitor to the kingdom. But circumstances have changed. The land is in peril, ravaged by a knightly order led by the infamous Black Knight. They sow chaos and misery, leaving death and destruction in their wake.");

         typewriterEffect.ConsoleWriteLine("\nThe king offers you a chance for redemption. Assist him in dismantling this order, and your name will be cleared, your honor restored, and your freedom granted.");

         typewriterEffect.ConsoleWriteLine("\nWill you accept the king's quest? (Y/N)");

        string response = inputFieldHandler.ConsoleReadLine<string>();



        if (response.ToUpper() != "Y")
        {
             typewriterEffect.ConsoleWriteLine("You refused the king's offer. You are thrown back in jail and executed a year later. Game over!");
                GameOver();
        }

         typewriterEffect.ConsoleWriteLine("\nThe king nods, acknowledging your decision. He gestures for you to step closer, his voice low and urgent.");

         typewriterEffect.ConsoleWriteLine("Listen well, brave soul. The Black Knight is the leader of this nefarious order, but he is not alone. He commands four other knights, each with their own vile powers and armies. There's the Red Knight, the Blue Knight, the Green Knight, and the Yellow Knight.");

         typewriterEffect.ConsoleWriteLine("Together, they threaten the very fabric of our kingdom. It's up to you to put an end to their reign of terror and restore peace to Verdantia.");

         typewriterEffect.ConsoleWriteLine("Speak to the villagers in The Capital for information. Your journey begins there.");

        return new Player(name, race, charClass);
    }



    void Explore(Player player)
    {
         typewriterEffect.ConsoleWriteLine("Current Location: The Capital");
         typewriterEffect.ConsoleWriteLine("What would you like to visit?");
         typewriterEffect.ConsoleWriteLine("1. Blacksmith");
         typewriterEffect.ConsoleWriteLine("2. Potion Master");
         typewriterEffect.ConsoleWriteLine("3. Trade Master");
         typewriterEffect.ConsoleWriteLine("4. Tavern");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                VisitBlacksmith(player);
                break;
            case 2:
                VisitPotionMaster(player);
                break;
            case 3:
                VisitTradeMaster(player);
                break;
            case 4:
                VisitTavern(player);
                break;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void CheckInventory(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nInventory:");
         typewriterEffect.ConsoleWriteLine("Gear:");
        foreach (var item in gear)
        {
             typewriterEffect.ConsoleWriteLine($"{item.Key}: {item.Value} (Equipped)");
        }
    }

     void ViewQuests(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nQuests:");
         typewriterEffect.ConsoleWriteLine("- Help the king defeat the Black Knights order");
        if (spokenToNPCs.Contains("Barman"))
             typewriterEffect.ConsoleWriteLine("  [X] Speak to the barman");
        else
             typewriterEffect.ConsoleWriteLine("  [ ] Speak to the barman");
        if (spokenToNPCs.Contains("Mercenary"))
             typewriterEffect.ConsoleWriteLine("  [X] Speak to the mercenary for hire");
        else
             typewriterEffect.ConsoleWriteLine("  [ ] Speak to the mercenary for hire");
        if (spokenToNPCs.Contains("GangLeader"))
             typewriterEffect.ConsoleWriteLine("  [X] Speak to the local gang leader");
        else
             typewriterEffect.ConsoleWriteLine("  [ ] Speak to the local gang leader");
    }

     void VisitBlacksmith(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou enter the blacksmith's shop. What would you like to do?");
         typewriterEffect.ConsoleWriteLine("1. Buy Weapons");
         typewriterEffect.ConsoleWriteLine("2. Buy Armor");
         typewriterEffect.ConsoleWriteLine("0. Back");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                BuyWeapons(player);
                break;
            case 2:
                BuyArmor(player);
                break;
            case 0:
                return;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void BuyWeapons(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nWeapons for sale:");

        // Display available weapons based on player's class and tier
        switch (player.Character)
        {
            case CharacterClass.Warrior:
                 typewriterEffect.ConsoleWriteLine("1. Axe (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Mace (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Greatsword (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Mage:
                 typewriterEffect.ConsoleWriteLine("1. Staff (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Wand (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Grimoire (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Rogue:
                 typewriterEffect.ConsoleWriteLine("1. Dagger (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Shortbow (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Crossbow (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Archer:
                 typewriterEffect.ConsoleWriteLine("1. Shortbow (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Longbow (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Composite Bow (Tier 3) - 60 Gold");
                break;
            default:
                break;
        }

         typewriterEffect.ConsoleWriteLine("0. Back");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                BuyItem(player, "Axe", 20, 10);
                break;
            case 2:
                BuyItem(player, "Mace", 40, 20);
                break;
            case 3:
                BuyItem(player, "Greatsword", 60, 30);
                break;
            case 0:
                return;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void BuyArmor(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nArmor for sale:");

        // Display available armor based on player's class and tier
        switch (player.Character)
        {
            case CharacterClass.Warrior:
                 typewriterEffect.ConsoleWriteLine("1. Chainmail (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Splint Armor (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Plate Mail (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Mage:
                 typewriterEffect.ConsoleWriteLine("1. Robe (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Silk Robe (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Enchanted Robe (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Rogue:
                 typewriterEffect.ConsoleWriteLine("1. Leather Armor (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Studded Leather Armor (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Shadow Armor (Tier 3) - 60 Gold");
                break;
            case CharacterClass.Archer:
                 typewriterEffect.ConsoleWriteLine("1. Cloth Armor (Tier 1) - 20 Gold");
                 typewriterEffect.ConsoleWriteLine("2. Leather Armor (Tier 2) - 40 Gold");
                 typewriterEffect.ConsoleWriteLine("3. Elven Armor (Tier 3) - 60 Gold");
                break;
            default:
                break;
        }

         typewriterEffect.ConsoleWriteLine("0. Back");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                BuyItem(player, "Chainmail", 20, 10);
                break;
            case 2:
                BuyItem(player, "Splint Armor", 40, 20);
                break;
            case 3:
                BuyItem(player, "Plate Mail", 60, 30);
                break;
            case 0:
                return;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void VisitPotionMaster(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou visit the potion master's shop. What would you like to do?");
        // Implement potion master interactions
    }

     void VisitTradeMaster(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou visit the trade master's shop. What would you like to do?");
        // Implement trade master interactions
    }

     void VisitTavern(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou enter the tavern. Inside, you see a variety of patrons.");
         typewriterEffect.ConsoleWriteLine("Who would you like to speak to?");
         typewriterEffect.ConsoleWriteLine("1. Barman");
         typewriterEffect.ConsoleWriteLine("2. Mercenary for hire");
         typewriterEffect.ConsoleWriteLine("3. Local gang leader");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                SpeakToBarman(player);
                spokenToNPCs.Add("Barman");
                break;
            case 2:
                SpeakToMercenary(player);
                spokenToNPCs.Add("Mercenary");
                break;
            case 3:
                InterrogateGangLeader(player);
                spokenToNPCs.Add("GangLeader");
                break;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void SpeakToBarman(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou approach the barman and strike up a conversation.");
         typewriterEffect.ConsoleWriteLine("Barman: Welcome, traveler! What can I do for you?");
         typewriterEffect.ConsoleWriteLine("You: I seek information about the knights terrorizing the land. Have you heard anything?");
         typewriterEffect.ConsoleWriteLine("Barman: Ah, you must be talking about the Green Knight. Rumor has it he's been seen lurking in a cave just outside the city.");
         typewriterEffect.ConsoleWriteLine("You: Thank you for the information. I'll look into it.");

        spokenToNPCs.Add("Barman"); // Add this line to mark the barman as spoken to

        if (spokenToNPCs.Contains("Barman") && spokenToNPCs.Contains("Mercenary") && spokenToNPCs.Contains("GangLeader") && !chapter1Completed)
        {
            CompleteChapter(player);
        }
    }

     void SpeakToMercenary(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou approach a burly mercenary and inquire about the knights.");
         typewriterEffect.ConsoleWriteLine("Mercenary: You want information? Gotta pay up, pal.");
         typewriterEffect.ConsoleWriteLine("You: Fine, here's some gold. What do you know?");
         typewriterEffect.ConsoleWriteLine("Mercenary: I've heard whispers about the Green Knight. They say he's holed up in a cave not far from here.");
         typewriterEffect.ConsoleWriteLine("You: Thanks for the tip.");

        spokenToNPCs.Add("Mercenary"); // Add this line to mark the mercenary as spoken to

        if (spokenToNPCs.Contains("Barman") && spokenToNPCs.Contains("Mercenary") && spokenToNPCs.Contains("GangLeader") && !chapter1Completed)
        {
            CompleteChapter(player);
        }
    }

     void InterrogateGangLeader(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nYou confront the local gang leader and demand information.");
         typewriterEffect.ConsoleWriteLine("Gang Leader: Who do you think you are, coming in here and demanding answers?");
         typewriterEffect.ConsoleWriteLine("You: Someone who's not afraid to get what they want. Now talk.");
         typewriterEffect.ConsoleWriteLine("Gang Leader: Alright, alright. I've heard talk of the Green Knight hiding out in a cave nearby. Happy now?");

        spokenToNPCs.Add("GangLeader"); // Add this line to mark the gang leader as spoken to

        if (spokenToNPCs.Contains("Barman") && spokenToNPCs.Contains("Mercenary") && spokenToNPCs.Contains("GangLeader") && !chapter1Completed)
        {
            CompleteChapter(player);
        }
    }

     void CompleteChapter(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nChapter 1 completed!");

        // Award gear
        AwardGear(player);

        // Progress to next chapter
        chapter1Completed = true;

         typewriterEffect.ConsoleWriteLine("\nA commander of the king's guard approaches you.");

        switch (player.Character)
        {
            case CharacterClass.Warrior:
                gear.Add("Armor", "Plate Mail");
                gear.Add("Weapon", "Sword");
                 typewriterEffect.ConsoleWriteLine("Commander: As a token of the king's gratitude, please accept this level 1 plate mail and sword, suitable for a warrior.");
                break;
            case CharacterClass.Mage:
                gear.Add("Armor", "Robe");
                gear.Add("Weapon", "Staff");
                 typewriterEffect.ConsoleWriteLine("Commander: As a token of the king's gratitude, please accept this level 1 robe and staff, suitable for a mage.");
                break;
            case CharacterClass.Rogue:
                gear.Add("Armor", "Leather Armor");
                gear.Add("Weapon", "Dagger");
                 typewriterEffect.ConsoleWriteLine("Commander: As a token of the king's gratitude, please accept this level 1 leather armor and dagger, suitable for a rogue.");
                break;
            case CharacterClass.Archer:
                gear.Add("Armor", "Chainmail");
                gear.Add("Weapon", "Bow");
                 typewriterEffect.ConsoleWriteLine("Commander: As a token of the king's gratitude, please accept this level 1 chainmail and bow, suitable for an archer.");
                break;
            default:
                 typewriterEffect.ConsoleWriteLine("Commander: I'm sorry, but I have nothing to offer you.");
                break;
        }
    }

     void AwardGear(Player player)
    {
        // Award gear based on player's class
        // This method is now called only when a chapter is completed
    }

     void ViewInventory(Player player)
    {
         typewriterEffect.ConsoleWriteLine("\nInventory:");
         typewriterEffect.ConsoleWriteLine("Gear:");
        foreach (var item in gear)
        {
             typewriterEffect.ConsoleWriteLine($"{item.Key}: {item.Value}");
        }

         typewriterEffect.ConsoleWriteLine("\nWhat would you like to do?");
         typewriterEffect.ConsoleWriteLine("1. Equip/Unequip Items");
         typewriterEffect.ConsoleWriteLine("2. Back");

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        switch (choice)
        {
            case 1:
                EquipUnequipItems();
                break;
            case 2:
                // Return to main menu
                return;
            default:
                 typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
                break;
        }
    }

     void EquipUnequipItems()
    {
         typewriterEffect.ConsoleWriteLine("\nSelect an item to equip/unequip:");

        int count = 1;
        foreach (var item in gear)
        {
            string status = gear[item.Key].Contains("(Equipped)") ? "(Equipped)" : "";
             typewriterEffect.ConsoleWriteLine($"{count}. {item.Key}: {item.Value} {status}");
            count++;
        }

        int choice = inputFieldHandler.ConsoleReadLine<int>();

        if (choice <= gear.Count)
        {
            string itemKey = gear.Keys.ToArray()[choice - 1];
            if (gear[itemKey].Contains("(Equipped)"))
            {
                gear[itemKey] = gear[itemKey].Replace("(Equipped)", "").Trim();
                 typewriterEffect.ConsoleWriteLine($"{itemKey} is now unequipped.");
            }
            else
            {
                // First, unequip all other items of the same type
                foreach (var key in gear.Keys.ToList())
                {
                    if (gear[key].Contains(itemKey) && gear[key].Contains("(Equipped)"))
                    {
                        gear[key] = gear[key].Replace("(Equipped)", "").Trim();
                         typewriterEffect.ConsoleWriteLine($"{key} is now unequipped.");
                    }
                }
                gear[itemKey] += " (Equipped)";
                 typewriterEffect.ConsoleWriteLine($"{itemKey} is now equipped.");
            }
        }
        else
        {
             typewriterEffect.ConsoleWriteLine("Invalid choice. Please try again.");
        }
    }

     void BuyItem(Player player, string itemName, int goldCost, int tier)
    {
        if (player.Gold >= goldCost)
        {
            player.Gold -= goldCost;
             typewriterEffect.ConsoleWriteLine($"{itemName} purchased for {goldCost} gold.");
            switch (tier)
            {
                case 1:
                     typewriterEffect.ConsoleWriteLine("You acquired a Tier 1 item.");
                    break;
                case 2:
                     typewriterEffect.ConsoleWriteLine("You acquired a Tier 2 item.");
                    break;
                case 3:
                     typewriterEffect.ConsoleWriteLine("You acquired a Tier 3 item.");
                    break;
                default:
                    break;
            }
        }
        else
        {
             typewriterEffect.ConsoleWriteLine("You don't have enough gold to purchase this item.");
        }
    }

    public enum RaceClass
    {
        Human = 1,
        Orc = 2,
        Vampire = 3,
        Elf = 4,
        Dwarf = 5,
        Dragonborn = 6,
        Tiefling = 7,
        Goblin = 8
    }

    public enum CharacterClass
    {
        Warrior = 1,
        Mage = 2,
        Rogue = 3,
        Archer = 4
    }

    public class Player
    {
        public string Name { get; set; }
        public RaceClass Race { get; set; }
        public CharacterClass Character { get; set; }
        public int Health { get; set; }
        public int Gold { get; set; } // Added Gold property
        // Add more properties as needed

        public Player(string name, RaceClass raceClass, CharacterClass charClass)
        {
            Name = name;
            Race = raceClass;
            Character = charClass;
            Health = 100; // Initial health value
            Gold = 100; // Initial gold value
        }
    }



    public enum InputType
    {
        Integer,
        String,
        RaceClass,
        CharacterClass

    }


    public bool IsValidCharacterClass(CharacterClass charClass)
    {
        // Check if the value of charClass is a valid CharacterClass enum value
        return System.Enum.IsDefined(typeof(CharacterClass), charClass);
    }

    public bool IsValidRaceClass(RaceClass raceClass)
    {
        // Check if the value of raceClass is a valid RaceClass enum value
        return System.Enum.IsDefined(typeof(RaceClass), raceClass);
    }

    

}
