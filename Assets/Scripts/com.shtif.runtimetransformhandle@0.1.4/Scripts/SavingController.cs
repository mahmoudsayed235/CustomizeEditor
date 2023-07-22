using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class SavingController : MonoBehaviour
{
   public void save()
    {
        Data data = new Data();
        Transform objectManager = ObjectManager.Instance.transform;
        if (objectManager.childCount != 0)
        {
            foreach (Transform child in objectManager)
            {

                ObjectData obj = new ObjectData();
                obj.objectType = child.name;
                obj.position = child.position;
                obj.rotation = child.rotation;
                obj.scale = child.localScale;
                data.data.Add(obj);
            }

            writeFile(JsonUtility.ToJson(data));
        }
        else
        {
            Debug.Log("Your scene is empty");
        }
    }
    void writeFile(string json)
    {
        try
        {
            string path = Application.persistentDataPath + "/Scene_" + System.DateTime.Now.ToString("dd_HH_mm_ss").ToString() + ".json";

            // Write JSON to file.
            File.WriteAllText(path, json);
        }
        catch
        {

            throw new ArgumentException("issue with file path");
        }
    }
}
[System.Serializable]
public class Data
{
    public List<ObjectData> data;
    public Data()
    {
        data = new List<ObjectData>();
    }
}
[System.Serializable]
public class ObjectData
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public string objectType;
}

