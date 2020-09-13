using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Keyboard",menuName="TypeMan/Keyboard")]
public class KeyboardEdition : ScriptableObject
{
    // Fields
    [SerializeField] private List<string> primaryKeyList;
    [SerializeField] private List<string> secondaryKeyList;

    // Please update each row inside primary-secondary sets.
    // Properties

    public List<string> PrimaryKeyList
    {
        get { return primaryKeyList; }
        set
        {
            primaryKeyList = value;
        }
    }
    public List<string> SecondaryKeyList
    {
        get { return secondaryKeyList; }
        set
        {
            secondaryKeyList = value;
        }

    }

    private void Awake() 
    {
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

    public void MakeIt105Key()
    {

    }
    public void MakeIt107Key()
    {

    }
}
