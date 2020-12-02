using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaver : MonoBehaviour
{
    public ParticleSystem particle;
    private Vector3 offset;
    private float zCoord;
    Camera cam;
    Transform top;

    private void Awake()
    {
        cam = Camera.main;
        top = GetComponentInChildren<Transform>();
    }

    private void OnMouseDown()
    {
        zCoord = cam.WorldToScreenPoint(transform.position).z;
        offset = transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        Vector3 total = GetMouseWorldPos() + offset;
        transform.position = new Vector3(transform.position.x, total.y, total.z);
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = zCoord;
        return cam.ScreenToWorldPoint(mousePosition);
    }

    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(top.position, -transform.forward, out hit, 100))
        {
            particle.Emit(5);
            //Destroy(hit.transform.gameObject);
            Rigidbody hitObject = hit.transform.gameObject.GetComponent<Rigidbody>();
            hitObject.isKinematic = false;
            int random = UnityEngine.Random.Range(8, 15);
            hitObject.AddForce(new Vector3(random, random, 0), ForceMode.Impulse);
            //Handheld.Vibrate();

        }

        Debug.DrawRay(top.position, -transform.forward, Color.green, .01f, false);
        

    }


}
