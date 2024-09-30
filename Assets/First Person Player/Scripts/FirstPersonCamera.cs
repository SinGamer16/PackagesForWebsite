using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{

    [SerializeField] private GameObject PlayerBody;

    [SerializeField] private float xSensetivity = 200.0f;
    [SerializeField] private float ySensetivity = 200.0f;
    private float xRotation;
    void Start()
    {


        PlayerBody = transform.parent.gameObject;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {


        float mouseX = Input.GetAxis("Mouse X") * xSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * ySensetivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.transform.Rotate(Vector3.up * mouseX);
    }
}
