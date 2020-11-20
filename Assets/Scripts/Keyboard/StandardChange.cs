using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Definition;


public class StandardChange : MonoBehaviour
{
    // Fields
    private Keyboard keyboard;
    private StandardTypes currentType;
    [SerializeField] private Key LeftHiddenKey;
    [SerializeField] private Key RightHiddenKey;
    [SerializeField] private Key LeftShift;
    [SerializeField] private Key RightShift;

    // Properties
    public StandardTypes GetCurrentType {get => currentType;}

    // Methods
    private void Awake()
    {
        keyboard = gameObject.GetComponent<Keyboard>();
    }
    public void ChangeStandard(StandardTypes standard)
    {
        currentType = standard;
        switch(currentType)
        {
            case StandardTypes.the104key :
                MakeIt104Key();
                break;
            case StandardTypes.the105key :
                MakeIt105Key();
                break;
            case StandardTypes.the107key :
                MakeIt107Key();
                break;
        }
    }
    public void MakeIt104Key()
    {
        keyboard.ChangeKeyWidthByRef(LeftShift , 0);
        keyboard.ChangeKeyWidthByRef(RightShift , 0);
        LeftHiddenKey.gameObject.SetActive(false);
        RightHiddenKey.gameObject.SetActive(false);
    }
    public void MakeIt105Key()
    {
        keyboard.ChangeKeyWidthByRef(LeftShift , -1.2f);
        keyboard.ChangeKeyWidthByRef(RightShift , 0);
        LeftHiddenKey.gameObject.SetActive(true);
        RightHiddenKey.gameObject.SetActive(false);
    }
    public void MakeIt107Key()
    {
        keyboard.ChangeKeyWidthByRef(LeftShift , -1.2f);
        keyboard.ChangeKeyWidthByRef(RightShift , -1.2f);
        LeftHiddenKey.gameObject.SetActive(true);
        RightHiddenKey.gameObject.SetActive(true);
    }
}