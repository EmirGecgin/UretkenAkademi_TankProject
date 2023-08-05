using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSensivity;
    [SerializeField] private GameObject player;
    private float rotationX;
    private void Awake()
    {
        transform.localRotation=Quaternion.Euler(0,0,0);
    }
    void Update()
    {
        CameraControl();
    }
    void CameraControl()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90, 90);

        transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
