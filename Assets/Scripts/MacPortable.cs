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
        InitializeEndIndexInRows();
    }
    public override void InitializeEndIndexInRows()
    {
        int row0Limit = primaryKeyList.IndexOf("delete");
        int row1Limit = primaryKeyList.IndexOf("\\");
        int row2Limit = primaryKeyList.IndexOf("return");
        int row3Limit = primaryKeyList.IndexOf(" shift");
        int row4Limit = primaryKeyList.IndexOf(" option");
        endIndexInRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}