using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManagerScript : singleton<KeyBoardManagerScript>
{
    public bool IsKeyBoardSectionEnabled;
    public GameObject keybard;
    public Event GameEvent;
    private int keyboardLanguageIndex=1;
    public enum keyboardLanguage
    {
        EnglishCapslockOn,
        EnglishCapslockOff,
        farsi,

    }
    public int maxLanguages=3;
    public keyboardLanguage MykeybardLanguage=keyboardLanguage.EnglishCapslockOff;
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
    public bool IsKeyBoardSystemReady()
    {
        if(IsKeyBoardSectionEnabled && (keybard==null ? false : true) && (keybard.GetComponent<HandManagerScript>()!=null))
          Debug.Log("Keyboard System Run.");
          else
          {
              if(!IsKeyBoardSectionEnabled)
              {
                  Debug.Log("keyboard system is not enabled!");
              }
              else
              if(keybard==null ||(keybard!=null && keybard.GetComponent<HandManagerScript>()==null))
              {
                  Debug.Log("please insert a valid keyboard!");
              }
          }
        return (IsKeyBoardSectionEnabled && (keybard==null ? false : true));
    }
    public void changeKeyboardLanguage()
    {
        keyboardLanguageIndex++;
        if(keyboardLanguageIndex>maxLanguages)
        keyboardLanguageIndex=1;
        switch(keyboardLanguageIndex)
        {
            case 1 :
             MykeybardLanguage=keyboardLanguage.EnglishCapslockOff;
            break;

             case 2 :
              MykeybardLanguage=keyboardLanguage.EnglishCapslockOn ;
            break;
             case 3 :
              MykeybardLanguage=keyboardLanguage.farsi;
            break;



        }
    }

}
