using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject RelatedFinger; //////////
    // private KeyBoardManagerScript.keyboardLanguage Language; //////////
   

   //////////////////////
    [SerializeField] private Text textComponent; // Initialize it with a script in Run in Edit mode
    [SerializeField] private int keyLocation; // Initialize it with a script in Run in Edit mode
    [SerializeField] private string keyPrimaryValue; 
    [SerializeField] private string keySecondaryValue;

    public string KeyPrimaryValue { get => keyPrimaryValue; set => keyPrimaryValue = value; }
    public string KeySecondaryValue { get => keySecondaryValue; set => keySecondaryValue = value; }

    private void Awake() 
    {
        // Subscribes to keyboard changing
        // KeyBoardManagerScript.OnKeyboardChanged += ChangeKeyValues;    
    } 
    // private void ChangeKeyValues(Keyboard keyboard)
    // {
    //     keyPrimaryValue = KeyBoardManagerScript.instance.CurrentKeyboard.PrimaryKeyList[keyLocation];
    //     keySecondaryValue = KeyBoardManagerScript.instance.CurrentKeyboard.SecondaryKeyList[keyLocation];
    //     ChangeKeyText();
    // }
    private void ChangeKeyText()
    {
        
    }

//    private void KeyboardLanguageSet()
//    {
      
//         Language=KeyBoardManagerScript.instance.MykeybardLanguage;
//         switch (Language)
//         {
//             case KeyBoardManagerScript.keyboardLanguage.English :
//             keyCurrentLanguage=English;
//             break;
//              case KeyBoardManagerScript.keyboardLanguage.farsi :
//             keyCurrentLanguage=Farsi;
//             break;

//         }
//    }


//    private void PressRelatedBtn()
//    {
      
//        if(KeyBoardManagerScript.instance.IsKeyBoardSectionEnabled)
//        { 
           
//           if(keyCurrentLanguage!=null && keyCurrentLanguage.MyKeyCode ==currentBtnKeyCode())
//           {
             
//                  if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
//                  {
//                      Debug.Log(keyCurrentLanguage.CapslockOnletter);
//                  }
//                  else
//                  {
//                     Debug.Log(keyCurrentLanguage.CapslockOffLetter); 
//                  }
//                 // GetComponent<Animation>().play(); used to highLight the key(code here)
//                 if(RelatedFinger!=null && RelatedFinger.GetComponent<FingerScript>()!=null)
//                 {
//                   //  RelatedFinger.GetComponent<Animation>().Play(); use to hight light related finger(code here)
//                 }

             
              
//           }
          
//        }
//    }


//    private KeyCode currentBtnKeyCode()
//    {
//        var e=System.Enum.GetNames(typeof(KeyCode)).Length;
//         for(int i = 0; i < e; i++)
//              {
//                  if(Input.GetKeyDown((KeyCode)i))
//                  {
//                      return (KeyCode)i;
//                  }
//              }
//              return KeyCode.None;
//    }
//    private string setCharEqualWithKey(KeyCode _KeyCode)
//    {
       
//        return _KeyCode.ToString();
            
//    }
}
