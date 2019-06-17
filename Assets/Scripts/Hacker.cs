using UnityEngine;

public class Hacker : MonoBehaviour
{
    const string menu_hint = " type menu to go back";
    //game configuration data
    string[] level1Passwords = { "code", "home", "room", "pen", "sleep", "car" };
    string[] level2Passwords = { "mozzarella", "cocumber", "rabbit", "vacation", "watermelon" };
    string[] level3Passwords = { "risotto", "prisoner", "tortellini", "working" };

    //game state
    int level;
    enum Screen { MainMenu, Password, Win };
    private Screen currentScreen;

    private string password;

    void show_introduction_menu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("what are you doing here ?");
        Terminal.WriteLine("-----------------------------------");
        Terminal.WriteLine("Press 1 for the first level");
        Terminal.WriteLine("Press 2 for the second level");
        Terminal.WriteLine("Press 3 for last level :(");
        Terminal.WriteLine("Enter :");
    }



    void OnUserInput(string input)
    {
        if (input == "menu")
        {
            show_introduction_menu();
        }
        else if(input == "quit" || input == "close" || input == "exit")
        {
            Terminal.WriteLine("If on the web close the tab");
            Application.Quit();
        }
        else if(currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if(currentScreen == Screen.Password)
        {
            CheckPassword(input);
        }
    }


    private void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2" || input == "3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "007")
        {
            Terminal.WriteLine(" :( ");
        }
        else
        {
            Terminal.WriteLine("select correct input");
            Terminal.WriteLine(menu_hint);
        }


    }
    private void AskForPassword()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(" You have chosen level " + level);
        Terminal.WriteLine(" Enter your password, hint: " + password.Anagram());

    }

    private void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                int index1 = Random.Range(0, level1Passwords.Length);
                password = level1Passwords[index1];
                break;
            case 2:
                int index2 = Random.Range(0, level2Passwords.Length);
                password = level2Passwords[index2];
                break;
            case 3:
                int index3 = Random.Range(0, level3Passwords.Length);
                password = level3Passwords[index3];
                break;
            default:
                Debug.LogError("invalid error");
                break;
        }
    }

    private void CheckPassword(string input)
    {
        if(input == password)
        {
            Terminal.WriteLine("Well done");
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }

    }



    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

    private void ShowLevelReward()
    {

        switch(level)
        {
            case 1:
                Terminal.WriteLine("good.. ");
                Terminal.WriteLine("but this was easy.. ");
                Terminal.WriteLine(@"
+---+  +---+
 XX     XX


  +-----+ 
"
                );
                break;
            case 2:
                Terminal.WriteLine("very good.. ");
                Terminal.WriteLine("try the last one.. ");
                Terminal.WriteLine(@"
 +--+ +---+
 +--------+
 |  | |   |
 +----+---+
    ++

+--------+ 
"
                );
                break;
            case 3:
                Terminal.WriteLine("wow.. ");
                Terminal.WriteLine(@"
   +--+-+    +-+-+
      |        |
      +       ++
+                    +
|                    |
|                    |
+--------------------+
"
                );
                break;
            default:
                Debug.LogError("invalid error");
                break;
        }
        Terminal.WriteLine(menu_hint);
    }





    // Start is called before the first frame update
    void Start()
    {
        show_introduction_menu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
