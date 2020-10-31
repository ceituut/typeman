using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="En-WinErgonomic2-104key-enterflat",
menuName="TypeMan/Keyboard/WinErgonomic2")]
public class WindowsErgonomic2 : WindowsDesktop
{
    private void Awake() {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "Backspace","1","2","3","4","5","6","7","8","9","0","-","=",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]",
            "Caps Lock","`","a","s","d","f","g","h","j","k","l",";","'","\\",
            "Shift","z","x","c","v","b","n","m",",",".","/"," Shift",
            "Ctrl","Alt"," Backspace","Delete","Enter","Space","AltGr"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "Backspace","!","@","#","$","%","^","&","*","(",")","_","+",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}",
            "Caps Lock","`","A","S","D","F","G","H","J","K","L",":","\"","|",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Alt"," Backspace","Delete","Enter","Space","AltGr"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"=","]","\\"," Shift"," Ctrl"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        SetWidthForSpecificKey("Backspace", 2.2f);
        SetWidthForSpecificKey("Tab", 2.2f);
        SetWidthForSpecificKey("\\", 1f);
        SetWidthForSpecificKey("Caps Lock", 1f);
        SetWidthForSpecificKey("Enter", 1.7f);
        SetWidthForSpecificKey(" Backspace", 1.7f);
        SetWidthForSpecificKey("Delete", 1.7f);
        SetWidthForSpecificKey("Shift", 2.2f);
        SetWidthForSpecificKey(" Shift", 2.2f);
        SetWidthForSpecificKey("Ctrl", 2.2f);
        SetWidthForSpecificKey("Alt", 1.6f);
        SetWidthForSpecificKey("Space", 1.7f);
        SetWidthForSpecificKey("AltGr", 1.6f);
        SetWidthForSpecificKey(" Ctrl", 2.2f);
    }
    public override void AdjustRows()
    {
        // Do nothing
    }
    public override void MakeEnterHigh()
    {
        // Do nothing
    }
    public override void MakeEnterBig()
    {
        // Do nothing
    }

}