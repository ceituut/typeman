using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class LanguageUpdate : MonoBehaviour
{
    private Keyboard keyboard;
    [SerializeField] private LanguageContainer LanguageContainer;
    private Dictionary<KeyboardLanguage,Language> LanguageDic;
    private Language currentLanguage;
    private LanguageCheck languageChecker;


    private void Start() 
    {
        keyboard = gameObject.GetComponent<Keyboard>();
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
        for (int index = 0; index < keyboard.GetKeyList.Count ; index++)
        {
            keyboard.GetKeyList[index].KeyPrimaryValue = currentLanguage.primaryKeyList[index];
            keyboard.GetKeyList[index].KeySecondaryValue = currentLanguage.secondaryKeyList[index];
            keyboard.GetKeyList[index].TextComponent.text = currentLanguage.primaryKeyList[index];
        }
    }
}