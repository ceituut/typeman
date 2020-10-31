using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinPortable2-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsPortable2")]
public class WindowsPortable2 : WindowsDesktop
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
            "Ctrl","Fn","Win","Alt","Space","AltGr"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        SetWidthForSpecificKey("Backspace", 2.2f);
        SetWidthForSpecificKey("Tab", 1.6f);
        SetWidthForSpecificKey("\\", 1.6f);
        SetWidthForSpecificKey("Caps Lock", 1.9f);
        SetWidthForSpecificKey("Enter", 2.35f);
        SetWidthForSpecificKey("Shift", 2.5f);
        SetWidthForSpecificKey(" Shift", 2.9f);
        SetWidthForSpecificKey("Ctrl", 1.6f);
        SetWidthForSpecificKey("Fn", 1f);
        SetWidthForSpecificKey("Win", 1f);
        SetWidthForSpecificKey("Alt", 1.3f);
        SetWidthForSpecificKey("Space", 5.6f);
        SetWidthForSpecificKey("AltGr", 1.1f);
        SetWidthForSpecificKey(" Ctrl", 1f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRow("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRow("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRow("Caps Lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRow("Shift",endStringInRows[3]);
    }
}
