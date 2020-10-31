using System.Collections;
using System.Collections.Generic;
using UnityEngine;


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
            "control","option","command","space"," command"," option"," control"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?"," shift",
            "control","option","command","space"," command"," option"," control"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"delete","\\","return"," shift"," control"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        SetWidthForSpecificKey("delete", 2.2f);
        SetWidthForSpecificKey("tab", 1.6f);
        SetWidthForSpecificKey("\\", 1.6f);
        SetWidthForSpecificKey("caps lock", 1.8f);
        SetWidthForSpecificKey("return", 2.45f);
        SetWidthForSpecificKey("shift", 2.5f);
        SetWidthForSpecificKey(" shift", 2.9f);
        SetWidthForSpecificKey("control", 1.5f);
        SetWidthForSpecificKey("option", 1.4f);
        SetWidthForSpecificKey("command", 1.6f);
        SetWidthForSpecificKey("space", 7.6f);
        SetWidthForSpecificKey(" command", 1.6f);
        SetWidthForSpecificKey(" option", 1.4f);
        SetWidthForSpecificKey(" control", 1.5f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRow("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRow("tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRow("caps lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRow("shift",endStringInRows[3]);
        FixLastKeyWidthOfThisRow("control",endStringInRows[4]);
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("shift");
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
        int firstIndex = primaryKeyList.IndexOf("return");
        int secondIndex = primaryKeyList.IndexOf("\\");
        InsertNewKey(firstIndex , "\\" , "|" , 1f);
        UpdateKey(firstIndex + 1 , "  " , "  " , keyWidthList[firstIndex + 1]);
        UpdateKey(secondIndex , "return" , "return" , keyWidthList[secondIndex]);
        endStringInRows[1] = "return";
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
