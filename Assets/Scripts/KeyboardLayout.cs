using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardLayout : ScriptableObject
{
    // Fields
    // Keyboard (without/with Shift key) string values 
    [SerializeField] protected List<string> primaryKeyList;
    [SerializeField] protected List<string> secondaryKeyList;
    // limited number of keys in each row
    protected List<int> limitedRows;

    // Properties
    public List<string> GetPrimaryKeyList { get => primaryKeyList;}
    public List<string> GetSecondaryKeyList { get => secondaryKeyList;}
    public List<int> GetLimitedRows { get => limitedRows;}

    // Methods
    public abstract void InitializeDefualt();
    public abstract void InitializeRowLimits();
}




[CreateAssetMenu(fileName="En-WinDesktop-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsDesktop")]
public class WindowsDesktop : KeyboardLayout
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
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu"," Ctrl"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("Backspace");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("Enter");
        int row3Limit = primaryKeyList.IndexOf(" Shift");
        int row4Limit = primaryKeyList.IndexOf(" Ctrl");
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}




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
        InitializeRowLimits();
    }
}




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
        InitializeRowLimits();
    }
}




[CreateAssetMenu(fileName="En-WinPortable3-104key-enterflat",
menuName="TypeMan/Keyboard/WindowsPortable3")]
public class WindowsPortable3 : WindowsPortable1
{
    private void Awake() {
        InitializeDefualt();
    }
}




[CreateAssetMenu(fileName="En-WinPocket1-104key-enterflat",
menuName="TypeMan/Keyboard/WinPocket1")]
public class WindowsPocket1 : WindowsPortable1
{
    private void Awake() {
        InitializeDefualt();
    }
}




[CreateAssetMenu(fileName="En-WinErgonomic1-104key-enterflat",
menuName="TypeMan/Keyboard/WinErgonomic1")]
public class WindowsErgonomic1 : WindowsDesktop
{
    private void Awake() {
        InitializeDefualt();
    }
}




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




[CreateAssetMenu(fileName="En-MacDesktop-104key-enterflat",
menuName="TypeMan/Keyboard/MacDesktop")]
public class MacDesktop : KeyboardLayout
{
    private void Awake()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","delete",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","return",
            "shift","z","x","c","v","b","n","m",",",".","/"," shift",
            "control","option","command","space","command","option"," control"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?"," shift",
            "control","option","command","space","command","option"," control"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("delete");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("return");
        int row3Limit = primaryKeyList.IndexOf(" shift");
        int row4Limit = primaryKeyList.IndexOf(" control");
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}




[CreateAssetMenu(fileName="En-MacPortable-104key-enterflat",
menuName="TypeMan/Keyboard/MacPortable")]
public class MacPortable : MacDesktop
{
    private void Awake()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","delete",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","return",
            "shift","z","x","c","v","b","n","m",",",".","/"," shift",
            "fn","control","option","command","space","command"," option"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?"," shift",
            "fn","control","option","command","space","command"," option"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("delete");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("return");
        int row3Limit = primaryKeyList.IndexOf(" shift");
        int row4Limit = primaryKeyList.IndexOf(" option");
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}