using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageUpdate : MonoBehaviour
{
    [SerializeField] private LanguageContainer LanguageContainer;
    private Dictionary<KeyboardLanguage,Language> LanguageDic;
    private Language currentLanguage;
    private LanguageCheck languageChecker;
    private List<Key> keyList;

    private void Start() 
    {
        keyList = new List<Key>( gameObject.GetComponentsInChildren<Key>() );
        languageChecker = new LanguageCheck();
        InitializeLanguageDic();
        UpdateKeyboardLanguage(KeyboardLanguage.English);
    }
    private void InitializeLanguageDic()
    {
        int numberOfLanguages = LanguageContainer.KeyboardLanguageList.Count;
        LanguageDic = new Dictionary<KeyboardLanguage, Language>();
        for (int index = 0; index < numberOfLanguages ; index++)
            LanguageDic.Add(LanguageContainer.KeyboardLanguageList[index] , LanguageContainer.LanguageList[index]);
    }
    public void UpdateKeyboardLanguage(KeyboardLanguage language)
    {
        LanguageDic.TryGetValue(language,out currentLanguage);
        languageChecker.UpdateKeyCheckers(currentLanguage);
        for (int index = 0; index < keyList.Count ; index++)
        {
            keyList[index].KeyPrimaryValue = currentLanguage.primaryKeyList[index];
            keyList[index].KeySecondaryValue = currentLanguage.secondaryKeyList[index];
            keyList[index].TextComponent.text = currentLanguage.primaryKeyList[index];
        }
    }
}