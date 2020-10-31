using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            "fn","control","option","command","space"," command"," option"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?"," shift",
            "fn","control","option","command","space"," command"," option"
        };
        InitializeEndStringInRows();
        InitializeEndIndexInRows();
        InitializeKeyWidthList();
        CalcTypicalRowWidth();
    }
    protected override void InitializeEndStringInRows()
    {
        endStringInRows = new List<string>
        {"delete","\\","return"," shift"," option"};
    }
    protected override void InitializeKeyWidthList()
    {
        keySpace = 0.2f;
        AddKeyWidthMembers();
        SetWidthForSpecificKey("delete", 1.5f);
        SetWidthForSpecificKey("tab", 1.6f);
        SetWidthForSpecificKey("\\", 0.9f);
        SetWidthForSpecificKey("caps lock", 2f);
        SetWidthForSpecificKey("return", 1.8f);
        SetWidthForSpecificKey("shift", 2.6f);
        SetWidthForSpecificKey(" shift", 2.5f);
        SetWidthForSpecificKey("fn", 1f);
        SetWidthForSpecificKey("control", 1f);
        SetWidthForSpecificKey("option", 1f);
        SetWidthForSpecificKey("command", 1.4f);
        SetWidthForSpecificKey("space", 5.8f);
        SetWidthForSpecificKey(" command", 1.4f);
        SetWidthForSpecificKey(" option", 1f);
    }
    public override void AdjustRows()
    {
        FixLastKeyWidthOfThisRow("`" , endStringInRows[0]);
        FixLastKeyWidthOfThisRow("tab",endStringInRows[1]);
        FixLastKeyWidthOfThisRow("caps lock",endStringInRows[2]);
        FixLastKeyWidthOfThisRow("shift",endStringInRows[3]);
    }
}