using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public abstract class KeyboardLayout : ScriptableObject
{
    // Fields
        // Keyboard (without/with Shift key) string values 
    [SerializeField] protected List<string> primaryKeyList;
    [SerializeField] protected List<string> secondaryKeyList;
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


    // Properties
    public List<string> GetPrimaryKeyList { get => primaryKeyList;}
    public List<string> GetSecondaryKeyList { get => secondaryKeyList;}
    public List<int> GetEndIndexInRows { get => endIndexInRows;}
    public List<float> GetKeyWidthList { get => keyWidthList;}


    // Methods
    // Abstract methods
    public abstract void InitializeDefualt();
    protected abstract void InitializeKeyWidthList();
    protected abstract void InitializeEndStringInRows();
    public abstract void AdjustRows();
    public abstract void MakeIt105Key();
    public abstract void MakeIt107Key();
    public abstract void MakeEnterHigh();
    public abstract void MakeEnterBig();


    // Common methods
    public void InitializeEndIndexInRows()
    {
        int row0Limit = primaryKeyList.IndexOf(endStringInRows[0]);
        int row1Limit = primaryKeyList.IndexOf(endStringInRows[1]);
        int row2Limit = primaryKeyList.IndexOf(endStringInRows[2]);
        int row3Limit = primaryKeyList.IndexOf(endStringInRows[3]);
        int row4Limit = primaryKeyList.IndexOf(endStringInRows[4]);
        endIndexInRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public void InsertNewKey(int targetIndex , string primaryKey , string secondaryKey , float width)
    {
        primaryKeyList.Insert(targetIndex , primaryKey);
        secondaryKeyList.Insert(targetIndex , secondaryKey);
        keyWidthList.Insert(targetIndex , width);
    }
    public void UpdateKey(int targetIndex , string primaryKey , string secondaryKey , float width)
    {
        primaryKeyList[targetIndex] = primaryKey;
        secondaryKeyList[targetIndex] = secondaryKey;
        keyWidthList[targetIndex] = width;
    }
    public void AddKeyWidthMembers()
    {
        keyWidthList = new List<float>();
        for(int index = 0; index < primaryKeyList.Count; index++)
            keyWidthList.Add(1);
    }
    // public void SetWidthForRangeOfKeys(string startKey , string endKey , float targetValue)
    // {
    //     int startIndex = primaryKeyList.IndexOf(startKey);
    //     int endIndex = primaryKeyList.IndexOf(endKey);
    //     for (int index = startIndex; index <= endIndex; index++)
    //         keyWidthList[index] = targetValue;
    // }
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

// [CustomEditor(typeof(WindowsDesktop))]
// public class KeyboardLayoutEditor : Editor {
//     public override void OnInspectorGUI() {
//         var script = target as WindowsDesktop;
//         DrawDefaultInspector();
//         for(int index =0 ; index < script.GetPrimaryKeyList.Count ; index++)
//             script.GetKeyWidthList[index] = EditorGUILayout.FloatField(script.GetPrimaryKeyList[index],script.GetKeyWidthList[index]);
//     }
// }