using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Un_RedoController : MonoBehaviour
	{

		public static Un_RedoController Instance { get; private set; }

	public GameObject emptyGO;
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

		emptyGO = new GameObject();
		emptyGO.name = "emptyObj";
	}
	void Start()
	{
		Resetting();
	}
	public List<setting> UndoList;
		public List<setting> RedoList;
		public GameObject UndoBtn;
		public GameObject RedoBtn;
		public void AddNewActionUndo(GameObject g,Transform previousPosition)
		{
			setting s = new setting(g, previousPosition);

			UndoList.Add(s);
			RedoList.Clear();
			RedoBtn.SetActive(false);
			UndoBtn.SetActive(true);
		}
		public void Redo()
		{
		try
		{
			GameObject selected = GameObject.Find(RedoList[RedoList.Count - 1].Obj.name);
				setting s = new setting(selected, selected.transform);
				
				UndoList.Add(s);
				RedoList[RedoList.Count - 1].Restore();
				UndoBtn.SetActive(true);
				RedoList.RemoveAt(RedoList.Count - 1);
				if (RedoList.Count == 0)
				{
					RedoBtn.SetActive(false);
				}
		}
		catch
		{

			throw new ArgumentException("No Action To Undo");
		}
	}
		public void Undo()
		{
		try
		{

			
				GameObject selected = GameObject.Find(UndoList[UndoList.Count - 1].Obj.name);
				setting s = new setting(selected, selected.transform);

				RedoList.Add(s);
				UndoList[UndoList.Count - 1].Restore();
				RedoBtn.SetActive(true);
				UndoList.RemoveAt(UndoList.Count - 1);




				if (UndoList.Count == 0)
				{
					UndoBtn.SetActive(false);

				}

			
        }
        catch
        {

			throw new ArgumentException("No Action To Undo");
		}
		}

		
		public void Resetting()
    {
		UndoList = new List<setting>();
		RedoList = new List<setting>();
		UndoBtn.SetActive(false);
		RedoBtn.SetActive(false);

	}
		public class setting
		{
			public GameObject Obj;
			public Vector3 Pos;
			public Quaternion Rot;
			public Vector3 Scale;
			public bool Deleted;

			public void Restore()
			{
				Obj.transform.position = Pos;
				Obj.transform.rotation = Rot;
				Obj.transform.localScale = Scale;
				Obj.SetActive(Deleted);
			}
			public setting(GameObject g, Transform previousTransform)
			{
				Obj = g;
			Pos = previousTransform.position;
			//Pos = g.transform.position;
			Rot = previousTransform.rotation;
				Scale = previousTransform.localScale;
				Deleted = g.activeSelf;

			}
		}
	}
