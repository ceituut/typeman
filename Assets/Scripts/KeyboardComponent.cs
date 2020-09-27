using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KeyboardComponent : MonoBehaviour
{
    public Dictionary<SystemLanguage,KeyboardLayout> layoutDic;
    [SerializeField] private LayoutLanguages layoutLanguages;
    private SystemLanguage currentLanguage;
    private List<Key> keyList;
    
    private void Awake() 
    {
        keyList = new List<Key>( gameObject.GetComponentsInChildren<Key>() );
        InitializeLayoutDic();
        UpdateLanguage();
    }
    private void Update()
    {
        if (Application.systemLanguage != currentLanguage)
            UpdateLanguage();
    }

    private void InitializeLayoutDic()
    {
        int numberOfLanguages = layoutLanguages.languageList.Count;
        layoutDic = new Dictionary<SystemLanguage, KeyboardLayout>();
        for (int index = 0; index < numberOfLanguages ; index++)
            layoutDic.Add(layoutLanguages.languageList[index] , layoutLanguages.layoutList[index]);
    }
    private void UpdateLanguage()
    {
        currentLanguage = Application.systemLanguage;
        UpdateKeyboardLanguage(currentLanguage);
    }
    void UpdateKeyboardLanguage(SystemLanguage language)
    {
        KeyboardLayout thisLayout;
        Debug.Log(language.ToString());
        layoutDic.TryGetValue(language,out thisLayout);
        if (thisLayout != null)
            for (int index = 0; index < keyList.Count ; index++)
            {
                keyList[index].KeyPrimaryValue = thisLayout.GetPrimaryKeyList[index];
                keyList[index].KeySecondaryValue = thisLayout.GetSecondaryKeyList[index];
                keyList[index].TextComponent.text = thisLayout.GetPrimaryKeyList[index];
            }
        else
        {
            Debug.Log("Language not supported");
            // tell that language not supported !
        }
    }

}