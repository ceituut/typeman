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
    private LanguageWrong languageWrongComponent;
    private List<Key> keyList;

    private void Start() 
    {
        keyList = new List<Key>( gameObject.GetComponentsInChildren<Key>() );
        languageWrongComponent = gameObject.GetComponent<LanguageWrong>();
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
        languageWrongComponent.UpdateKeyCheckers(currentLayout);
        for (int index = 0; index < keyList.Count ; index++)
        {
            keyList[index].KeyPrimaryValue = currentLayout.GetPrimaryKeyList[index];
            keyList[index].KeySecondaryValue = currentLayout.GetSecondaryKeyList[index];
            keyList[index].TextComponent.text = currentLayout.GetPrimaryKeyList[index];
        }
    }
}