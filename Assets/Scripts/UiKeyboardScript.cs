using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiKeyboardScript : MonoBehaviour
{
    public KeyCode mykey;//initiate in the unity editor

    public char [] charactersList;//initiate in unity Editor
    public int characterLanguageIndex;
    public string myString;//dont initiate
    private void Initializings()
    {
        myString=setCharEqualWithKey(mykey);
    }
    private void Awake()
    {
        Initializings();
    }
   private void Update()
   {
       PressRelatedBtn();
       KeyboardLanguageSet();
   }
   private void KeyboardLanguageSet()
   {
       switch(KeyBoardManagerScript.instance.MykeybardLanguage)
       {
           case  KeyBoardManagerScript.keyboardLanguage.EnglishCapslockOff :
                characterLanguageIndex=0;
                break;
                 case  KeyBoardManagerScript.keyboardLanguage.EnglishCapslockOn :
                characterLanguageIndex=1;
                break;
                 case  KeyBoardManagerScript.keyboardLanguage.farsi :
                characterLanguageIndex=2;
                break;
       }
   }
   private void PressRelatedBtn()
   {
       if(KeyBoardManagerScript.instance.IsKeyBoardSectionEnabled)
       {
          if(mykey==currentBtnKeyCode())
          {
              Debug.Log(charactersList[characterLanguageIndex]);///////
              //run animation on correct key(code here)
          }
          
       }
   }
   private KeyCode currentBtnKeyCode()
   {
       var e=System.Enum.GetNames(typeof(KeyCode)).Length;
        for(int i = 0; i < e; i++)
             {
                 if(Input.GetKeyDown((KeyCode)i))
                 {
                     return (KeyCode)i;
                 }
             }
             return KeyCode.None;
   }
   private string setCharEqualWithKey(KeyCode _KeyCode)
   {
       
       return _KeyCode.ToString();
            
   }
}
