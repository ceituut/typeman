using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageWrong : MonoBehaviour
{
    [SerializeField] private LanguageUpdate languageUpdate;
    private void Awake() 
    {
        // Get Keyboard in the scene and it's languageUpdate component
    }
    public bool IsLanguageWrong(String lastInputChar)
    {
        bool keyFound = false;
        bool isLanguageWrong = false;
        KeyboardLayout currentLayout = languageUpdate.GetCurrentLayout;
        foreach (String keyString in currentLayout.GetPrimaryKeyList)
            if ( keyString == lastInputChar )
            {
                keyFound = true;
                break;
            }
        if ( !keyFound )
            foreach (String keyString in currentLayout.GetSecondaryKeyList)
                if ( keyString == lastInputChar )
                {
                    keyFound = true;
                    break;
                }
        isLanguageWrong = !keyFound;
        return isLanguageWrong;
    }
}