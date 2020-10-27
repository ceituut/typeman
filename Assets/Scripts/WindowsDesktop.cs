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
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        InitializeRowWidthList();
    }
    public override void InitializeEndIndexInRows()
    {
        int row0Limit = primaryKeyList.IndexOf("Backspace");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("Enter");
        int row3Limit = primaryKeyList.IndexOf(" Shift");
        int row4Limit = primaryKeyList.IndexOf(" Ctrl");
        endIndexInRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
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
        SetWidthForSpecificKey("Shift", 2.5f);
        SetWidthForSpecificKey(" Shift", 2.9f);
        SetWidthForSpecificKey("Ctrl", 1.5f);
        SetWidthForSpecificKey("Win", 0.9f);
        SetWidthForSpecificKey("Alt", 1.4f);
        SetWidthForSpecificKey("Space", 7.5f);
        SetWidthForSpecificKey("AltGr", 1.4f);
        SetWidthForSpecificKey("Win", .9f);
        SetWidthForSpecificKey("Menu", 1f);
        SetWidthForSpecificKey(" Ctrl", 1.5f);

        keySpace = 0.2f;
        FixLastKeyWidthOfThisRow("Tab","\\");
        FixLastKeyWidthOfThisRow("Caps Lock","Enter");
        FixLastKeyWidthOfThisRow("Shift"," Shift");
        FixLastKeyWidthOfThisRow("Ctrl"," Ctrl");
    }


    public override void MakeIt104Key()
    {
        InitializeDefualt();
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("Shift");
        string newPrimaryKey = "\\";
        string newSecondaryKey = "|";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
        // Update row limits
        endIndexInRows[4] += 1;
    }
    public override void MakeIt107Key()
    {
        MakeIt105Key();
        int insertionIndex = primaryKeyList.IndexOf("/");
        string newPrimaryKey = "   ";
        string newSecondaryKey = "   ";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
        // Update row limits
        endIndexInRows[4] += 1;
    }
    public override void MakeEnterFlat()
    {
        InitializeDefualt();
    }
    public override void MakeEnterHigh()
    {
        int firstIndex = primaryKeyList.IndexOf("Enter");
        int secondIndex = primaryKeyList.IndexOf("\\");
        // Swap primary keys
        string tempKey = primaryKeyList[firstIndex];
        primaryKeyList[firstIndex] = primaryKeyList[secondIndex];
        primaryKeyList[secondIndex] = tempKey;
        // Swap secondary keys
        tempKey = secondaryKeyList[firstIndex];
        secondaryKeyList[firstIndex] = secondaryKeyList[secondIndex];
        secondaryKeyList[secondIndex] = tempKey;
    }
    public override void MakeEnterBig()
    {
        MakeEnterHigh();
        int insertionIndex = primaryKeyList.IndexOf("=");
        // Remove primary & secondary string of target key
        primaryKeyList.Remove("\\");
        secondaryKeyList.Remove("|");
        // Insert them after "=" key
        primaryKeyList.Insert(insertionIndex,"\\");
        secondaryKeyList.Insert(insertionIndex,"|");
        // Update row limits
        endIndexInRows[0] += 1;
        endIndexInRows[2] -= 1;
    }
}
