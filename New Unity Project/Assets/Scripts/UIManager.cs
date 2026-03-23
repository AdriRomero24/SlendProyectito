using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{   
    public static UIManager Ui;
    public GameObject pausa;

    public bool pause = false;




    public void Start()
    {
        pausa.SetActive(false);
    }


    public void Awake()
    {
       Ui = this;
    }


    public void ShowPauseScreen()
    {

      
     pausa.SetActive(true);

     pause = true;


    }

    public void UnshowPauseScreen()
    {
        
        pausa.SetActive(false);

        pause = false;
    }
}
