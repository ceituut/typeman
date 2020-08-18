using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UiManagerScript : MonoBehaviour
{
  /* Desctiptoins: DONT DISABLE ANY UI BEFORE GAME STARTS, ENABLE ALL THE UIS IN THE SCENE AND PUT THEM ALL IN THE UIs ARRAY IN GAME MANAGER SCRIPT THEN SET THE
'ActiveUIWhenStart' VARIABLE OF THE START UI ON TRUE AND SET ALL THE OTHERS ON FALSE.*/
  public GameObject[] UIs;//initiate in unity editor
  private GameObject currentActiveUI;
  private void Start()
  {
    InitialActiveUiCheck();
    FindActiveUI();
  }
  private void InitialActiveUiCheck()
  {
    int NumberOfActiveUIs=0;
    for(int i=0;i<UIs.Length;i++)
    {
      if(UIs[i].activeSelf)
      {
        NumberOfActiveUIs++;

      }
    }
          Debug.Log(NumberOfActiveUIs==0 ? "please set an active UI!" :  NumberOfActiveUIs>1 ?"more than one UI is Active!":"number of Active UIs are correct!");

  }
  private void FindActiveUI()
  {

       foreach(GameObject g in UIs)
   {
     if(g.activeSelf)
     {
        currentActiveUI=g;
        break;
     }
   
  }
  }
    public enum StandardUI
    {
        splashScreen,
        mainMenu,
        battleMenu,
        options,
        styleMenu,
        credits,
        exit,
        duelMatch,
        deathMatch,
        teamDeathMatch,
        battleGround,
        quickMenu,
        areYouSureMenu,
        chooseTeamMenu,
        battleGroundScene,
    }
    public void OpenSplashScreenMenu()
    {
      FindActiveUI();
      currentActiveUI.SetActive(false);
    }
     public void OpenMainMenu()
    {
      FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.mainMenu)
        {
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenBattleMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleMenu)
        {
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenOptionsMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.options)
        {
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenStylesMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.styleMenu)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenCreditsMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.credits)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenExitMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.exit)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenDuelMatchMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.duelMatch)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenDeathMatchMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.deathMatch)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenTeamDeathMatchMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.teamDeathMatch)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenBattleGroundMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleGround)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenQuickMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.quickMenu)
        {
          g.SetActive(true);
          break;
        }
      }
    }
      public void OpenAreYouSureMenuMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.areYouSureMenu)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenChooseTeamMenu()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.chooseTeamMenu)
        {
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenbattleGroundScene()
    {
       FindActiveUI();
      currentActiveUI.SetActive(false);
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleGroundScene)
        {
          g.SetActive(true);
          break;
        }
      }

    }

    
}
