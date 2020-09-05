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
    private List<bool> IsTypedCorrectList;

    public List<TextMesh> TypedTextList { get => typedTextList; set => typedTextList = value; }

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
        IsTypedCorrectList = new List<bool>();
        for(int index=0; index < typedTextList.Count ; index++)
        {
            charList.Add(' ');
            IsTypedCorrectList.Add(false);////
        }
    }
    void ShiftLeftCharList(int pointerLocation , Report pointerReport)///// rename
    {
        for (int index=0; index < charList.Count ; index++)
        {
            if( index == charList.Count-1 )
            {
                charList[index] = textString[pointerLocation];
                IsTypedCorrectList[index] = pointerReport.IsTypedCorrectList[pointerLocation];
                // IsTypedCorrectList[index] = IsTypedCorrectList[pointerLocation];
            }
            else
            {
                charList[index] = charList[index+1];
                IsTypedCorrectList[index] = IsTypedCorrectList[index+1];
            }
        }
    }
    void ShiftRighCharList(int pointerLocation , Report pointerReport)
    {
        int length = charList.Count;
        int offset = pointerLocation - charList.Count - 1 ;
        for (int index = length-1; index >= 0 ; index--)
        {
            if( index == 0 )
                if (pointerLocation > charList.Count)
                {
                    charList[index] = textString[offset];
                    IsTypedCorrectList[index] = pointerReport.IsTypedCorrectList[offset];/////////////////////////////
                }
                else
                {
                    charList[index] = ' ';
                    IsTypedCorrectList[index] = false;
                }

            else
            {
                charList[index] = charList[index-1];
                IsTypedCorrectList[index] = IsTypedCorrectList[index-1];
            }
        }
    }
    public void WasTyped(int pointerLocation , Report pointerReport)
    {
        ShiftLeftCharList(pointerLocation , pointerReport);

        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        RemoveLastTypedChar();


        int lastIndex = typedTextList.Count -1;
        if (pointerReport.IsTypedCorrectList[pointerReport.IsTypedCorrectList.Count-1])
            IsTypedCorrectList[lastIndex] = true;
        else
            IsTypedCorrectList[lastIndex] = false;


        StyleTypedChar(pointerLocation , pointerReport);//////////
    }
    public void OneStepBack(int pointerLocation , Report pointerReport)
    {
        ShiftRighCharList(pointerLocation , pointerReport);
        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        AddPreviousChar(pointerLocation);
        StyleTypedChar(pointerLocation , pointerReport);//////////
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
    void StyleTypedChar(int pointerLocation , Report pointerReport)
    {
        for (int index=0; index < typedTextList.Count ; index++)
            if(IsTypedCorrectList[index])
                typedTextList[index].color = Color.green;
            else
                typedTextList[index].color = Color.red;
    }
    public void GoBackward(int pointerLocation)
    {
        
    }
}
