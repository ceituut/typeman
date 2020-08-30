using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManagerScript : singleton<KeyBoardManagerScript>
{
    public bool IsKeyBoardSectionEnabled;
    public GameObject keybard;
    public Event GameEvent;
    public enum keyboardLanguage
    {
        
        English,
        farsi,

    }
    public keyboardLanguage MykeybardLanguage=keyboardLanguage.English;//we change language with this
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
    public bool IsKeyBoardSystemReady()
    {
        if(IsKeyBoardSectionEnabled && (keybard==null ? false : true) && (keybard.GetComponent<keyboardScript>()!=null))
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
    public void changeToEnglish()
    {
        MykeybardLanguage=keyboardLanguage.English;
    }
    public void changeToFarsi()
    {
        MykeybardLanguage=keyboardLanguage.farsi;
    }

    

}
