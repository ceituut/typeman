using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageWrong : MonoBehaviour
{
    private Dictionary<string,bool> primaryKeyChecker;
    private Dictionary<string,bool> secondaryKeyChecker;

    /// convert it to a normal class not component
    //////// a character typing problem : ی is not ي .
    /////// In unity editor when press ی , typed ي.
    private void Update() 
    {
        Debug.Log("g typed , is language wrong:" + IsLanguageWrong("g"));
        Debug.Log("ی typed , is language wrong:" + IsLanguageWrong("ی"));
    }
    public void UpdateKeyCheckers(KeyboardLayout currentLayout)
    {
        primaryKeyChecker = new Dictionary<string, bool>();
        secondaryKeyChecker = new Dictionary<string, bool>();
        bool isThisKeyExists;
        foreach ( string keyString in currentLayout.GetPrimaryKeyList)
        {
            isThisKeyExists = false;
            primaryKeyChecker.TryGetValue( keyString , out isThisKeyExists);
            if ( !isThisKeyExists )
                primaryKeyChecker.Add( keyString , true);
        }
        foreach ( string keyString in currentLayout.GetSecondaryKeyList)
        {
            isThisKeyExists = false;
            secondaryKeyChecker.TryGetValue( keyString , out isThisKeyExists);
            if ( !isThisKeyExists )
                secondaryKeyChecker.Add( keyString , true);
        }
    }
    public bool IsLanguageWrong(string lastInputChar)
    {
        bool keyFound = false;
        bool isLanguageWrong = false;
        primaryKeyChecker.TryGetValue(lastInputChar, out keyFound);
        if ( !keyFound )
            secondaryKeyChecker.TryGetValue(lastInputChar, out keyFound);
        isLanguageWrong = !keyFound;
        return isLanguageWrong;
    }
    // public bool IsLanguageWrong(string lastInputChar)
    // {
    //     bool keyFound = false;
    //     bool isLanguageWrong = false;
    //     KeyboardLayout currentLayout = languageUpdate.GetCurrentLayout;
    //     foreach (String keyString in currentLayout.GetPrimaryKeyList)
    //         if ( keyString == lastInputChar )
    //         {
    //             keyFound = true;
    //             break;
    //         }
    //     if ( !keyFound )
    //         foreach (String keyString in currentLayout.GetSecondaryKeyList)
    //             if ( keyString == lastInputChar )
    //             {
    //                 keyFound = true;
    //                 break;
    //             }
    //     isLanguageWrong = !keyFound;
    //     return isLanguageWrong;
    // }
}