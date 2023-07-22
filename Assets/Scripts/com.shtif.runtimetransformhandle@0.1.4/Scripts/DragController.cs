using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragController : MonoBehaviour
{
	private Vector3 screenPoint;
	private Vector3 offset;
	public Transform previousTransform; 

	private void Start()
	{
		
		previousTransform = Un_RedoController.Instance.emptyGO.transform;
		previousTransform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
		previousTransform.localScale = this.transform.localScale;

	}
    void OnMouseDown()
	{

		if ( !EventSystem.current.IsPointerOverGameObject())
		{
			previousTransform.SetPositionAndRotation(this.transform.position, this.transform.rotation);
			previousTransform.localScale = this.transform.localScale;
			
			ObjectManager.Instance.selectedObject = gameObject;
			ObjectManager.Instance.FreeMovement();

			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}

	}

	void OnMouseDrag()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
    private void OnMouseUp()
    {
        if (!previousTransform.position.Equals(this.transform.position) || !previousTransform.rotation.eulerAngles.Equals(this.transform.rotation.eulerAngles) || !previousTransform.localScale.Equals(this.transform.localScale) )
        {

			Un_RedoController.Instance.AddNewActionUndo(this.gameObject, previousTransform);
		}

	}
}
