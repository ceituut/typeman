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
    public List<SystemLanguage> languageList;
    public List<KeyboardLayout> layoutList;

    private void Awake() 
    {
        languageList = new List<SystemLanguage>();
        layoutList = new List<KeyboardLayout>();
        for (int index = 0; index < 10; index++)
        {
            languageList.Add(SystemLanguage.English);
            layoutList.Add(null);
        }
    }
}
