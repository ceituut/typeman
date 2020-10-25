using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardLayout : ScriptableObject
{
    // Fields
    // Keyboard (without/with Shift key) string values 
    [SerializeField] protected List<string> primaryKeyList;
    [SerializeField] protected List<string> secondaryKeyList;
    // limited number of keys in each row
    protected List<int> limitedRows;

    // Properties
    public List<string> GetPrimaryKeyList { get => primaryKeyList;}
    public List<string> GetSecondaryKeyList { get => secondaryKeyList;}
    public List<int> GetLimitedRows { get => limitedRows;}

    // Methods
    public abstract void InitializeDefualt();
    public abstract void InitializeRowLimits();
}