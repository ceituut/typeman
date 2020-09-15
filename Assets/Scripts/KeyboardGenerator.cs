using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Just use it for creating keyboard in edit mode
// Attach it to keyboard Object
// It will generate all keys
[ExecuteInEditMode]
public class KeyboardGenerator : MonoBehaviour
{
    [SerializeField] private GameObject keyGameObject;
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private List<int> rowLimits;
    // Types
    [SerializeField] private KeyboardDef.keyboardTypes currentKeyboardType;
    [SerializeField] private KeyboardDef.numberOfKeysTypes currentNumberOfKeys;
    [SerializeField] private KeyboardDef.enterTypes currentEnterType; 

    // Properties
    public KeyboardDef.keyboardTypes CurrentKeyboardType 
    { 
        get { return currentKeyboardType;} 
        set
        {
            // UpdateKeyboardType(value);
            // currentKeyboardType = value;
        }
    }
    public KeyboardDef.numberOfKeysTypes CurrentNumberOfKeys 
    {
        get { return currentNumberOfKeys;} 
        set
        {
            UpdateKeys(value,currentEnterType);
            rowLimits = keyboard.GetLimitedRows;
            currentNumberOfKeys = value;
        }
    }
    private void Start() 
    {
        GameObject go;
        foreach(string primaryValue in keyboard.GetPrimaryKeyList)
        {
            go = GameObject.Instantiate(keyGameObject) as GameObject;
            go.transform.parent = gameObject.transform;
            go.name = primaryValue;
            go.GetComponent<Key>().KeyPrimaryValue = primaryValue;
            go.GetComponentInChildren<Text>().text = primaryValue;
            go.GetComponentInChildren<RectTransform>().localScale = Vector3.one;
        }
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
}
