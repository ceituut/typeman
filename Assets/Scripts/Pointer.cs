using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    private char neededChar;
    private char lastInputChar;
    [SerializeField] private GameObject targetPlatform;
    private InputField playerInputField;
    [SerializeField] private GameObject targetText;
    private string textString;
    private int pointerLocation;
    private int mistakes;
    private int backspaceMistakes;
    private List<bool> wasCorrectList;
    private bool pointerActiveness;

    // Properties
    public int PointerLocation { get => pointerLocation; set => pointerLocation = value; }
    public bool PointerActiveness { get => pointerActiveness; set => pointerActiveness = value; }

    // Start is called before the first frame update
    void Start()
    {
        GetNeededChar();
        wasCorrectList = new List<bool>();
        mistakes = 0;
        backspaceMistakes = 0;
        pointerLocation = 0;
        lastInputChar = '\0';
        ActivatePlayerInput();
    }

    // Update is called once per frame
    void Update()
    {
        GetLastInputChar();
        // check if player is typing or not
        if (this.lastInputChar != '\0')
            CheckChar();
    }

    void ActivatePlayerInput()
    {
        playerInputField = gameObject.GetComponent<InputField>();
        playerInputField.textComponent = gameObject.GetComponent<Text>();
        playerInputField.ActivateInputField();
        playerInputField.Select();
    }
    public void CheckChar()
    {
        if (this.lastInputChar == this.neededChar)
        {
            // Warrior function according to target platform
            Debug.Log("correct");////////////////////
            wasCorrectList.Insert(pointerLocation,true);
            pointerLocation ++;
            GetNeededChar();
        }
        else
        {
            wasCorrectList.Insert(pointerLocation,false);
            this.mistakes ++;
            // warrior becomes vulnerable to enemy high damage
            // backspace check ? pointerLocation-- 
            // enter check ?
        }
    }
    void GetLastInputChar()
    {
        string playerInputString = playerInputField.textComponent.text.ToString();
        if (playerInputString.Length != 0)
        {
            this.lastInputChar = playerInputString[playerInputString.Length - 1];
            playerInputField.textComponent.text.Remove(0);
        }
        else
            this.lastInputChar = '\0';
    }
    void GetNeededChar()
    {
        this.neededChar = this.targetText.GetComponent<Text>().text.ToString()[pointerLocation];
    }
    void OnbackspacePressed()
    {
        bool currentCharWasCorrect;
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (wasCorrectList.Count>0)
            {
                currentCharWasCorrect = wasCorrectList[pointerLocation];
                if (currentCharWasCorrect)
                    this.backspaceMistakes ++;
                else
                    wasCorrectList.RemoveAt(wasCorrectList.Count-1);
            pointerLocation --;
            }   
        }
    }
}
