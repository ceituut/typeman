using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    private Warrior warrior;
    [SerializeField] private GameObject targetPlatform;
    [SerializeField] private GameObject targetText;
    private TMPro.TMP_InputField playerInputField;
    private char lastInputChar;
    private string neededString;
    private char neededChar;
    private int pointerLocation;
    [SerializeField] private int mistakes;
    [SerializeField] private int backspaceMistakes;
    [SerializeField] private int continuousCorrects;
    private List<bool> isTypedCorrectList;
    private bool pointerActiveness;

    public platformManager.StandardPlatform myPlatform;
    // Properties
    public int PointerLocation
    {
        get {return pointerLocation;}
        set {            
                if (value >= 0)
                    pointerLocation = value;
            }
    }
    public bool PointerActiveness { get => pointerActiveness; set => pointerActiveness = value; }

    // Start is called before the first frame update
    void Start()
    {
        warrior = gameObject.GetComponent<Warrior>();
        PointerLocation = 0;
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
        lastInputChar = '\0';
        isTypedCorrectList = new List<bool>();
        neededString = targetText.GetComponent<TextMesh>().text.ToString();
        GetNeededChar();
        ActivatePlayerInput();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActivatePlayerInput()
    {
        playerInputField = gameObject.GetComponent<TMPro.TMP_InputField>();
        playerInputField.textComponent = gameObject.GetComponent<TMPro.TextMeshPro>();
        playerInputField.ActivateInputField();
        playerInputField.Select();
        // Adds listner to the playerInutField and invokes CheckChar() when the value changes
        playerInputField.onValueChanged.AddListener( delegate 
        {
            GetLastInputChar(); 
            CheckChar();
            BonusCorrectsCheck(); 
            GetNeededChar(); 
        });
    }
    public void CheckChar()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            CheckBackspaceMistakes();
            targetText.GetComponent<TextChain>().OneStepBack(pointerLocation); ///// performance
            PointerLocation --;
            continuousCorrects = 0;
        }
        else if (!IsTextEnd())
        {
            targetText.GetComponent<TextChain>().WasTyped(pointerLocation); ///// performance
            if (lastInputChar == neededChar)
            {
                isTypedCorrectList.Add(true);
                PointerLocation ++;
                continuousCorrects ++;
                // Warrior function according to target platform
                warrior.Attack();
            }
            else
            {
                isTypedCorrectList.Add(false);
                mistakes ++;
                PointerLocation ++;
                continuousCorrects = 0;
                // warrior becomes vulnerable to enemy damage
                warrior.Armor --;
            }
        }
        else
        {
            pointerLocation = 0;
            // Text is ended. new text needed.
        }
    }
    public void GetLastInputChar()
    {
        string playerInputString = playerInputField.text.ToString();
        if (playerInputString.Length != 0)
            lastInputChar = playerInputString[playerInputString.Length - 1];
    }
    public void GetNeededChar()
    {
        if (!IsTextEnd()) /////////////////////////////////////////////////
            neededChar = neededString[PointerLocation];
    }
    void ClearInputString()
    {
        playerInputField.text = String.Empty;
    }
    void CheckBackspaceMistakes()
    {
        bool currentCharIsCorrect;
        int length = isTypedCorrectList.Count;
        if (length > 0)
        {
            currentCharIsCorrect = isTypedCorrectList[length-1];
            if (currentCharIsCorrect)
                this.backspaceMistakes ++;
            isTypedCorrectList.RemoveAt(length-1);
        }
    }
    public void BonusCorrectsCheck()
    {
        if (continuousCorrects >= 5)
            warrior.BonusAttack(continuousCorrects);
    }
    bool IsTextEnd()
    {
        if (pointerLocation > neededString.Length -1)
            return true;
        else
            return false;
    }
}
