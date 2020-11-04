using System;
using System.Collections;
using System.Collections.Generic;


public abstract class KeyboardChanger
{
    public abstract void MakeIt104Key(Key LeftHiddenKey , Key RightHiddenKey);
    public abstract void MakeIt105Key(Key LeftHiddenKey , Key RightHiddenKey);
    public abstract void MakeIt107Key(Key LeftHiddenKey , Key RightHiddenKey);
    public abstract void MakeEnterFlat(Key UpperHiddenKey , Key LowerHiddenKey);
    public abstract void MakeEnterHigh(Key UpperHiddenKey , Key LowerHiddenKey);
    public abstract void MakeEnterBig(Key UpperHiddenKey , Key LowerHiddenKey);
}
public class WindowsDesktopChanger : KeyboardChanger
{
    public override void MakeIt104Key(Key LeftHiddenKey , Key RightHiddenKey)
    {
        LeftHiddenKey.gameObject.SetActive(false);
        RightHiddenKey.gameObject.SetActive(false);

        /// and default width options from KeyboardLayout
    }
    ///////////////////////////////////////////// width operations should apply
    public override void MakeIt105Key(Key LeftHiddenKey , Key RightHiddenKey)
    {
        LeftHiddenKey.gameObject.SetActive(true);
        RightHiddenKey.gameObject.SetActive(false);
    }
    public override void MakeIt107Key(Key LeftHiddenKey , Key RightHiddenKey)
    {
        LeftHiddenKey.gameObject.SetActive(true);
        RightHiddenKey.gameObject.SetActive(true);
    }
    public override void MakeEnterFlat(Key UpperHiddenKey , Key LowerHiddenKey)
    {
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(false);
    }
    public override void MakeEnterHigh(Key UpperHiddenKey , Key LowerHiddenKey)
    {
        UpperHiddenKey.gameObject.SetActive(false);
        LowerHiddenKey.gameObject.SetActive(true);
    }
    public override void MakeEnterBig(Key UpperHiddenKey , Key LowerHiddenKey)
    {
        UpperHiddenKey.gameObject.SetActive(true);
        LowerHiddenKey.gameObject.SetActive(false);
    }
}