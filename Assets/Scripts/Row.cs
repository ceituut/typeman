using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName="Row",menuName="TypeMan/Row")]
[System.Serializable]
public class Row : ScriptableObject
{
    // Fields
    public List<string> primaryKeyValue;
    public List<string> secondaryKeyValue;

    public List<Row> rowList = new List<Row>();

    public Row()
    {
        primaryKeyValue = new List<string>         
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace"
        };
        secondaryKeyValue = new List<string>         
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace"
        };
    }
    private void OnEnable() {
        primaryKeyValue = new List<string>         
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace"
        };
        secondaryKeyValue = new List<string>         
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace"
        };
        rowList.Add(this);
    }
    private void Awake() {
        primaryKeyValue = new List<string>         
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","backspace"
        };
        secondaryKeyValue = new List<string>         
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","backspace"
        };
    }
}
