using System.Collections;
using System.Collections.Generic;

public class Report
{
    // Fields 
    private int mistakes;
    private int backspaceMistakes;
    private int continuousCorrects;
    private List<bool> isTypedCorrectList;

    // Properties
    public int ContinuousCorrects { get => continuousCorrects; set => continuousCorrects = value; }
    public List<bool> IsTypedCorrectList { get => isTypedCorrectList; set => isTypedCorrectList = value; }

    public Report()
    {
        mistakes = 0;
        backspaceMistakes = 0;
        continuousCorrects = 0;
        isTypedCorrectList = new List<bool>();
    }
    public void InitializeReport() 
    {
    }
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
                this.backspaceMistakes ++;
            isTypedCorrectList.RemoveAt(length-1);
        }
    }
}
