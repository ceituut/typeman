using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static KeyboardDefinition;


public class LessonLanguageChange : MonoBehaviour
{
    // Fields
    [SerializeField] private LessonContainer lessonContainer;

    // Methods
    public void ChangeLessonLanguage(Language targetLanguage)
    {
        foreach(Lesson lesson in lessonContainer.LessonList)
            for(int charIndex = 0; charIndex < lesson.LessonText.Length; charIndex++)
                lesson.LessonText.Replace(lesson.LessonText[charIndex] , GetAlternativeChar(lesson , targetLanguage , charIndex));
    }
    private char GetAlternativeChar(Lesson lesson , Language language , int charIndex)
    {
        int letterIndex = lesson.CrossLanguageLetters[charIndex].MapIndex;
        if( lesson.CrossLanguageLetters[charIndex].IsPrimary)
            return Convert.ToChar(language.primaryKeyList[letterIndex]);
        else
            return Convert.ToChar(language.secondaryKeyList[letterIndex]);
    }
}