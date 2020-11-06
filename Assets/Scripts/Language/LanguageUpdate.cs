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

    public Keyboard SetKeyboard {set => keyboard = value; }

    private void Start() 
    {
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
            UpdateSingleKey(index);
    }
    public void UpdateSingleKey(int keyIndex)
    {
        keyboard.GetKeyList[keyIndex].KeyPrimaryValue = currentLanguage.primaryKeyList[keyIndex];
        keyboard.GetKeyList[keyIndex].KeySecondaryValue = currentLanguage.secondaryKeyList[keyIndex];
        keyboard.GetKeyList[keyIndex].TextComponent.text = currentLanguage.primaryKeyList[keyIndex];
    }
}