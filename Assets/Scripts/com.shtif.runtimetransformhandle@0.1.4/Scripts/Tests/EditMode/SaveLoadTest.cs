using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
public class SaveLoadTest
{

    [Test]
    public void Save()
    {
        try
        {
            ObjectManager objManager = new ObjectManager();
            GameObject obj = new GameObject();
            obj.transform.parent = objManager.transform;

            SavingController savingController = new SavingController();
            savingController.save();
            Assert.IsTrue(true);

        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
   



}
