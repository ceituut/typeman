using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiKeyboardScript : MonoBehaviour
{
    public KeyCode mykey;//initiate in the unity editor
    private void Update()
    {
        PressRelatedBtn();
    }
    private void PressRelatedBtn()
    {
        if(KeyBoardManagerScript.instance.IsKeyBoardSectionEnabled)
        {
            if(mykey==currentBtnKeyCode())
            {
                Debug.Log(mykey);///////
                //run animation on correct key(code here)
            }
            
        }
    }
    private KeyCode currentBtnKeyCode()
    {
        var e=System.Enum.GetNames(typeof(KeyCode)).Length;
        for(int i = 0; i < e; i++)
            {
                if(Input.GetKey((KeyCode)i))
                {
                    return (KeyCode)i;
                }
            }
        return KeyCode.None;
    }
}
