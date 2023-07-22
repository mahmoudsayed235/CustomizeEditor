using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectManager : MonoBehaviour
{
	public static ObjectManager Instance { get; private set; }
	private void Awake()
	{
		// If there is an instance, and it's not me, delete myself.

		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}
	public GameObject transformGizmoController;
	public GameObject HomeMenu;
	public GameObject MainMenu;
	public GameObject MaterialOpen;
	public GameObject Lamp;



	[HideInInspector]
	public GameObject selectedObject;

	


	public void FreeMovement()
    {
		transformGizmoController.SetActive(true);

	}

	public void OpenScene(string json)
	{
		DestroyAllChildern();
		Data data = JsonUtility.FromJson<Data>(json);

		foreach (ObjectData obj in data.data)
		{

			GameObject newObjectForScene = null;
			if (obj.objectType.Contains("Cube"))
			{
				newObjectForScene = GameObject.CreatePrimitive(PrimitiveType.Cube);
			}
			else if (obj.objectType.Contains("Sphere"))
			{

				newObjectForScene = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			}
			newObjectForScene.name = obj.objectType;
			newObjectForScene.AddComponent<DragController>();
			newObjectForScene.tag = "Selectable";
			newObjectForScene.transform.parent = this.transform;
			newObjectForScene.transform.position = obj.position;
			newObjectForScene.transform.rotation = obj.rotation;
			newObjectForScene.transform.localScale = obj.scale;
		}


		HomeMenu.SetActive(false);
		MainMenu.SetActive(true);
	}

	public void DestroyAllChildern()
    {
		foreach(Transform child in this.transform)
        {
			Destroy(child.gameObject);
        }
    }
	public void AddObjectToScene(string objectName)
	{
		GameObject newObjectForScene = null;
		if (objectName == "Cube")
		{
			newObjectForScene = GameObject.CreatePrimitive(PrimitiveType.Cube);
		}
		else if (objectName == "Sphere")
		{

			newObjectForScene = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		}else if(objectName == "Light")
        {
			newObjectForScene = Instantiate(Lamp);

			newObjectForScene.AddComponent<Light>();
			newObjectForScene.GetComponent<Light>().type = LightType.Spot;
			newObjectForScene.GetComponent<Light>().intensity = 5;
			newObjectForScene.GetComponent<Light>().range = 10;
			newObjectForScene.GetComponent<Light>().spotAngle = 50;
			newObjectForScene.AddComponent<BoxCollider>();
		}
		newObjectForScene.name = objectName + UnityEngine.Random.Range(0, 1000);
		newObjectForScene.AddComponent<DragController>();
		newObjectForScene.tag = "Selectable";
		newObjectForScene.transform.parent = this.transform;
		selectedObject = newObjectForScene;
		MaterialOpen.SetActive(true);
	}
	public void ChangeMaterial(Material material)
    {
		if (selectedObject != null)
		{
			if (selectedObject.name.Contains("Light"))
			{
				selectedObject.GetComponent<Light>().color = material.color;
			}
			else
			{
				transformGizmoController.GetComponent<SelectTransformGizmo>().originalMaterialHighlight = material;
				transformGizmoController.GetComponent<SelectTransformGizmo>().originalMaterialSelection = material;
				selectedObject.GetComponent<MeshRenderer>().material = material;
			}
		}

    }


}
