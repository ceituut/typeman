using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardManagerScript : singleton<KeyBoardManagerScript>
{
    public bool IsKeyBoardSectionEnabled;
    public GameObject keybard;
    
    public bool IsKeyBoardSystemReady()
    {
        if(IsKeyBoardSectionEnabled && (keybard==null ? false : true))
          Debug.Log("Keyboard System Run.");
          else
          {
              if(!IsKeyBoardSectionEnabled)
              {
                  Debug.Log("keyboard system is not enabled!");
              }
              else
              if(keybard==null)
              {
                  Debug.Log("keyboard GameObject Variable is null!");
              }
          }
        return (IsKeyBoardSectionEnabled && (keybard==null ? false : true));
    }
}
