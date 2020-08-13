using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChain : MonoBehaviour
{
    // Fields 
    private Text textComponent;
    private string textString;
    private int correctCharOffset;

    // Start is called before the first frame update
    void Start()
    {
        textComponent = gameObject.GetComponent<Text>();
        textString = textComponent.text.ToString();
        // correctCharOffset = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WasCorrect(int pointerLocation)
    {
        // int replacementLocation;
        // if (pointerLocation != 0)
        //     correctCharOffset += 7;
        // replacementLocation = correctCharOffset + pointerLocation;
        // char currentChar = textString[replacementLocation];
        // string successor = "<b>" + currentChar + "</b>";
        // textString = textString.Remove(replacementLocation , 1);
        // textString = textString.Insert(replacementLocation,successor);
        // textComponent.text = textString;
        // Debug.Log(textString);
    }

    public void GoForward(int pointerLocation)
    {

    }

    public void GoBackward(int pointerLocation)
    {
        
    }
}
