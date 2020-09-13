using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManagerScript : singleton<KeyBoardManagerScript>
{
    public bool IsKeyBoardSectionEnabled;
    public GameObject keybard;
    public Event GameEvent;
    public enum keyboardLanguage {English,Farsi};
    public keyboardLanguage MykeybardLanguage=keyboardLanguage.English;//we change language with this




    [SerializeField] private List<List<Key>> keyboardRows;

    //////////////////////////
    // public static event Action<Keyboard> OnKeyboardChanged;
    // public List<Keyboard> keyboardList;
    // private Keyboard currentKeyboard;

    // public Keyboard CurrentKeyboard
    // {
    //     get {return currentKeyboard;}
    //     set {
    //             currentKeyboard = value;
    //             // update keys here
    //             UpdateKeys();
    //         }
    // }
    
    private void CheckSystemLangauge()
    {
        // every time user changes language , we should get system language and campare with keyboardList
        // and change keyboard
        // we should tell him if a languge not supported
    }
    private void ChangeLanguage()
    {
        //CurrentKeyboard = assing it
    }
    private bool IsLanguageChanged()
    {
        return ( 
            ( Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt) )
            && ( Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) )
            );
    }
    private bool ChackBackSace()
    {
        return true;
    }
    // private void UpdateKeys()
    // {
    //     if ( OnKeyboardChanged != null)
    //         OnKeyboardChanged(currentKeyboard);
    // }
    // private void Update() 
    // {
    //     if (IsLanguageChanged())
    //     {
    //         CheckSystemLangauge();
    //         ChangeLanguage();
    //     }
    // }

    // private void InitializeDefaultKeyboard()
    // {
    //     keyboardRows = new List<List<Key>>();
    //     InitializeRow(new List<Key>() , 14);
    //     InitializeRow(new List<Key>() , 14);
    //     InitializeRow(new List<Key>() , 14);
    //     InitializeRow(new List<Key>() , 12);
    //     InitializeRow(new List<Key>() , 8);
    // }
    // private void InitializeRow(List<Key> thisRow , int numberOfKeys)
    // {
    //     Key newKey;
    //     int startKeyIndex = GetStartIndexOfRow();
    //     keyboardRows.Add(thisRow);
    //     for (int index = startKeyIndex; index < numberOfKeys ; index++)
    //     {
    //         newKey = new Key();
    //         newKey.KeyPrimaryValue = primaryKeyList[index];
    //         newKey.KeySecondaryValue = secondaryKeyList[index];
    //         // newKey.TextComponent.text = primaryKeyList[index]; /////////////////
    //         thisRow.Add(newKey);
    //     }
    // }
    // private int GetStartIndexOfRow()
    // {
    //     int startKeyIndex = 0;
    //     if (keyboardRows.Count == 0)
    //         return startKeyIndex;
    //     int lastKeyIndex;
    //     for (int index = 0; index < keyboardRows.Count ; index++)
    //     {
    //         lastKeyIndex = keyboardRows[index].Count - 1;
    //         startKeyIndex += lastKeyIndex;
    //     }
    //     return startKeyIndex;
    // }





    public void changeToEnglish()
    {
        MykeybardLanguage=keyboardLanguage.English;
    }
    public void changeToFarsi()
    {
        MykeybardLanguage=keyboardLanguage.Farsi;
    }

    

}
