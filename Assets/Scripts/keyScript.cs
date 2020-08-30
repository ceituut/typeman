using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="New Key",menuName="keyboard key")]
public class keyScript : ScriptableObject
{
   public KeyCode MyKeyCode;
   public KeyBoardManagerScript.keyboardLanguage Language;
   public char CapslockOnletter,CapslockOffLetter;
   
}
