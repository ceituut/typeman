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
    [SerializeField] private Text targetText;

    // Methods
    public void ChangeLessonLanguage(Language targetLanguage)
    {
        string editString;
        foreach(Lesson lesson in lessonContainer.LessonList)
        {
            editString = lesson.LessonText;
            for(int charIndex = 0; charIndex < lesson.LessonText.Length; charIndex++)
                editString = editString.Replace(lesson.LessonText[charIndex] , GetAlternativeChar(lesson , targetLanguage , charIndex));;
            targetText.text = editString;///////////////////////////////////////////////
        }
    }
    private char GetAlternativeChar(Lesson lesson , Language language , int charIndex)
    {
        int letterIndex = lesson.CrossLanguageLetters[charIndex].MapIndex;
        if( lesson.CrossLanguageLetters[charIndex].IsPrimary)
            if(language.primaryKeyList[letterIndex] == string.Empty)
                return ' ';
            else
                return Convert.ToChar(language.primaryKeyList[letterIndex]);
        else
            if(language.secondaryKeyList[letterIndex] == string.Empty)
                return ' ';
            else
                return Convert.ToChar(language.secondaryKeyList[letterIndex]);
    }
}