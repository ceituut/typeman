using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class KeyboardLayout : ScriptableObject
{
    // Fields
        // Keyboard (without/with Shift key) string values 
    protected List<string> defaultKeyList;
        // String value of last key in each row
    protected List<string> endStringInRows;
        // Index of last key in each row
    protected List<int> endIndexInRows;
        // Width of each key in percent
    protected List<float> keyWidthList;
        // Space between keys
    protected float keySpace;
        // Typical row width that other width of rows will be equayl to that.
    protected float typicalRowWidth;
        // An object that provides change options
    protected KeyboardChanger changer;


    // Properties
    public List<string> GetDefaultKeyList { get => defaultKeyList;}
    public List<int> GetEndIndexInRows { get => endIndexInRows;}
    public List<float> GetKeyWidthList { get => keyWidthList;}
    public KeyboardChanger GetChanger { get => changer; set => changer = value; }


    // Methods
    // Abstract methods
    public abstract void InitializeDefualt();
    protected abstract void InitializeKeyWidthList();
    protected abstract void InitializeEndStringInRows();
    public abstract void AdjustRows();


    // Common methods
    public void InitializeEndIndexInRows()
    {
        int row0Limit = defaultKeyList.IndexOf(endStringInRows[0]);
        int row1Limit = defaultKeyList.IndexOf(endStringInRows[1]);
        int row2Limit = defaultKeyList.IndexOf(endStringInRows[2]);
        int row3Limit = defaultKeyList.IndexOf(endStringInRows[3]);
        int row4Limit = defaultKeyList.IndexOf(endStringInRows[4]);
        endIndexInRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public void InsertNewKey(int targetIndex , string newKey , float width)
    {
        defaultKeyList.Insert(targetIndex , newKey);
        keyWidthList.Insert(targetIndex , width);
    }
    public void UpdateKey(int targetIndex , string newKey , float width)
    {
        defaultKeyList[targetIndex] = newKey;
        keyWidthList[targetIndex] = width;
    }
    public void UpdateKey(string targetKey , float width)
    {
        int targetIndex = defaultKeyList.IndexOf(targetKey);
        keyWidthList[targetIndex] = width;
    }
    public void AddKeyWidthMembers()
    {
        keyWidthList = new List<float>();
        for(int index = 0; index < defaultKeyList.Count; index++)
            keyWidthList.Add(1);
    }
    public float GetWidthOfRangeOfKeys(string startKey , string endKey)
    {
        int startIndex = defaultKeyList.IndexOf(startKey);
        int endIndex = defaultKeyList.IndexOf(endKey);
        float totalWidth = 0;
        for (int index = startIndex; index <= endIndex; index++)
            totalWidth += keyWidthList[index];
        totalWidth += (( endIndex - startIndex ) * keySpace);
        return totalWidth;
    }
    public void FixLastKeyWidthOfThisRange(string startKey , string endKey)
    {
        int endIndex = defaultKeyList.IndexOf(endKey);
        float targetRowWidth = GetWidthOfRangeOfKeys(startKey , endKey);
        float offset = Mathf.Abs(typicalRowWidth - targetRowWidth);
        if (typicalRowWidth >= targetRowWidth)
            keyWidthList[endIndex] = keyWidthList[endIndex] + offset;
        else
            keyWidthList[endIndex] = keyWidthList[endIndex] - offset;
    }
    public void CalcTypicalRowWidth()
    {
        // We use first row width as typical row width.
        // other rows width will be equal to this width.
        typicalRowWidth = 0;
        for (int index = 0; index <= endIndexInRows[0]; index ++)
            typicalRowWidth += keyWidthList[index];
        typicalRowWidth += (( endIndexInRows[0]) * keySpace);  
    }
}