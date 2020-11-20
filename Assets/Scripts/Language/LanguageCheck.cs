using System;
using System.Collections;
using System.Collections.Generic;
using static Definition;

public class LanguageCheck
{
    private Dictionary<string,bool> primaryKeyChecker;
    private Dictionary<string,bool> secondaryKeyChecker;
    public void UpdateKeyCheckers(Language currentLanguage)
    {
        primaryKeyChecker = new Dictionary<string, bool>();
        secondaryKeyChecker = new Dictionary<string, bool>();
        bool isThisKeyExists;
        foreach ( string keyString in currentLanguage.primaryKeyList)
        {
            isThisKeyExists = false;
            primaryKeyChecker.TryGetValue( keyString , out isThisKeyExists);
            if ( !isThisKeyExists )
                primaryKeyChecker.Add( keyString , true);
        }
        foreach ( string keyString in currentLanguage.secondaryKeyList)
        {
            isThisKeyExists = false;
            secondaryKeyChecker.TryGetValue( keyString , out isThisKeyExists);
            if ( !isThisKeyExists )
                secondaryKeyChecker.Add( keyString , true);
        }
    }
    public bool IsLanguageWrong(string lastInputChar)
    {
        bool keyFound = false;
        bool isLanguageWrong = false;
        primaryKeyChecker.TryGetValue(lastInputChar, out keyFound);
        if ( !keyFound )
            secondaryKeyChecker.TryGetValue(lastInputChar, out keyFound);
        isLanguageWrong = !keyFound;
        return isLanguageWrong;
    }
}