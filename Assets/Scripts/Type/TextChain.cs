using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChain : MonoBehaviour
{
    // Fields
    private TextMesh textMeshComponent;
    private string initialTextString;
    [SerializeField] private GameObject typedSection;
    private List<TextMesh> typedTextList;
    private List<char> charList;
    private List<bool> IsTypedCorrectList;

    // Properties
    public List<TextMesh> TypedTextList { get => typedTextList; set => typedTextList = value; }
    public string InitialTextString { get => initialTextString; set => initialTextString = value; }

    // Methods
    void Awake()
    {
        textMeshComponent = gameObject.GetComponent<TextMesh>();
        initialTextString = textMeshComponent.text.ToString();
        TextMesh []textChilds = typedSection.GetComponentsInChildren<TextMesh>();
        typedTextList = new List<TextMesh>(textChilds);
        InitializeCharList();
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
    void ShiftLeftCharList(int pointerLocation , Progress pointerProgress)///// rename
    {
        for (int index=0; index < charList.Count ; index++)
        {
            if( index == charList.Count-1 )
            {
                charList[index] = initialTextString[pointerLocation];
                IsTypedCorrectList[index] = pointerProgress.IsTypedCorrectList[pointerLocation];
            }
            else
            {
                charList[index] = charList[index+1];
                IsTypedCorrectList[index] = IsTypedCorrectList[index+1];
            }
        }
    }
    void ShiftRighCharList(int pointerLocation , Progress pointerProgress)
    {
        int length = charList.Count;
        int offset = pointerLocation - charList.Count - 1 ;
        for (int index = length-1; index >= 0 ; index--)
        {
            if( index == 0 )
                if (pointerLocation > charList.Count)
                {
                    charList[index] = initialTextString[offset];
                    IsTypedCorrectList[index] = pointerProgress.IsTypedCorrectList[offset];/////////////////////////////
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
    public void WasTyped(int pointerLocation , Progress pointerProgress)
    {
        ShiftLeftCharList(pointerLocation , pointerProgress);

        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        RemoveLastTypedChar();


        int lastIndex = typedTextList.Count -1;
        if (pointerProgress.IsTypedCorrectList[pointerProgress.IsTypedCorrectList.Count-1])
            IsTypedCorrectList[lastIndex] = true;
        else
            IsTypedCorrectList[lastIndex] = false;


        StyleTypedChar(pointerLocation , pointerProgress);//////////
    }
    public void OneStepBack(int pointerLocation , Progress pointerProgress)
    {
        ShiftRighCharList(pointerLocation , pointerProgress);
        for (int index=0; index < typedTextList.Count ; index++)
            typedTextList[index].text = charList[index].ToString();
        AddPreviousChar(pointerLocation);
        StyleTypedChar(pointerLocation , pointerProgress);//////////
    }
    void RemoveLastTypedChar()
    {
        textMeshComponent.text = textMeshComponent.text.Remove(0,1);
    }
    void AddPreviousChar(int pointerLocation)
    {
        char previousChar = initialTextString[pointerLocation-1];
        textMeshComponent.text = textMeshComponent.text.Insert(0,previousChar.ToString());
    }
    void StyleTypedChar(int pointerLocation , Progress pointerProgress)
    {
        for (int index=0; index < typedTextList.Count ; index++)
            if(IsTypedCorrectList[index])
                typedTextList[index].color = Color.green;
            else
                typedTextList[index].color = Color.red;
    }
}
