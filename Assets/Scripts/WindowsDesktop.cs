using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            "Ctrl","Win","Alt","Space","AltGr"," Win","Menu"," Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?"," Shift",
            "Ctrl","Win","Alt","Space","AltGr"," Win","Menu"," Ctrl"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"Backspace","\\","Enter"," Shift"," Ctrl"};
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
        SetWidthForSpecificKey("Ctrl", 1.5f);
        SetWidthForSpecificKey("Win", 0.9f);
        SetWidthForSpecificKey("Alt", 1.4f);
        SetWidthForSpecificKey("Space", 7.5f);
        SetWidthForSpecificKey("AltGr", 1.4f);
        SetWidthForSpecificKey(" Win", .9f);
        SetWidthForSpecificKey("Menu", 1f);
        SetWidthForSpecificKey(" Ctrl", 1.5f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRow("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRow("Tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRow("Caps Lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRow("Shift",endStringInRows[3]);
        FixLastKeyWidthOfThisRow("Ctrl",endStringInRows[4]);
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("Shift");
        string newPrimaryKey = "\\";
        string newSecondaryKey = "|";
        UpdateKey(insertionIndex , primaryKeyList[insertionIndex] , secondaryKeyList[insertionIndex] , keyWidthList[insertionIndex] - 1.2f);
        InsertNewKey(insertionIndex + 1 , newPrimaryKey , newSecondaryKey , 1f);
        InitializeEndIndexInRows();
    }
    public override void MakeIt107Key()
    {
        MakeIt105Key();
        int insertionIndex = primaryKeyList.IndexOf("/");
        string newPrimaryKey = "   ";
        string newSecondaryKey = "   ";
        UpdateKey(insertionIndex + 1 , primaryKeyList[insertionIndex + 1] , secondaryKeyList[insertionIndex + 1] , keyWidthList[insertionIndex + 1] - 1.2f);
        InsertNewKey(insertionIndex + 1 , newPrimaryKey , newSecondaryKey , 1f);
        InitializeEndIndexInRows();
    }
    public override void MakeEnterHigh()
    {
        int firstIndex = primaryKeyList.IndexOf("Enter");
        int secondIndex = primaryKeyList.IndexOf("\\");
        InsertNewKey(firstIndex , "\\" , "|" , 1f);
        UpdateKey(firstIndex + 1 , "  " , "  " , keyWidthList[firstIndex + 1]);
        UpdateKey(secondIndex , "Enter" , "Enter" , keyWidthList[secondIndex]);
        endStringInRows[1] = "Enter";
        endStringInRows[2] = "  ";
        InitializeEndIndexInRows();
    }
    public override void MakeEnterBig()
    {
        int targetIndex = primaryKeyList.IndexOf("\\");
        int insertionIndex = primaryKeyList.IndexOf("=") + 1;
        UpdateKey(targetIndex , "  " , "  " , keyWidthList[targetIndex]);
        InsertNewKey(insertionIndex , "\\" , "|" , 1f);
        endStringInRows[1] = "  ";
        InitializeEndIndexInRows();
    }
}
