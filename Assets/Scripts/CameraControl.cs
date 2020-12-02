using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    bool mouseClickjudge;
    public Transform target;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        //CameraController();
    }

    public void CameraController()
    {
        if (Input.GetMouseButtonDown(0)) {
            mouseClickjudge = true;
        }

        if (Input.GetMouseButtonUp(0)) {
            mouseClickjudge = false;
        }
        if (mouseClickjudge) {
            cam.transform.RotateAround(target.position, Vector3.up, Input.GetAxis("Mouse X") * 3);
        }
    }
}
