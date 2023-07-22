using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private float x;
    private float y;
    private Vector3 rotateValue;
    private bool isSelected = false;
    public float movementSpeed=1.5f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isSelected = !isSelected;
        }
        if (isSelected)
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotateValue = new Vector3(x, y * -1, 0);
            transform.eulerAngles = transform.eulerAngles - rotateValue;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime, 0, 0));
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0, -movementSpeed * Time.deltaTime, 0));
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0, movementSpeed * Time.deltaTime, 0));
            }
        }
    }
}
