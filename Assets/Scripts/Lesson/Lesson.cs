using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Lesson
{
    // Fields
    public string name;
    [SerializeField] private int lessonNumber;
    [SerializeField] private string lessonText;
    private List<Letter> crossLanguageLetters;

    // Properties
    public int LessonNumber { get => lessonNumber; set => lessonNumber = value; }
    public string LessonText { get => lessonText;  set => lessonText = value; }
    public List<Letter> CrossLanguageLetters { get => crossLanguageLetters; set => crossLanguageLetters = value; }
}

public struct Letter
{
    public bool IsPrimary;
    public int MapIndex;
}