using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Definition;


public class EnterSelect : MonoBehaviour
{
    // Fields
    [SerializeField] private EnterChange enterChange;
    private Dropdown dropdownComponent;

    // Methods
    private void Awake()
    {
        InitializeDropdown();
    }
    private void InitializeDropdown()
    {
        dropdownComponent = gameObject.GetComponent<Dropdown>();
        string enterTypeName;
        EnterTypes enterType = 0;
        int numberOfEnterTypes = Enum.GetNames(typeof(EnterTypes)).Length;
        for (int index = 0; index < numberOfEnterTypes; index++)
        {
            enterTypeName = enterType.ToString();
            dropdownComponent.options.Add(new Dropdown.OptionData(enterTypeName));
            enterType ++;
        }
        dropdownComponent.onValueChanged.AddListener( delegate { OnEnterTypeChanged(); } );
    }
    private EnterTypes GetEnterTypeOfOption(string enterTypeName)
    {
        EnterTypes relatedEnterType = 0;
        EnterTypes enterType = 0;
        int numberOfEnterTypes = Enum.GetNames(typeof(EnterTypes)).Length;
        for (int index = 0; index < numberOfEnterTypes; index++ , enterType++)
            if ( enterType.ToString() == enterTypeName )
                relatedEnterType = enterType;
        return relatedEnterType;
    }
    private void OnEnterTypeChanged()
    {
        Dropdown.OptionData currentOption = dropdownComponent.options[dropdownComponent.value];
        EnterTypes currentEnter = GetEnterTypeOfOption(currentOption.text);
        enterChange.ChangeEnter(currentEnter);
    }
}