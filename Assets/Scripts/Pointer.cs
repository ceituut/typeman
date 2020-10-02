using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    // Fields
    [SerializeField] private Warrior warrior;
    private Progress progressObject;
    private GameObject targetText;
    private TMPro.TMP_InputField playerInputField;
    [SerializeField] private string neededString;
    [SerializeField] private char neededChar;
    private char lastInputChar;


    // Methods
    private void Start()
    {
        warrior = gameObject.GetComponentInParent<Warrior>();
        InitializeInputField();
        AllowCheck();
    }
    private void Update()
    {
        KeepActiveInputField();
    }
    public void UpdatePointer(Progress currentProgress)
    {
        progressObject = currentProgress;
        GameObject platformObject = progressObject.TargetPlatform;
        targetText = platformObject.GetComponent<Platform>().textChild;
        neededString = targetText.GetComponent<TextChain>().InitialTextString;
        ResetInput();
    }
    private void ResetInput()
    {
        // Removes previous lisntners if exists
        if(warrior.ProgressList.Count != 0)
            playerInputField.onValueChanged.RemoveAllListeners();
        ClearInput();
        AllowCheck();
    }
    public void InitializePointer(GameObject newPlatform)
    {
        progressObject = new Progress();
        warrior.ProgressList.Add(progressObject);
        InitializeNeededString(newPlatform);
        ResetInput();
    }
    private void InitializeNeededString(GameObject thisPlatform)
    {
        progressObject.TargetPlatform = thisPlatform; 
        targetText = thisPlatform.GetComponent<Platform>().textChild;
        neededString = targetText.GetComponent<TextChain>().InitialTextString;
    }
    private void InitializeInputField()
    {
        playerInputField = gameObject.GetComponent<TMPro.TMP_InputField>();
        playerInputField.textComponent = gameObject.GetComponent<TMPro.TextMeshPro>();
        playerInputField.characterLimit = 5;
        ActivateInputField();
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
            ResetInput();
        }
        else
        {
            DontAllowCheck();
        }
    }
    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.Backspace))
        {
            if (progressObject.CanBackespace())
            {
                progressObject.CheckBackspaceMistakes();
                targetText.GetComponent<TextChain>().OneStepBack(progressObject.PointerLocation , progressObject);
                progressObject.PointerLocation --;
            }
            progressObject.ContinuousCorrects = 0;
        }
        else
            CheckChar();
    }
    private void CheckChar()
    {
        if (lastInputChar == neededChar)
            PerformCorrectAction();
        else
            PerformMistakeAction();
        targetText.GetComponent<TextChain>().WasTyped(progressObject.PointerLocation , progressObject);
        progressObject.PointerLocation ++;
    }
    private void PerformCorrectAction()
    {
        progressObject.AddCorrect();
        // Warrior function according to target platform
        // warrior.PerformOperation(TargetPlatform.GetComponent<Platform>().platformType);
    }
    private void PerformMistakeAction()
    {
        progressObject.AddMistake();
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
        neededChar = neededString[progressObject.PointerLocation];
    }
    public void ClearInput()
    {
        playerInputField.text = String.Empty;
    }
    public void AllowCheck()
    {
        // Adds listner to the playerInutField and invokes CheckOperation() when the value changes
        playerInputField.onValueChanged.AddListener( delegate { CheckOperation(); });
    }
    public void DontAllowCheck()
    {
        playerInputField.onValueChanged.RemoveAllListeners();
    }
    private void BonusCorrectsCheck()
    {
        if (progressObject.ContinuousCorrects >= 5)
            warrior.BonusAttack(progressObject.ContinuousCorrects);
    }
    private bool IsTextEnd()
    {
        return (progressObject.PointerLocation > (neededString.Length -1));
    }
}
