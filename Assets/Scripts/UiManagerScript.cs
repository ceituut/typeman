using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManagerScript : singleton<UiManagerScript>
{
  /* Desctiptoins: DONT DISABLE ANY UI BEFORE GAME STARTS, ENABLE ALL THE UIS IN THE SCENE AND PUT THEM ALL IN THE UIs ARRAY IN GAME MANAGER SCRIPT THEN SET THE
'ActiveUIWhenStart' VARIABLE OF THE STARTING UI ON TRUE AND SET ALL THE OTHERS ON FALSE.*/
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
          Debug.Log(NumberOfActiveUIs==0 ? "please set an active UI!" :  NumberOfActiveUIs>1 ?"more than one UI is Active! NOT CORRECT!":"number of Active UIs are correct!");

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
     
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.mainMenu)
        {          

           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenBattleMenu()
    {
       
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleMenu)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenOptionsMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.options)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
     public void OpenStylesMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.styleMenu)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenCreditsMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.credits)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenExitMenu()
    {
     
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.exit)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenDuelMatchMenu()
    {
       
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.duelMatch)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenDeathMatchMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.deathMatch)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenTeamDeathMatchMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.teamDeathMatch)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenBattleGroundMenu()
    {
     
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleGround)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenQuickMenu()
    {
     
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.quickMenu)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }
    }
      public void OpenAreYouSureMenuMenu()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.areYouSureMenu)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenChooseTeamMenu()
    {
       
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.chooseTeamMenu)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
      public void OpenbattleGroundScene()
    {
      
      foreach(GameObject g in UIs)
      {
        if(g.GetComponent<myUiTypeScript>().myStandardUI==StandardUI.battleGroundScene)
        {
           FindActiveUI();
           g.GetComponent<myUiTypeScript>().previousUI=currentActiveUI;
          currentActiveUI.SetActive(false);
          g.SetActive(true);
          break;
        }
      }

    }
    public void ExitYesButtonAction()
    {
      
           FindActiveUI();
           if(currentActiveUI.GetComponent<myUiTypeScript>().previousUI.GetComponent<myUiTypeScript>().previousUI!=null)
           {
           currentActiveUI.GetComponent<myUiTypeScript>().previousUI.GetComponent<myUiTypeScript>().previousUI.SetActive(true);
         //  GameObject _previousUI=currentActiveUI;
           currentActiveUI.SetActive(false);
         //  FindActiveUI();
          // currentActiveUI.GetComponent<myUiTypeScript>().previousUI=_previousUI;
           }
           else
           Application.Quit();

        
      

    }
    public void ExitNoButtonAction()
    {
           FindActiveUI();
           currentActiveUI.GetComponent<myUiTypeScript>().previousUI.SetActive(true);
          // GameObject _previousUI=currentActiveUI;
           currentActiveUI.SetActive(false);
          // FindActiveUI();
           //currentActiveUI.GetComponent<myUiTypeScript>().previousUI=_previousUI;

    }
    public void OnBackButtonAction()
    {
           FindActiveUI();
           currentActiveUI.GetComponent<myUiTypeScript>().previousUI.SetActive(true);
         //  GameObject _previousUI=currentActiveUI;
           currentActiveUI.SetActive(false);
         //  FindActiveUI();
          // currentActiveUI.GetComponent<myUiTypeScript>().previousUI=_previousUI;
    }

    
}
