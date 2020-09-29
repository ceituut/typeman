using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static KeyboardDef;


// First , Create all Keyboards in other languages for specific KeyboardLayout
// for example for WindowsDesktop KeyboardLayout
// Then , Add all These keyboards inside This Asset for that KeyboardLayout
[CreateAssetMenu(fileName="WindowsDesktopLanguages",
menuName="TypeMan/Keyboard/LayoutLanguages")]
public class LayoutLanguages : ScriptableObject
{
    public List<KeyboardLanguage> languageList;
    public List<KeyboardLayout> layoutList;

    private void Awake() 
    {
        languageList = new List<KeyboardLanguage>();
        layoutList = new List<KeyboardLayout>();
        KeyboardLanguage language = 0;
        int numberOfLanguages = Enum.GetNames(typeof(KeyboardLanguage)).Length;
        for (int index = 0; index < numberOfLanguages; index++)
        {
            languageList.Add(language);
            layoutList.Add(null);
            language ++;
        }
    }
}
