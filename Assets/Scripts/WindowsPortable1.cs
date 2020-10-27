using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinPortable1-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsPortable1")]
public class WindowsPortable1 : WindowsDesktop
{
    private void Awake() {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/"," Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Prnt Scr"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Prnt Scr"," Ctrl"
        };
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        InitializeRowWidthList();
    }
    public override void InitializeRowWidthList()
    {
        AddRowWidthMembers();
    }
    public override void InitializeKeyWidthList()
    {
        AddKeyWidthMembers();
        SetWidthForSpecificKey("Backspace", 2.2f);
        SetWidthForSpecificKey("Tab", 1.6f);
        SetWidthForSpecificKey("\\", 1.6f);
        SetWidthForSpecificKey("Caps Lock", 1.9f);
        SetWidthForSpecificKey("Enter", 2.35f);
        SetWidthForSpecificKey("Shift", 2f);
        SetWidthForSpecificKey(" Shift", 3.2f);
        SetWidthForSpecificKey("Ctrl", 1f);
        SetWidthForSpecificKey("Win", 1f);
        SetWidthForSpecificKey("Fn", 1f);
        SetWidthForSpecificKey("Alt", 1f);
        SetWidthForSpecificKey("Space", 5f);
        SetWidthForSpecificKey("AltGr", 1f);
        SetWidthForSpecificKey("Prnt Scr", 1f);
        SetWidthForSpecificKey(" Ctrl", 1f);

        // FixLastKeyWidthOfThisRow("Tab","\\");
        // FixLastKeyWidthOfThisRow("Caps Lock","Enter");
        // FixLastKeyWidthOfThisRow("Shift"," Shift");
        // FixLastKeyWidthOfThisRow("Ctrl"," Ctrl");
    }
}