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
        InitializeEndIndexInRows();
    }
}
