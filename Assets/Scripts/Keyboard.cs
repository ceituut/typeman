using System.Collections;
using System.Collections.Generic;
using System.Linq;

public static class KeyboardDef
{
    public enum languages { English , Farsi }
    public enum keyboardTypes 
    { 
        WindowsDesktop , WindowsErgonomic1 , WindowsErgonomic2 , 
        WindowsPortable1 , WindowsPortable2 , WindowsPortable3 , WindowsPocket1 ,
        MacDesktop , MacPortable
    };
    public enum numberOfKeysTypes { key104 , key105 , key107 };
    public enum enterTypes { flat , high , big };
}




public abstract class Keyboard
{
    // Fields
        // Keyboard (without/with Shift key) string values 
    protected List<string> primaryKeyList;
    protected List<string> secondaryKeyList;
    // limited number of keys in each row
    protected List<int> limitedRows;

    // Properties
    public List<string> GetPrimaryKeyList { get => primaryKeyList;}
    public List<string> GetSecondaryKeyList { get => secondaryKeyList;}
    public List<int> GetLimitedRows { get => limitedRows;}

    // Methods
    public abstract void InitializeDefualt();
    public abstract void InitializeRowLimits();
        // Number of keys 
    public abstract void MakeIt104Key();
    public abstract void MakeIt105Key();
    public abstract void MakeIt107Key();
        // Enter Types
    public abstract void MakeEnterFlat();
    public abstract void MakeEnterHigh();
    public abstract void MakeEnterBig();
}




public class WinDesktop : Keyboard
{
    // Constructor
    public WinDesktop()
    {
        InitializeDefualt();
    }

    // Methods
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/","Shift",
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu","Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?","Shift",
            "Ctrl","Win","Alt","Space","AltGr","Win","Menu","Ctrl"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("Backspace") + 1;
        int row1Limit = primaryKeyList.IndexOf("\\") + 1 - row0Limit;
        int row2Limit = primaryKeyList.IndexOf("Enter") + 1 - row1Limit;
        int row3Limit = primaryKeyList.IndexOf("Shift") + 1 - row2Limit;
        int row4Limit = primaryKeyList.IndexOf("Ctrl") + 1 - row3Limit;
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public override void MakeIt104Key()
    {
        InitializeDefualt();
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("Shift");
        string newPrimaryKey = "\\";
        string newSecondaryKey = "|";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
        // Update row limits
        limitedRows[4] += 1;
    }
    public override void MakeIt107Key()
    {
        MakeIt105Key();
        int insertionIndex = primaryKeyList.IndexOf("/");
        string newPrimaryKey = "   ";
        string newSecondaryKey = "   ";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
        // Update row limits
        limitedRows[4] += 1;
    }
    public override void MakeEnterFlat()
    {
        InitializeDefualt();
    }
    public override void MakeEnterHigh()
    {
        int firstIndex = primaryKeyList.IndexOf("Enter");
        int secondIndex = primaryKeyList.IndexOf("\\");
        // Swap primary keys
        string tempKey = primaryKeyList[firstIndex];
        primaryKeyList[firstIndex] = primaryKeyList[secondIndex];
        primaryKeyList[secondIndex] = tempKey;
        // Swap secondary keys
        tempKey = secondaryKeyList[firstIndex];
        secondaryKeyList[firstIndex] = secondaryKeyList[secondIndex];
        secondaryKeyList[secondIndex] = tempKey;
    }
    public override void MakeEnterBig()
    {
        MakeEnterHigh();
        int insertionIndex = primaryKeyList.IndexOf("=");
        // Remove primary & secondary string of target key
        primaryKeyList.Remove("\\");
        secondaryKeyList.Remove("|");
        // Insert them after = key
        primaryKeyList.Insert(insertionIndex,"\\");
        secondaryKeyList.Insert(insertionIndex,"|");
        // Update row limits
        limitedRows[0] += 1;
        limitedRows[2] -= 1;
    }
}




public class WindPortable1 : WinDesktop
{
    public WindPortable1()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/","Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Prnt Scr","Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?","Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Prnt Scr","Ctrl"
        };
        InitializeRowLimits();
    }
}




public class WindPortable2 : WinDesktop
{
    public WindPortable2()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","Backspace",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "Caps Lock","a","s","d","f","g","h","j","k","l",";","'","Enter",
            "Shift","z","x","c","v","b","n","m",",",".","/","Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","Backspace",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "Caps Lock","A","S","D","F","G","H","J","K","L",":","\"","Enter",
            "Shift","Z","X","C","V","B","N","M","<",">","?","Shift",
            "Ctrl","Fn","Win","Alt","Space","AltGr","Ctrl"
        };
        InitializeRowLimits();
    }
}




public class WindPortable3 : WindPortable1
{
    public WindPortable3()
    {
        base.InitializeDefualt();
    }
}




public class WindPocket1 : WindPortable1
{
    public WindPocket1()
    {
        base.InitializeDefualt();
    }
}




public class WinErgonomic1 : WinDesktop
{
    public WinErgonomic1()
    {
        base.InitializeDefualt();
    }
}




public class WinErgonomic2 : WinDesktop
{
    public WinErgonomic2()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "Backspace","1","2","3","4","5","6","7","8","9","0","-","=",
            "Tab","q","w","e","r","t","y","u","i","o","p","[","]",
            "Caps Lock","`","a","s","d","f","g","h","j","k","l",";","'","\\",
            "Shift","z","x","c","v","b","n","m",",",".","/","Shift",
            "Ctrl","Alt","Backspace","Delete","Enter","Space","AltGr","Ctrl"
        };
        secondaryKeyList = new List<string>
        {
            "Backspace","!","@","#","$","%","^","&","*","(",")","_","+",
            "Tab","Q","W","E","R","T","Y","U","I","O","P","{","}",
            "Caps Lock","`","A","S","D","F","G","H","J","K","L",":","\"","|",
            "Shift","Z","X","C","V","B","N","M","<",">","?","Shift",
            "Ctrl","Alt","Backspace","Delete","Enter","Space","AltGr","Ctrl"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("=") + 1;
        int row1Limit = primaryKeyList.IndexOf("]") + 1 - row0Limit;
        int row2Limit = primaryKeyList.IndexOf("\\") + 1 - row1Limit;
        int row3Limit = primaryKeyList.IndexOf("Shift") + 1 - row2Limit;
        int row4Limit = primaryKeyList.IndexOf("Ctrl") + 1 - row3Limit;
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public override void MakeEnterFlat()
    {
        // Do nothing
    }
    public override void MakeEnterHigh()
    {
        // Do nothing
    }
    public override void MakeEnterBig()
    {
        // Do nothing
    }
}




public class MacDesktop : Keyboard
{
    // Constructor
    public MacDesktop()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","delete",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","return",
            "shift","z","x","c","v","b","n","m",",",".","/","shift",
            "control","option","command","space","command","option","control"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?","shift",
            "control","option","command","space","command","option","control"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("delete") + 1;
        int row1Limit = primaryKeyList.IndexOf("\\") + 1 - row0Limit;
        int row2Limit = primaryKeyList.IndexOf("return") + 1 - row1Limit;
        int row3Limit = primaryKeyList.IndexOf("shift") + 1 - row2Limit;
        int row4Limit = primaryKeyList.IndexOf("control") + 1 - row3Limit;
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
    public override void MakeIt104Key()
    {
        InitializeDefualt();
    }
    public override void MakeIt105Key()
    {
        int insertionIndex = primaryKeyList.IndexOf("shift");
        string newPrimaryKey = "\\";
        string newSecondaryKey = "|";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
    }
    public override void MakeIt107Key()
    {
        MakeIt105Key();
        int insertionIndex = primaryKeyList.IndexOf("/");
        string newPrimaryKey = "   ";
        string newSecondaryKey = "   ";
        primaryKeyList.Insert(insertionIndex,newPrimaryKey);
        secondaryKeyList.Insert(insertionIndex,newSecondaryKey);
    }
    public override void MakeEnterFlat()
    {
        InitializeDefualt();
    }
    public override void MakeEnterHigh()
    {
        int firstIndex = primaryKeyList.IndexOf("return");
        int secondIndex = primaryKeyList.IndexOf("\\");
        // Swap primary keys
        string tempKey = primaryKeyList[firstIndex];
        primaryKeyList[firstIndex] = primaryKeyList[secondIndex];
        primaryKeyList[secondIndex] = tempKey;
        // Swap secondary keys
        tempKey = secondaryKeyList[firstIndex];
        secondaryKeyList[firstIndex] = secondaryKeyList[secondIndex];
        secondaryKeyList[secondIndex] = tempKey;
    }
    public override void MakeEnterBig()
    {
        MakeEnterHigh();
        int insertionIndex = primaryKeyList.IndexOf("=");
        // Remove primary & secondary string of target key
        primaryKeyList.Remove("\\");
        secondaryKeyList.Remove("|");
        // Insert them after = key
        primaryKeyList.Insert(insertionIndex,"\\");
        secondaryKeyList.Insert(insertionIndex,"|");
    }
}




public class MacPortable : MacDesktop
{
    public MacPortable()
    {
        InitializeDefualt();
    }
    public override void InitializeDefualt()
    {
        primaryKeyList = new List<string>
        {
            "`","1","2","3","4","5","6","7","8","9","0","-","=","delete",
            "tab","q","w","e","r","t","y","u","i","o","p","[","]","\\",
            "caps lock","a","s","d","f","g","h","j","k","l",";","'","return",
            "shift","z","x","c","v","b","n","m",",",".","/","shift",
            "fn","control","option","command","space","command","option"
        };
        secondaryKeyList = new List<string>
        {
            "~","!","@","#","$","%","^","&","*","(",")","_","+","delete",
            "tab","Q","W","E","R","T","Y","U","I","O","P","{","}","|",
            "caps lock","A","S","D","F","G","H","J","K","L",":","\"","return",
            "shift","Z","X","C","V","B","N","M","<",">","?","shift",
            "fn","control","option","command","space","command","option"
        };
        InitializeRowLimits();
    }
    public override void InitializeRowLimits()
    {
        int row0Limit = primaryKeyList.IndexOf("delete") + 1;
        int row1Limit = primaryKeyList.IndexOf("\\") + 1 - row0Limit;
        int row2Limit = primaryKeyList.IndexOf("return") + 1 - row1Limit;
        int row3Limit = primaryKeyList.IndexOf("shift") + 1 - row2Limit;
        int row4Limit = primaryKeyList.IndexOf("option") + 1 - row3Limit;
        limitedRows = new List<int>{row0Limit,row1Limit,row2Limit,row3Limit,row4Limit};
    }
}
