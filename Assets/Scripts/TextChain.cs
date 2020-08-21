using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChain : MonoBehaviour
{
    // Fields
    private TextMesh textMeshComponent;
    private string textString;
    [SerializeField] private GameObject typedSection;
    private List<TextMesh> typedTextList;
    private List<char> charList;

    // Start is called before the first frame update
    void Start()
    {
        textMeshComponent = gameObject.GetComponent<TextMesh>();
        textString = textMeshComponent.text.ToString();
        TextMesh []textChilds = typedSection.GetComponentsInChildren<TextMesh>();
        typedTextList = new List<TextMesh>(textChilds);
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

    void ShiftRighCharList(int pointerLocation)
    {
        int length = charList.Count;
        int offset = pointerLocation - charList.Count - 1 ;
        for (int index = length-1; index >= 0 ; index--)
        {
            if( index == 0 )
                if (pointerLocation > charList.Count)
                    charList[index] = textString[offset];
                else
                    charList[index] = ' ';

            else
                charList[index] = charList[index-1];
        }
    }
    public void WasTyped(int pointerLocation)
    {
        ShiftLeftCharList(pointerLocation);
        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        RemoveLastTypedChar();
    }
    public void OneStepBack(int pointerLocation)
    {
        ShiftRighCharList(pointerLocation);
        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        AddPreviousChar(pointerLocation);
    }
    void RemoveLastTypedChar()
    {
        textMeshComponent.text = textMeshComponent.text.Remove(0,1);
    }
    void AddPreviousChar(int pointerLocation)
    {
        char previousChar = textString[pointerLocation-1];
        textMeshComponent.text = textMeshComponent.text.Insert(0,previousChar.ToString());
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
