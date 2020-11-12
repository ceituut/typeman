using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class KeyboardLanguageChange : MonoBehaviour
{
    // Fields
    [SerializeField] private Keyboard keyboard;
    private Dictionary<int,int> layoutToLiteralMapDic;

    // Properties
    public Keyboard SetKeyboard {set => keyboard = value; }

    // Methods
    private void Start()
    {
        InitializeLayoutToLiteralMapDic();
    }
    private void InitializeLayoutToLiteralMapDic()
    {
        layoutToLiteralMapDic = new Dictionary<int, int>();
        int keyIndexInLayout;
        int KeyIndexInLiteralKeys;
        foreach(string thisDefaultKey in primaryLetters)
        {
            keyIndexInLayout = keyboard.GetKeyboardLayout.GetDefaultKeyList.IndexOf(thisDefaultKey);
            KeyIndexInLiteralKeys = primaryLetters.IndexOf(thisDefaultKey);
            layoutToLiteralMapDic.Add(keyIndexInLayout , KeyIndexInLiteralKeys);
        }
    }
    public void ChangeKeyboardLanguage(Language language)
    {
        keyboard.KeyboardLanguage = language;
        foreach(int layoutKeyIndex in layoutToLiteralMapDic.Keys)
            UpdateSingleKey(language , layoutKeyIndex);
        PerformTypeChange();
    }
    public void UpdateSingleKey(Language language , int layoutKeyIndex)
    {
        int newKeyIndex = layoutToLiteralMapDic[layoutKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].PrimaryValue = language.primaryKeyList[newKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].SecondaryValue = language.secondaryKeyList[newKeyIndex];
        keyboard.GetKeyList[layoutKeyIndex].TextComponent.text = language.primaryKeyList[newKeyIndex];
    }
    private void PerformTypeChange()
    {
        EnterChange enterChange = gameObject.GetComponent<EnterChange>();
        StandardChange standardChange = gameObject.GetComponent<StandardChange>();
        if (enterChange != null)
            enterChange.ChangeEnter(enterChange.GetCurrentType);
        if (standardChange!= null)
            standardChange.ChangeStandard(standardChange.GetCurrentType);
    }
}