using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using System;
public class UnReDoTest
{

    [Test]
    public void Undo()
    {
        try
        {
            GameObject obj = new GameObject();
            GameObject temp = new GameObject();

            Transform transform = temp.transform;
            transform.SetPositionAndRotation(new Vector3(3, 3, 3), obj.transform.rotation);
            transform.localScale = obj.transform.localScale;
            Un_RedoController instance = new Un_RedoController();
            instance.Resetting();
            instance.AddNewActionUndo(obj, transform);
            instance.Undo();

            Assert.IsTrue(!obj.transform.position.Equals(transform));

        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }
    [Test]
    public void Redo()
    {
        try
        {
            GameObject obj = new GameObject();
            GameObject temp = new GameObject();

            Transform transform = temp.transform;
            transform.SetPositionAndRotation(new Vector3(3, 3, 3), obj.transform.rotation);
            transform.localScale = obj.transform.localScale;
            Un_RedoController instance = new Un_RedoController();
            instance.Resetting();
            instance.AddNewActionUndo(obj, transform);
            instance.Undo();
            instance.Redo();

            Assert.IsTrue(obj.transform.position.Equals(transform));

        }
        catch (Exception e)
        {
            Assert.Fail(e.Message);
        }
    }




}
