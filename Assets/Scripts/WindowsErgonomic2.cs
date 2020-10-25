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
            "Ctrl","Alt","Backspace","Delete","Enter","Space","AltGr"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "Backspace","!","@","#","$","%","^","&","*","(",")","_","+",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}",
            "Caps Lock","`","A","S","D","F","G","H","J","K","L",":","\"","|",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Alt","Backspace","Delete","Enter","Space","AltGr"," Ctrl"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("=");
        int row1Limit = primaryKeyList.IndexOf("]");
        int row2Limit = primaryKeyList.IndexOf("\\");
        int row3Limit = primaryKeyList.IndexOf(" Shift");
        int row4Limit = primaryKeyList.IndexOf(" Ctrl");
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}