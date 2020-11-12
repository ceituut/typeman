using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class LanguageSelect : MonoBehaviour
{
    [SerializeField] private LanguageContainer languageContainer;
    private Dictionary<KeyboardLanguage,Language> languageDic;
    private Dropdown dropdownComponent;
    [SerializeField] private KeyboardLanguageChange keyboardLanguageChanger;
    private LanguageCheck languageChecker;
    [SerializeField] private LessonLanguageChange lessonLanguageChanger;

    private void Start() 
    {
        languageChecker = new LanguageCheck();
        InitializeDropdown();
        InitializeLanguageDic();
        //////////////////////////// Initialize keyboard language here or select default option
    }
    private void InitializeLanguageDic()
    {
        int numberOfLanguages = languageContainer.KeyboardLanguageList.Count;
        languageDic = new Dictionary<KeyboardLanguage, Language>();
        for (int index = 0; index < numberOfLanguages ; index++)
            languageDic.Add(languageContainer.KeyboardLanguageList[index] , languageContainer.LanguageList[index]);
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
    private Language GetLanguageOfOption(string languageName)
    {
        KeyboardLanguage relatedLanguage = 0;
        KeyboardLanguage language = 0;
        int numberOfLanguages = Enum.GetNames(typeof(KeyboardLanguage)).Length;
        for (int index = 0; index < numberOfLanguages; index++ , language++)
            if ( language.ToString() == languageName )
                relatedLanguage = language;
        return languageDic[language];
    }
    private void OnLanguageChanged()
    {
        Dropdown.OptionData currentOption = dropdownComponent.options[dropdownComponent.value];
        Language currentLanguage = GetLanguageOfOption(currentOption.text);
        keyboardLanguageChanger.ChangeKeyboardLanguage(currentLanguage);
        languageChecker.UpdateKeyCheckers(currentLanguage);
        lessonLanguageChanger.ChangeLessonLanguage(currentLanguage);
    }
}