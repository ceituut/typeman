using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CustomInputField : TMPro.TMP_InputField
{ 
    public override void OnDeselect(BaseEventData eventData)
    {
        // Do nothing
        base.Select();
        base.ActivateInputField();
        Debug.Log("deselected");
    }
    public override void OnSelect(BaseEventData eventData)
    {
        
    }
}
