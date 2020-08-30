using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiKeyboardScript : MonoBehaviour
{    public keyScript English,Farsi,keyCurrentLanguage;
public GameObject RelatedFinger;
    private KeyBoardManagerScript.keyboardLanguage Language;
   
    
    
   private void Update()
   {
              KeyboardLanguageSet();
       PressRelatedBtn();
   }
   private void KeyboardLanguageSet()
   {
      
        Language=KeyBoardManagerScript.instance.MykeybardLanguage;
        switch (Language)
        {
            case KeyBoardManagerScript.keyboardLanguage.English :
            keyCurrentLanguage=English;
            break;
             case KeyBoardManagerScript.keyboardLanguage.farsi :
            keyCurrentLanguage=Farsi;
            break;

        }
   }
   private void PressRelatedBtn()
   {
      
       if(KeyBoardManagerScript.instance.IsKeyBoardSectionEnabled)
       { 
           
          if(keyCurrentLanguage!=null && keyCurrentLanguage.MyKeyCode ==currentBtnKeyCode())
          {
             
                 if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                 {
                     Debug.Log(keyCurrentLanguage.CapslockOnletter);
                 }
                 else
                 {
                    Debug.Log(keyCurrentLanguage.CapslockOffLetter); 
                 }
                // GetComponent<Animation>().play(); used to highLight the key(code here)
                if(RelatedFinger!=null && RelatedFinger.GetComponent<FingerScript>()!=null)
                {
                  //  RelatedFinger.GetComponent<Animation>().Play(); use to hight light related finger(code here)
                }

             
              
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
