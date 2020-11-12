using System;
using System.Collections;
using System.Collections.Generic;
public static class KeyboardDefinition
{
    public enum KeyboardLanguage { English , Persian , Arabic , Turkish ,French , German , Italian , 
    Russsion , Japanese , Chinese , Korean , Espanian };
    public enum  StandardTypes { the104key , the105key , the107key };
    public enum EnterTypes { flat , high , big };
    public static List<string> primaryLetters = new List<string>()
    {
        "`","1","2","3","4","5","6","7","8","9","0","-","=",
        "q","w","e","r","t","y","u","i","o","p","[","]","\\",
        "a","s","d","f","g","h","j","k","l",";","'",
        "z","x","c","v","b","n","m",",",".","/"
    };
    public static List<string> secondaryLetters = new List<string>()
    {
        "~","!","@","#","$","%","^","&","*","(",")","_","+",
        "Q","W","E","R","T","Y","U","I","O","P","{","}","|",
        "A","S","D","F","G","H","J","K","L",":","\"",
        "Z","X","C","V","B","N","M","<",">","?"
    };
}