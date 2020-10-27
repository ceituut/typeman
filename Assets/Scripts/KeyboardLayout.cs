using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardLayout : ScriptableObject
{
    // Fields
        // Keyboard (without/with Shift key) string values 
    [SerializeField] protected List<string> primaryKeyList;
    [SerializeField] protected List<string> secondaryKeyList;
        // Number of keys in each row
    [SerializeField] protected List<int> endIndexInRows;
        // Width of each row in percent
    [SerializeField] protected List<float> rowWidthList;
        // Width of each key in percent
    [SerializeField] protected List<float> keyWidthList;
        // Space between keys
    [SerializeField] protected float keySpace;


    // Properties
    public List<string> GetPrimaryKeyList { get => primaryKeyList;}
    public List<string> GetSecondaryKeyList { get => secondaryKeyList;}
    public List<int> GetEndIndexInRows { get => endIndexInRows;}
    protected List<float> GetRowWidthList { get => rowWidthList;}
    public List<float> GetKeyWidthList { get => keyWidthList;}


    // Methods
    // Abstract methods
    public abstract void InitializeDefualt();
    public abstract void InitializeEndIndexInRows();
    public abstract void InitializeRowWidthList();
    public abstract void InitializeKeyWidthList();
    public abstract void MakeIt104Key();
    public abstract void MakeIt105Key();
    public abstract void MakeIt107Key();
    public abstract void MakeEnterFlat();
    public abstract void MakeEnterHigh();
    public abstract void MakeEnterBig();


    // Common methods
    public void AddRowWidthMembers()
    {
        rowWidthList = new List<float>();
        for(int index = 0; index < endIndexInRows.Count; index++)
            rowWidthList.Add(1);
    }
    public void AddKeyWidthMembers()
    {
        keyWidthList = new List<float>();
        for(int index = 0; index < primaryKeyList.Count; index++)
            keyWidthList.Add(1);
    }
    public void SetWidthForRangeOfKeys(string startKey , string endKey , float targetValue)
    {
        int startIndex = primaryKeyList.IndexOf(startKey);
        int endIndex = primaryKeyList.IndexOf(endKey);
        for (int index = startIndex; index <= endIndex; index++)
            keyWidthList[index] = targetValue;
    }
    public float GetWidthOfRangeOfKeys(string startKey , string endKey)
    {
        int startIndex = primaryKeyList.IndexOf(startKey);
        int endIndex = primaryKeyList.IndexOf(endKey);
        float totalWidth = 0;
        for (int index = startIndex; index <= endIndex; index++)
            totalWidth += keyWidthList[index];
        totalWidth += (( endIndex - startIndex ) * keySpace);
        return totalWidth;
    }
    public void SetWidthForSpecificKey(string targetKey , float targetValue)
    {
        int targetIndex = primaryKeyList.IndexOf(targetKey);
        keyWidthList[targetIndex] = targetValue;
    }
    public void FixLastKeyWidthOfThisRow(string startKey , string endKey)
    {
        int endIndex = primaryKeyList.IndexOf(endKey);
        float typicalRowWidth = GetTypicalRowWidth();
        float targetRowWidth = GetWidthOfRangeOfKeys(startKey , endKey);
        float offset = Mathf.Abs(typicalRowWidth - targetRowWidth);
        if (typicalRowWidth >= targetRowWidth)
            keyWidthList[endIndex] = keyWidthList[endIndex] + offset;
        else
            keyWidthList[endIndex] = keyWidthList[endIndex] - offset;
    }
    public float GetTypicalRowWidth()
    {
        // We use first row width as typical row width.
        // other rows width will be equal to this width.
        float typicalRowWidth = 0;
        for (int index = 0; index <= endIndexInRows[0]; index ++)
            typicalRowWidth += keyWidthList[index];
        typicalRowWidth += (( endIndexInRows[0]) * keySpace);  
        return typicalRowWidth;
    }

}