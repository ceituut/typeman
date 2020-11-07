using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class StandardSelect : MonoBehaviour
{
    // Fields
    [SerializeField] private StandardChange standardChange;
    private Dropdown dropdownComponent;

    // Methods
    private void Awake()
    {
        InitializeDropdown();
    }
    private void InitializeDropdown()
    {
        dropdownComponent = gameObject.GetComponent<Dropdown>();
        string standardTypeName;
        StandardTypes standardType = 0;
        int numberOfStandardTypes = Enum.GetNames(typeof(StandardTypes)).Length;
        for (int index = 0; index < numberOfStandardTypes; index++)
        {
            standardTypeName = standardType.ToString();
            dropdownComponent.options.Add(new Dropdown.OptionData(standardTypeName));
            standardType ++;
        }
        dropdownComponent.onValueChanged.AddListener( delegate { OnStandardTypeChanged(); } );
    }
    private StandardTypes GetStandardTypeOfOption(string standardTypeName)
    {
        StandardTypes relatedStandardType = 0;
        StandardTypes standardType = 0;
        int numberOfStandardTypes = Enum.GetNames(typeof(StandardTypes)).Length;
        for (int index = 0; index < numberOfStandardTypes; index++ , standardType++)
            if ( standardType.ToString() == standardTypeName )
                relatedStandardType = standardType;
        return relatedStandardType;
    }
    private void OnStandardTypeChanged()
    {
        Dropdown.OptionData currentOption = dropdownComponent.options[dropdownComponent.value];
        StandardTypes currentStandard = GetStandardTypeOfOption(currentOption.text);
        standardChange.ChangeStandard(currentStandard);
    }
}