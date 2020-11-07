using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class LanguageUpdate : MonoBehaviour
{
    // Fields
    [SerializeField] private Keyboard keyboard;
    [SerializeField] private LanguageContainer LanguageContainer;
    private Dictionary<KeyboardLanguage,Language> LanguageDic;
    private Dictionary<int,int> pairKeyDic;
    private Language currentLanguage;
    private LanguageCheck languageChecker;

    // Properties
    public Keyboard SetKeyboard {set => keyboard = value; }

    // Methods
    private void Start()
    {
        languageChecker = new LanguageCheck();
        InitializeLanguageDic();
        InitializePairKeyDic();
        UpdateKeyboardLanguage(KeyboardLanguage.English);
    }
    private void InitializeLanguageDic()
    {
        int numberOfLanguages = LanguageContainer.KeyboardLanguageList.Count;
        LanguageDic = new Dictionary<KeyboardLanguage, Language>();
        for (int index = 0; index < numberOfLanguages ; index++)
            LanguageDic.Add(LanguageContainer.KeyboardLanguageList[index] , LanguageContainer.LanguageList[index]);
    }
    private void InitializePairKeyDic()
    {
        pairKeyDic = new Dictionary<int, int>();
        int keyIndexInLayout;
        int KeyIndexInLiteralKeys;
        foreach(string thisDefaultKey in primaryLiteralKeys)
        {
            keyIndexInLayout = keyboard.GetKeyboardLayout.GetDefaultKeyList.IndexOf(thisDefaultKey);
            KeyIndexInLiteralKeys = primaryLiteralKeys.IndexOf(thisDefaultKey);
            pairKeyDic.Add(keyIndexInLayout , KeyIndexInLiteralKeys);
        }
    }
    public void UpdateKeyboardLanguage(KeyboardLanguage language)
    {
        LanguageDic.TryGetValue(language,out currentLanguage);
        languageChecker.UpdateKeyCheckers(currentLanguage);
        foreach(int layoutKeyIndex in pairKeyDic.Keys)
            UpdateSingleKey(layoutKeyIndex);
        EnterChange enterChange = gameObject.GetComponent<EnterChange>();
        StandardChange standardChange = gameObject.GetComponent<StandardChange>();
        if (enterChange != null)
            enterChange.ChangeEnter(enterChange.GetCurrentType);
        if (standardChange!= null)
            standardChange.ChangeStandard(standardChange.GetCurrentType);
    }
    public void UpdateSingleKey(int layoutKeyIndex)
    {
        int newKeyIndex = pairKeyDic[layoutKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].KeyPrimaryValue = currentLanguage.primaryKeyList[newKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].KeySecondaryValue = currentLanguage.secondaryKeyList[newKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].TextComponent.text = currentLanguage.primaryKeyList[newKeyIndex];
    }
}