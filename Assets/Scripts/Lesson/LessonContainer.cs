using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Definition;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName="LessonContainer",
menuName="TypeMan/LessonContainer")]
public class LessonContainer : ScriptableObject
{
    // Fields
    [SerializeField] private List<Lesson> lessonList;


    // Properties
    public List<Lesson> LessonList { get => lessonList; set => lessonList = value; }

    // Methods
    private void Awake()
    {
        lessonList = new List<Lesson>();
    }
}


#if UNITY_EDITOR
[CustomEditor(typeof(LessonContainer))]
public class LessonContainerEditor : Editor {
    private Dictionary<string,int> primaryLetterToIndexMap;
    private Dictionary<string,int> secondaryLetterToIndexMap;
    public override void OnInspectorGUI() {
        var script = target as LessonContainer;
        InitializePrimaryLetterDic();
        InitializeSecondaryLetterDic();
        base.DrawDefaultInspector();
        if(GUILayout.Button("Calculate Cross-Language Letters"))
            foreach(Lesson lesson in script.LessonList)
                lesson.CrossLanguageLetters = GetLetterList(lesson);
    }
    private void InitializePrimaryLetterDic()
    {
        primaryLetterToIndexMap = new Dictionary<string, int>();
        foreach(string thisLetter in primaryLetters)
            primaryLetterToIndexMap.Add(thisLetter,primaryLetters.IndexOf(thisLetter));
    }
    private void InitializeSecondaryLetterDic()
    {
        secondaryLetterToIndexMap = new Dictionary<string, int>();
        foreach(string thisLetter in secondaryLetters)
            secondaryLetterToIndexMap.Add(thisLetter,secondaryLetters.IndexOf(thisLetter));
    }
    private List<Letter> GetLetterList(Lesson lesson)
    {
        bool isLetterInPrimary = false;
        Letter letter;
        int letterIndex , charIndex = 0;
        lesson.CrossLanguageLetters = new List<Letter>();
        foreach(char thisChar in lesson.LessonText)
        {
            letter = new Letter();
            isLetterInPrimary = primaryLetterToIndexMap.TryGetValue(thisChar.ToString() , out letterIndex);
            if (isLetterInPrimary)
            {
                letter.IsPrimary = true;
                letter.MapIndex = letterIndex;
            }
            else
            {
                secondaryLetterToIndexMap.TryGetValue(thisChar.ToString() , out letterIndex);
                letter.IsPrimary = false;
                letter.MapIndex = letterIndex;
            }
            AddLeter(lesson , letter , charIndex);
            charIndex ++;
        }
        return lesson.CrossLanguageLetters;
    }
    private void AddLeter(Lesson lesson , Letter letter , int targetIndex)
    {
        int count = lesson.CrossLanguageLetters.Count;
        if(targetIndex >= count)
            lesson.CrossLanguageLetters.Add(letter);
        else
            lesson.CrossLanguageLetters[targetIndex] = letter;
    }
}
#endif