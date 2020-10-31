using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinErgonomic1-104key-enterflat",
menuName="TypeMan/Keyboard/WinErgonomic1")]
public class WindowsErgonomic1 : WindowsDesktop
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
            "Ctrl","Win","Alt","Space","AltGr","Menu"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Win","Alt","Space","AltGr","Menu"," Ctrl"
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
        SetWidthForSpecificKey("t", 1.8f);
        SetWidthForSpecificKey("g", 1.6f);
        SetWidthForSpecificKey("7", 1.7f);
        SetWidthForSpecificKey("h", 1.4f);
        SetWidthForSpecificKey("n", 2.1f);
        SetWidthForSpecificKey("Backspace", 2.2f);
        SetWidthForSpecificKey("Tab", 1.6f);
        SetWidthForSpecificKey("\\", 1.6f);
        SetWidthForSpecificKey("Caps Lock", 1.9f);
        SetWidthForSpecificKey("Enter", 2.35f);
        SetWidthForSpecificKey("Shift", 2.5f);
        SetWidthForSpecificKey(" Shift", 2.9f);
        SetWidthForSpecificKey("Ctrl", 1.5f);
        SetWidthForSpecificKey("Win", 2f);
        SetWidthForSpecificKey("Alt", 1.7f);
        SetWidthForSpecificKey("Space", 7.5f);
        SetWidthForSpecificKey("AltGr", 2.1f);
        SetWidthForSpecificKey("Menu", 2.3f);
        SetWidthForSpecificKey(" Ctrl", 2.2f);
    }
    public override void AdjustRows()
    {
        // Do nothing
    }
}
