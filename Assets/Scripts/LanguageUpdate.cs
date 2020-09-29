using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageUpdate : MonoBehaviour
{
    [SerializeField] private LayoutLanguages layoutLanguages;
    private Dictionary<KeyboardLanguage,KeyboardLayout> layoutDic;
    private KeyboardLayout currentLayout;
    private LanguageCheck languageChecker;
    private List<Key> keyList;

    private void Start() 
    {
        keyList = new List<Key>( gameObject.GetComponentsInChildren<Key>() );
        languageChecker = new LanguageCheck();
        InitializeLayoutDic();
        UpdateKeyboardLanguage(KeyboardLanguage.English);
    }
    private void InitializeLayoutDic()
    {
        int numberOfLanguages = layoutLanguages.languageList.Count;
        layoutDic = new Dictionary<KeyboardLanguage, KeyboardLayout>();
        for (int index = 0; index < numberOfLanguages ; index++)
            layoutDic.Add(layoutLanguages.languageList[index] , layoutLanguages.layoutList[index]);
    }
    public void UpdateKeyboardLanguage(KeyboardLanguage language)
    {
        layoutDic.TryGetValue(language,out currentLayout);
        languageChecker.UpdateKeyCheckers(currentLayout);
        for (int index = 0; index < keyList.Count ; index++)
        {
            keyList[index].KeyPrimaryValue = currentLayout.GetPrimaryKeyList[index];
            keyList[index].KeySecondaryValue = currentLayout.GetSecondaryKeyList[index];
            keyList[index].TextComponent.text = currentLayout.GetPrimaryKeyList[index];
        }
    }
}