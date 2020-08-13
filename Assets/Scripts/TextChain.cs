using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChain : MonoBehaviour
{
    // Fields 
    private Text textComponent;
    private string textString;
    [SerializeField] private GameObject typedSection;
    private List<Text> typedTextList;
    private List<char> charList;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
        textString = textComponent.text.ToString();
        Text []textChilds = typedSection.GetComponentsInChildren<Text>();
        typedTextList = new List<Text>(textChilds);
        InitializeCharList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializeCharList()
    {
        charList = new List<char>();
        for(int index=0; index < typedTextList.Count ; index++)
        {
            charList.Add(' ');
        }
    }
    void ShiftLeftCharList(int pointerLocation)
    {
        for (int index=0; index < charList.Count ; index++)
        {
            if( index == charList.Count-1 )
                charList[index] = textString[pointerLocation];
            else
                charList[index] = charList[index+1];
        }
    }
    public void WasTyped(int pointerLocation)
    {
        ShiftLeftCharList(pointerLocation);
        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
    }
    public void WasCorrect(int pointerLocation)
    {
    }

    public void GoForward(int pointerLocation)
    {

    }

    public void GoBackward(int pointerLocation)
    {
        
    }
}
