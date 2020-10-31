using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageSelect : MonoBehaviour
{
    private LanguageUpdate languageUpdate;
    private KeyboardLanguage currentLanguage;
    private Dropdown dropdownComponent;

    private void Awake() 
    {
        InitializeDropdown();
        FindKeyboard();
    }
    private void FindKeyboard()
    {
        GameObject Keyboard = GameObject.FindGameObjectWithTag("Keyboard");
        languageUpdate = Keyboard.GetComponent<LanguageUpdate>();
    }
    private void InitializeDropdown()
    {
        dropdownComponent = gameObject.GetComponent<Dropdown>();
        string languageName;
        KeyboardLanguage language = 0;
        int numberOfLanguages = Enum.GetNames(typeof(KeyboardLanguage)).Length;
        for (int index = 0; index < numberOfLanguages; index++)
        {
            languageName = language.ToString();
            dropdownComponent.options.Add(new Dropdown.OptionData(languageName));
            language ++;
        }
        dropdownComponent.onValueChanged.AddListener( delegate { OnLanguageChanged(); } );
    }
    private KeyboardLanguage GetLanguageOfOption(string languageName)
    {
        KeyboardLanguage relatedLanguage = 0;
        KeyboardLanguage language = 0;
        int numberOfLanguages = Enum.GetNames(typeof(KeyboardLanguage)).Length;
        for (int index = 0; index < numberOfLanguages; index++ , language++)
            if ( language.ToString() == languageName )
                relatedLanguage = language;
        return relatedLanguage;
    }
    private void OnLanguageChanged()
    {
        Dropdown.OptionData currentOption = dropdownComponent.options[dropdownComponent.value];
        currentLanguage = GetLanguageOfOption(currentOption.text);
        languageUpdate.UpdateKeyboardLanguage(currentLanguage);
    }
}