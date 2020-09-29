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
        // int length = KeyboardLanguage /// how to get nombe of items in enum ?
        for (int index = 0; index < 12; index++)
        {
            languageList.Add(language);
            layoutList.Add(null);
            language ++;
        }
    }
}
