using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ThirdPersonCamera : MonoBehaviour
{

    [SerializeField] private GameObject PlayerBody;

    private float mouseX = 0;
    private float mouseY = 0;

    [SerializeField] private float distance = 10;

    [SerializeField] private float xSensetivity = 500.0f;
    [SerializeField] private float ySensetivity = 300.0f;
    private float xRotation;
    void Start()
    {
        PlayerBody = transform.parent.gameObject;
    }

    
    void Update()
    {

        mouseX += Input.GetAxis("Mouse X") * xSensetivity * Time.deltaTime;
        mouseY -= Input.GetAxis("Mouse Y") * ySensetivity * Time.deltaTime;

        mouseY = Mathf.Clamp(mouseY, -4, 50);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
        transform.position = PlayerBody.transform.position + rotation * Direction;

        transform.LookAt(PlayerBody.transform.position);

        Quaternion CamRotation = transform.rotation;
        CamRotation.x = 0;
        CamRotation.z = 0;

        PlayerBody.transform.rotation = Quaternion.Lerp(PlayerBody.transform.rotation, CamRotation, 10f * Time.deltaTime);
    }
}
