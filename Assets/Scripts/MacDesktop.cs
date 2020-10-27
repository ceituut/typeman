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
        InitializeEndIndexInRows();
    }
    public override void InitializeEndIndexInRows()
    {
        int row0Limit = primaryKeyList.IndexOf("delete");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("return");
        int row3Limit = primaryKeyList.IndexOf(" shift");
        int row4Limit = primaryKeyList.IndexOf(" control");
        endIndexInRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public override void InitializeRowWidthList()
    {
    }
    public override void InitializeKeyWidthList()
    {
    }



    public override void MakeIt104Key()
    {
        InitializeDefualt();
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("shift");
        string newPrimaryKey = "\\";
        string newSecondaryKey = "|";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
    }
    public override void MakeIt107Key()
    {
        MakeIt105Key();
        int insertionIndex = primaryKeyList.IndexOf("/");
        string newPrimaryKey = "   ";
        string newSecondaryKey = "   ";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
    }
    public override void MakeEnterFlat()
    {
        InitializeDefualt();
    }
    public override void MakeEnterHigh()
    {
        int firstIndex = primaryKeyList.IndexOf("return");
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
        // Insert them after = key
        primaryKeyList.Insert(insertionIndex,"\\");
        secondaryKeyList.Insert(insertionIndex,"|");
    }
}
