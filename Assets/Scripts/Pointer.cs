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
    private Platform targetPlatform;
    private InputField playerInputField;
    private TextChain targetTextChain;
    private string textString;
    private int pointerLocation;
    private bool pointerActiveness;

    // Properties
    public TextChain TargetTextChain { get => targetTextChain; set => targetTextChain = value; }
    public Platform TargetPlatform { get => targetPlatform; set => targetPlatform = value; }
    public int PointerLocation { get => pointerLocation; set => pointerLocation = value; }
    public bool PointerActiveness { get => pointerActiveness; set => pointerActiveness = value; }

    // Start is called before the first frame update
    void Start()
    {
        GetNeededChar();
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
            pointerLocation ++;
            GetNeededChar();
        }
        else
        {
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
        this.neededChar = this.TargetTextChain.ToString()[pointerLocation];
    }
}
