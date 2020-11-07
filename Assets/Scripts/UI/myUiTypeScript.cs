using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myUiTypeScript : MonoBehaviour
{ /* Desctiptoins: DONT DISABLE ANY UI BEFORE GAME STARTS, ENABLE ALL THE UIS IN THE SCENE AND PUT THEM ALL IN THE UIs ARRAY IN GAME MANAGER SCRIPT THEN SET THE
'ActiveUIWhenStart' VARIABLE OF THE START UI ON TRUE AND SET ALL THE OTHERS ON FALSE.*/
   public  UiTypeScript MyUiTypeScriptableObject;
   public GameObject previousUI;
   public bool ActiveUIWhenStart=false;
   public UiManagerScript.StandardUI myStandardUI;
   private void Awake()//consider Start if doesnt work
   {
       myStandardUI=MyUiTypeScriptableObject.myUiType;
       transform.gameObject.SetActive(ActiveUIWhenStart);
       
   }
   
}
