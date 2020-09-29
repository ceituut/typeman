using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    public GameObject RelatedFinger; 
    [SerializeField] private Text textComponent;
    [SerializeField] private string keyPrimaryValue; 
    [SerializeField] private string keySecondaryValue;

    public string KeyPrimaryValue { get => keyPrimaryValue; set => keyPrimaryValue = value; }
    public string KeySecondaryValue { get => keySecondaryValue; set => keySecondaryValue = value; }
    public Text TextComponent { get => textComponent; set => textComponent = value; }

    private void Awake() 
    {
        textComponent = gameObject.GetComponentInChildren<Text>();   
    } 
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
}
