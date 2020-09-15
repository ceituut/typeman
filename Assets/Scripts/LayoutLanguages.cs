using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// First , Create all Keyboards in other languages for specific KeyboardLayout
// for example for WindowsDesktop KeyboardLayout
// Then , Add all These keyboards inside This Asset for that KeyboardLayout
[CreateAssetMenu(fileName="WindowsDesktopLanguages",
menuName="TypeMan/Keyboard/LayoutLanguages")]
public class LayoutLanguages : ScriptableObject
{
    public List<KeyboardLayout> layoutList;

    private void Awake() 
    {
        layoutList = new List<KeyboardLayout>();
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
        layoutList.Add(null);   
    }
}
