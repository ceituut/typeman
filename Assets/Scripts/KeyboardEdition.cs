using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Keyboard-En-Win-Desktop-104-enter-flat",menuName="TypeMan/Keyboard")]
public class KeyboardEdition : ScriptableObject
{
    // Fields
        // Keyboard (without/with Shift key) string values 
    [SerializeField] private List<string> primaryKeyList;
    [SerializeField] private List<string> secondaryKeyList;
        // Type Definitions 
    private enum languages { English , Farsi };
    private enum osTypes { Wind , Mac };
    private enum keyboardTypes 
    { 
        Desktop , Ergonomic1 , Ergonomic2 , Portable1 , Portable2 , Portable3 , Pocket1
    };
    private enum numberOfKeysTypes { key104 , key105 , key107 };
    private enum enterTypes { flat , high , big };
        // Type fields
    [SerializeField] private languages languageType;
    [SerializeField] private osTypes currentOSType;
    [SerializeField] private keyboardTypes currentKeyboardTye;
    [SerializeField] private numberOfKeysTypes currentNumberOfKeys;
    [SerializeField] private enterTypes currentEnterType;
        // limited number of keys in each row
    private List<int> rowLimits;

    // Properties
        // Lists
    public List<string> PrimaryKeyList { get => primaryKeyList; set => primaryKeyList = value; }
    public List<string> SecondaryKeyList { get => secondaryKeyList; set => secondaryKeyList = value; }
    public List<int> GetRowLimits { get => rowLimits;}
        // Types
    private osTypes CurrentOSType { get => currentOSType; set => currentOSType = value; }
    private keyboardTypes CurrentKeyboardTye { get => currentKeyboardTye; set => currentKeyboardTye = value; }
    private numberOfKeysTypes CurrentNumberOfKeys { get => currentNumberOfKeys; set => currentNumberOfKeys = value; }
    private enterTypes CurrentEnterType { get => currentEnterType; set => currentEnterType = value; }

    // Methods
    private void Awake() 
    {
        rowLimits = new List<int>();
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/","Shift",
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu","Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?","Shift",
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu","Ctrl"
        };
        rowLimits.Add(14);
        rowLimits.Add(14);
        rowLimits.Add(13);
        rowLimits.Add(12);
        rowLimits.Add(8);
    }

    public void MakeIt105Key()
    {
        // After first Shift , Add \
    }
    public void MakeIt107Key()
    {
        // After first Shift , Add \
        // After / , Add a empty key
    }
}
