using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Keyboard",menuName="TypeMan/Keyboard")]
public class KeyboardEdition : ScriptableObject
{
    // Fields
    [SerializeField] private List<string> primaryKeyList;
    [SerializeField] private List<string> secondaryKeyList;

    public List<Row> myKeyboardRows;
    public Row myRow;

    private List<List<Key>> keyboardRows;

    // Please update each row inside primary-secondary sets.
    // Properties

    public List<string> PrimaryKeyList
    {
        get { return primaryKeyList; }
        set
        {
            
        }
    }
    public List<string> SecondaryKeyList
    {
        get { return secondaryKeyList; }
        set
        {

        }

    }

    private void OnEnable() {
        myRow = new Row();
        myRow.primaryKeyValue = new List<string>         
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace"
        };
        myRow.secondaryKeyValue = new List<string>         
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace"
        };
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","enter",
            "shift","z","x","c","v","b","n","m",",",".","/","shift",
            "ctrl","fn","windows","alt","space","alt","option","ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","enter",
            "shift","Z","X","C","V","B","N","M","<",">","?","shift",
            "ctrl","fn","windows","alt","space","alt","option","ctrl"
        };
    }
    private void Awake() 
    {
        // InitializeDefaultKeyboard();
        myRow = new Row();
        myRow.primaryKeyValue = new List<string>         
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace"
        };
        myRow.secondaryKeyValue = new List<string>         
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace"
        };
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","enter",
            "shift","z","x","c","v","b","n","m",",",".","/","shift",
            "ctrl","fn","windows","alt","space","alt","option","ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","enter",
            "shift","Z","X","C","V","B","N","M","<",">","?","shift",
            "ctrl","fn","windows","alt","space","alt","option","ctrl"
        };
    }
    // private void InitializeDefaultKeyboard()
    // {
    //     InitializeRow(new List<Key>() , 14);
    //     InitializeRow(row2 , 14);
    //     InitializeRow(row3 , 14);
    //     InitializeRow(row4 , 12);
    //     InitializeRow(row5 , 8);
    // }
    // private void InitializeRow(List<Key> thisRow , int numberOfKeys)
    // {
    //     Key newKey;
    //     int currentIndex = keyboardRows.Count - 1;
    //     int previousIndex = GetLastIndexOfPreviousRow(currentIndex);
    //     int startKeyIndex = lastIndex * numberOfKeys;
    //     keyboardRows.Add(thisRow);
    //     for (int index = ; index < numberOfKeys ; index++)
    //     {
    //         newKey = new Key();
    //         newKey.KeyPrimaryValue = 
    //         thisRow.Add(newKey);
    //     }
    // }
    // private int GetLastIndexOfPreviousRow(int currentRowIndex)
    // {
    //     if (currentRowIndex != 0)
    //         return currentRowIndex - 1;
    //     else
    //         return 0;
    // }
    // private int GetStartIndexOfRow()
    // {
    //     int startKeyIndex = 0;
    //     if (keyboardRows.Count == 0)
    //         return startKeyIndex;
    //     int lastKeyIndex = keyboardRows[keyboardRows.Count -1].Count - 1;
    //     for (int currentIndex = lastKeyIndex; currentIndex != -1 ; currentIndex--)
    //     {
    //         startKeyIndex = keyboardRows.Count
    //     }
    //     return startKeyIndex;
    // }

    public void MakeIt105Key()
    {

    }
    public void MakeIt107Key()
    {

    }
}
