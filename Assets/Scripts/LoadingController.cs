using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
public class LoadingController : MonoBehaviour
{
    public GameObject sceneBtn,container,scrollView;
    public void Load()
    {
      
            foreach (Transform child in container.transform)
            {
                Destroy(child.gameObject);
            }
        var info = new DirectoryInfo(Application.persistentDataPath);
        var fileInfo = info.GetFiles();
        foreach (FileInfo file in fileInfo)
        {
            GameObject scene = Instantiate(sceneBtn, container.transform);
            scene.transform.GetChild(0).GetComponent<TMP_Text>().text = Path.GetFileNameWithoutExtension(file.Name);
            scene.GetComponent<Button>().onClick.AddListener(() => openScene(file.Name));

        }
        scrollView.SetActive(true);
    }
    void openScene(string sceneName)
    {
        string fileContents = File.ReadAllText(Application.persistentDataPath+"/"+ sceneName);
        
        ObjectManager.Instance.OpenScene(fileContents);
        scrollView.SetActive(false);
    }
    
}
