using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIController : MonoBehaviour
{
    public GameObject HomeMenu;
    public GameObject MainMenu;



    public void createScene()
    {
        try
        {
            HomeMenu.SetActive(false);
            MainMenu.SetActive(true);
        }
        catch (Exception e)
        {
            throw new ArgumentException("NullReferenceException");
        }
    }
}
