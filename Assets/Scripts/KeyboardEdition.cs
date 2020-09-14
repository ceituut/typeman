using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Keyboard-En-WinDesktop-104key-enterflat",menuName="TypeMan/Keyboard")]
public class KeyboardEdition : ScriptableObject
{
    // Fields
        // Keyboard object
    private Keyboard keyboard;
        // Keyboard (without/with Shift key) string values 
    [SerializeField] private List<string> primaryKeyList;
    [SerializeField] private List<string> secondaryKeyList;
        // Type fields
    [SerializeField] private KeyboardDef.languages languageType;
    [SerializeField] private KeyboardDef.keyboardTypes currentKeyboardType;
    [SerializeField] private KeyboardDef.numberOfKeysTypes currentNumberOfKeys;
    [SerializeField] private KeyboardDef.enterTypes currentEnterType;
        // limited number of keys in each row
    private List<int> rowLimits;

    // Properties
        // Lists
    public List<string> PrimaryKeyList { get => primaryKeyList; set => primaryKeyList = value; }
    public List<string> SecondaryKeyList { get => secondaryKeyList; set => secondaryKeyList = value; }
    public List<int> GetRowLimits { get => rowLimits;}
        // Types
    private KeyboardDef.languages LanguageType { get => languageType; set => languageType = value; }
    private KeyboardDef.keyboardTypes CurrentKeyboardType 
    { 
        get { return currentKeyboardType;} 
        set
        {
            UpdateKeyboardType(value);
            currentKeyboardType = value;
        }
    }
    private KeyboardDef.numberOfKeysTypes CurrentNumberOfKeys 
    {
        get { return currentNumberOfKeys;} 
        set
        {
            UpdateKeys(value,currentEnterType);
            rowLimits = keyboard.GetLimitedRows;
            currentNumberOfKeys = value;
        }
    }
    private KeyboardDef.enterTypes CurrentEnterType
    {
        get { return currentEnterType; }
        set 
        {
            UpdateKeys(currentNumberOfKeys,value);
            rowLimits = keyboard.GetLimitedRows;
            currentEnterType = value;
        }
    }
    // Methods
    private void Awake() 
    {
        InitializeDefaultEdition();
    }
    private void InitializeDefaultEdition()
    {
        InitializeTypes();
        InitializeKeyLists();
        rowLimits = keyboard.GetLimitedRows;
    }
    private void InitializeKeyLists()
    {
        keyboard = new WinDesktop();
        keyboard.MakeIt104Key();
        keyboard.MakeEnterFlat();
        primaryKeyList = keyboard.GetPrimaryKeyList;
        secondaryKeyList = keyboard.GetSecondaryKeyList;
    }
    private void InitializeTypes()
    {
        languageType = KeyboardDef.languages.English;
        CurrentKeyboardType = KeyboardDef.keyboardTypes.WindowsDesktop;
        CurrentNumberOfKeys = KeyboardDef.numberOfKeysTypes.key104;
        CurrentEnterType = KeyboardDef.enterTypes.flat;
    }
    private void UpdateNumberOfKeys(KeyboardDef.numberOfKeysTypes thisNumberOfKeysType)
    {
        switch (thisNumberOfKeysType)
        {
            case KeyboardDef.numberOfKeysTypes.key105 :
                keyboard.MakeIt105Key();
                break;
            case KeyboardDef.numberOfKeysTypes.key107 :
                keyboard.MakeIt107Key();
                break;
            default:
                break;
        }
    }
    private void UpdateEnterTypes(KeyboardDef.enterTypes thisEnterType)
    {
        switch (thisEnterType)
        {
            case KeyboardDef.enterTypes.high :
                keyboard.MakeEnterHigh();
                break;
            case KeyboardDef.enterTypes.big :
                keyboard.MakeEnterBig();
                break;
            default:
                break;
        }

    }
    private void UpdateKeys(KeyboardDef.numberOfKeysTypes thisNumberOfKeysType , KeyboardDef.enterTypes thisEnterType)
    {
        bool is104Keys = ( thisNumberOfKeysType == KeyboardDef.numberOfKeysTypes.key104 );
        bool isEnterFlat = ( thisEnterType == KeyboardDef.enterTypes.flat );
        bool isNeedTwoInitialization = (is104Keys && isEnterFlat);
        if ( isNeedTwoInitialization )
        {
            keyboard.InitializeDefualt();
        }
        else
        {
            keyboard.InitializeDefualt();
            UpdateNumberOfKeys(thisNumberOfKeysType);
            UpdateEnterTypes(thisEnterType);
        }
    }
    private void UpdateKeyboardType(KeyboardDef.keyboardTypes thisKeyboardType)
    {
        switch (thisKeyboardType)
        {
            case KeyboardDef.keyboardTypes.WindowsDesktop :
                {
                    keyboard = new WinDesktop();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsPortable1 :
                {
                    keyboard = new WindPortable1();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsPortable2 :
                {
                    keyboard = new WindPortable2();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsPortable3 :
                {
                    keyboard = new WindPortable3();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsErgonomic1 :
                {
                    keyboard = new WinErgonomic1();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsErgonomic2 :
                {
                    keyboard = new WinErgonomic2();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.WindowsPocket1 :
                {
                    keyboard = new WindPocket1();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.MacDesktop :
                {
                    keyboard = new MacDesktop();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            case KeyboardDef.keyboardTypes.MacPortable :
                {
                    keyboard = new MacPortable();
                    keyboard.MakeIt104Key();
                    keyboard.MakeEnterFlat();
                    primaryKeyList = keyboard.GetPrimaryKeyList;
                    secondaryKeyList = keyboard.GetSecondaryKeyList; 
                    break;
                }
            default:
                break;
        }

        // test //////////////////////////
        //////////////////
        ////////
        primaryKeyList.RemoveRange(0,30);
    }
}
