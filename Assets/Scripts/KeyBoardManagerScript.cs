﻿using System;
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


    ///////////////////////////////////
    private void Initializings()
    {
        changeToEnglish();
        GameEvent=Event.current;
    }
    protected override void Awake()
    {
        base.Awake();
        Initializings();
    }
    private void Update()
    {
       checkForCapslockOnOrOff();
    }
    private void checkForCapslockOnOrOff()
    {
         if(Input.GetKeyDown(KeyCode.CapsLock))
        {
            GameEvent=Event.current;
        }
    }
    // public bool IsKeyBoardSystemReady()
    // {
    //     if(IsKeyBoardSectionEnabled && (keybard==null ? false : true) && (keybard.GetComponent<keyboardScript>()!=null))
    //       Debug.Log("Keyboard System Run.");
    //       else
    //       {
    //           if(!IsKeyBoardSectionEnabled)
    //           {
    //               Debug.Log("keyboard system is not enabled!");
    //           }
    //           else
    //           if(keybard==null ||(keybard!=null && keybard.GetComponent<HandManagerScript>()==null))
    //           {
    //               Debug.Log("please insert a valid keyboard!");
    //           }
    //       }
    //     return (IsKeyBoardSectionEnabled && (keybard==null ? false : true));
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
