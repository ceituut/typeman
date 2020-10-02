using System.Collections;
using System.Collections.Generic;

public class Progress
{
    // Fields
    private UnityEngine.GameObject targetPlatform; 
    private int pointerLocation;
    private int mistakes;
    private int backspaceMistakes;
    private int continuousCorrects;
    private List<bool> isTypedCorrectList;

    // Properties
    public UnityEngine.GameObject TargetPlatform { get => targetPlatform; set => targetPlatform = value; }
    public int PointerLocation
    {
        get {return pointerLocation;}
        set {            
                if (value >= 0)
                    pointerLocation = value;
            }
    }
    public int ContinuousCorrects { get => continuousCorrects; set => continuousCorrects = value; }
    public List<bool> IsTypedCorrectList { get => isTypedCorrectList; set => isTypedCorrectList = value; }
    public int Mistakes { get => mistakes; set => mistakes = value; }

    // Constructor
    public Progress()
    {
        pointerLocation = 0;
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
        isTypedCorrectList = new List<bool>();
    }

    // Methods
    public void AddCorrect()
    {
        isTypedCorrectList.Add(true);
        continuousCorrects ++;
    }
    public void AddMistake()
    {
        isTypedCorrectList.Add(false);
        mistakes ++;
        continuousCorrects = 0;
    }
    public bool CanBackespace()
    {
        return isTypedCorrectList.Count != 0;
    }
    public void CheckBackspaceMistakes()
    {
        bool currentCharIsCorrect;
        int length = isTypedCorrectList.Count;
        if (length > 0)
        {
            currentCharIsCorrect = isTypedCorrectList[length-1];
            if (currentCharIsCorrect)
                backspaceMistakes ++;
            else
                mistakes --;
            isTypedCorrectList.RemoveAt(length-1);
        }
    }
}
