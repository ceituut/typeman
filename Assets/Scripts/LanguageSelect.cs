using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDef;


public class LanguageSelect : MonoBehaviour
{
    [SerializeField] private LayoutLanguages layoutLanguages;
    [SerializeField] private LanguageUpdate languageUpdate;
    private KeyboardLanguage currentLanguage;
    private Dropdown dropdownComponent;

    private void Awake() 
    {
        InitializeDropdown();
    }
    private void InitializeDropdown()
    {
        dropdownComponent = gameObject.GetComponent<Dropdown>();
        string langugeName;
        foreach ( KeyboardLanguage language in layoutLanguages.languageList)
        {
            langugeName = language.ToString();
            dropdownComponent.options.Add(new Dropdown.OptionData(langugeName));
        }
        dropdownComponent.onValueChanged.AddListener( delegate { OnLanguageChanged(); } );
    }
    private KeyboardLanguage GetLanguageOfOption(string langugaeName)
    {
        KeyboardLanguage relatedLanguage = KeyboardLanguage.English;
        foreach ( KeyboardLanguage language in layoutLanguages.languageList )
            if ( language.ToString() == langugaeName )
                relatedLanguage = language;
        return relatedLanguage;
    }
    private void OnLanguageChanged()
    {
        currentLanguage = GetLanguageOfOption(dropdownComponent.value.ToString()); /////////////// ???
        languageUpdate.UpdateKeyboardLanguage(currentLanguage);
    }
}