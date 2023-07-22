using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
public class SceneTests
{

    [Test]
    public void SceneCreation()
    {
        try
        {
            UIController ui = new UIController();
            ui.MainMenu = new GameObject();
            ui.HomeMenu = new GameObject();
            ui.createScene();
            Assert.IsTrue(ui.HomeMenu.activeSelf == false && ui.MainMenu.activeSelf == true);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [Test]
    public void SceneCreationMissingParametar()
    {
        try
        {
            UIController ui = new UIController();
            ui.MainMenu = new GameObject();
            ui.createScene();
            Assert.IsTrue(true);
        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
   


}
