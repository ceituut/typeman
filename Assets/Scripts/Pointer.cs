using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    [SerializeField] private Warrior warrior;
    private GameObject targetPlatform;
    private GameObject targetText;
    private Report currentReport;
    private TMPro.TMP_InputField playerInputField;
    [SerializeField] private string neededString;
    [SerializeField] private char neededChar;
    private char lastInputChar;
    [SerializeField] private int pointerLocation;

    // Properties
    public int PointerLocation
    {
        get {return pointerLocation;}
        set {            
                if (value >= 0)
                    pointerLocation = value;
            }
    }
    public GameObject TargetPlatform { get => targetPlatform; set => targetPlatform = value; }

    // Methods
    private void Start()
    {
        warrior = gameObject.GetComponentInParent<Warrior>();
        currentReport = new Report();
    }
    private void Update()
    {
        KeepActiveInputField();
    }
    public void InitializePointer(GameObject newPlatform)
    {
        warrior.PointerList.Add(this);
        currentReport = new Report();
        InitializeNeededString(newPlatform);
        InitializeInputField();
    }
    private void InitializeNeededString(GameObject targetPlatform)
    {
        PointerLocation = 0;
        targetText = targetPlatform.GetComponent<Platform>().textChild;
        neededString = targetText.GetComponent<TextMesh>().text.ToString();
    }
    private void InitializeInputField()
    {
        playerInputField = gameObject.GetComponent<TMPro.TMP_InputField>();
        playerInputField.textComponent = gameObject.GetComponent<TMPro.TextMeshPro>();
        ActivateInputField();
        // Removes previous lisntners
        if(warrior.PointerList.Count != 0)
            playerInputField.onValueChanged.RemoveAllListeners();
        // Adds listner to the playerInutField and invokes CheckOperation() when the value changes
        playerInputField.onValueChanged.AddListener( delegate { CheckOperation(); });
    }
    private void ActivateInputField()
    {
        playerInputField.ActivateInputField();
        playerInputField.Select();
    }
    private void KeepActiveInputField()
    {
        if(Input.GetKey(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse1) 
        || Input.GetKey(KeyCode.Mouse2) || Input.GetKey(KeyCode.Mouse3) 
        || Input.GetKey(KeyCode.Mouse4) || Input.GetKey(KeyCode.Mouse5)
        || Input.GetKey(KeyCode.Mouse6))
            ActivateInputField();
    }
    private void CheckOperation()
    {
        if (!IsTextEnd())
        {
            GetLastInputChar();
            GetNeededChar();
            CheckInput();
            BonusCorrectsCheck(); 
        }
        else
            pointerLocation = 0; // Text is ended
    }
    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (currentReport.CanBackespace())
            {
                currentReport.CheckBackspaceMistakes();
                targetText.GetComponent<TextChain>().OneStepBack(pointerLocation);
                PointerLocation --;
            }
            currentReport.ContinuousCorrects = 0;
        }
        else
            CheckChar();
    }
    private void CheckChar()
    {
        targetText.GetComponent<TextChain>().WasTyped(pointerLocation);
        if (lastInputChar == neededChar)
            PerformCorrectAction();
        else
            PerformMistakeAction();
    }
    private void PerformCorrectAction()
    {
        currentReport.AddCorrect();
        PointerLocation ++;
        // Warrior function according to target platform
        // warrior.PerformOperation(TargetPlatform.GetComponent<Platform>().platformType);
    }
    private void PerformMistakeAction()
    {
        currentReport.AddMistake();
        PointerLocation ++;
        // warrior becomes vulnerable to enemy damage
        // warrior.Armor --;
    }
    private void GetLastInputChar()
    {
        string playerInputString = playerInputField.text.ToString();
        if (playerInputString.Length != 0)
            lastInputChar = playerInputString[playerInputString.Length - 1];
    }
    private void GetNeededChar()
    {
        neededChar = neededString[PointerLocation];
    }
    private void ClearInputString()
    {
        playerInputField.text = String.Empty;
    }
    private void BonusCorrectsCheck()
    {
        if (currentReport.ContinuousCorrects >= 5)
            warrior.BonusAttack(currentReport.ContinuousCorrects);
    }
    private bool IsTextEnd()
    {
        return (pointerLocation > (neededString.Length -1));
    }
}
