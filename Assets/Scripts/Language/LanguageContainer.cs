using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Definition;


[CreateAssetMenu(fileName="languageContainer",
menuName="TypeMan/KeyboardLanguage/languageContainer")]
public class LanguageContainer : ScriptableObject
{
    public List<KeyboardLanguage> KeyboardLanguageList;
    public List<Language> LanguageList;

    private void Awake() 
    {
        KeyboardLanguageList = new List<KeyboardLanguage>();
        LanguageList = new List<Language>();
        KeyboardLanguage language = 0;
        int numberOfLanguages = Enum.GetNames(typeof(KeyboardLanguage)).Length;
        for (int index = 0; index < numberOfLanguages; index++)
        {
            KeyboardLanguageList.Add(language);
            LanguageList.Add(null);
            language ++;
        }
    }
}
