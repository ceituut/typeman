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
    private int numberOfCorrected;
    private List<bool> isTypedCorrectList;
    private List<float> charDelayTimeList;
    private float previousTime;

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
    public int BackspaceMistakes { get => backspaceMistakes; set => backspaceMistakes = value; }
    public int NumberOfCorrected { get => numberOfCorrected; set => numberOfCorrected = value; }

    // Constructor
    public Progress()
    {
        pointerLocation = 0;
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
        numberOfCorrected = 0;
        isTypedCorrectList = new List<bool>();
        charDelayTimeList = new List<float>();
        previousTime = 0;
    }

    // Methods
    public void MakeCorrect()
    {
        if (isTypedCorrectList.Count <= pointerLocation)
            isTypedCorrectList.Add(true);
        else
        {
            if (!isTypedCorrectList[pointerLocation])
                numberOfCorrected ++;
            isTypedCorrectList[pointerLocation] = true;
        }
        continuousCorrects ++;
    }
    public void MakeMistake()
    {
        if (isTypedCorrectList.Count <= pointerLocation)
            isTypedCorrectList.Add(false);
        else
            isTypedCorrectList[pointerLocation] = false;
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
        }
    }
    public void UpdateCharDelay()
    {
        float delay = (UnityEngine.Time.time ) - previousTime;
        if ( charDelayTimeList.Count <= pointerLocation)
            charDelayTimeList.Add(delay);
        else
            charDelayTimeList[pointerLocation] = delay;
        previousTime += delay;
    }
}
