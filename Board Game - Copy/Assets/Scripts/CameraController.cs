using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public float sensitivity;
    public float bounds = 5;

    public float maxZoom = 2f;
    public float minZoom = 14f;

    public float zoom = 10f;

    void Update() {
        if(Input.GetMouseButton(2)) {
            transform.position = new Vector3(transform.position.x + Input.GetAxis("Mouse X") * sensitivity, transform.position.y + Input.GetAxis("Mouse Y") * sensitivity, -10);
            if(transform.position.x > bounds)
                transform.position = new Vector3(bounds, transform.position.y, transform.position.z);
            if(transform.position.x < -bounds)
                transform.position = new Vector3(-bounds, transform.position.y, transform.position.z);
            if(transform.position.y > bounds)
                transform.position = new Vector3(transform.position.x, bounds, transform.position.z);
            if(transform.position.y < -bounds)
                transform.position = new Vector3(transform.position.x, -bounds, transform.position.z);
        }

        zoom += Input.GetAxisRaw("Mouse ScrollWheel") * -1f;
        if(zoom > maxZoom)
            zoom = maxZoom;
        if(zoom < minZoom)
            zoom = minZoom;
        Camera cam = GetComponent<Camera>();
        cam.orthographicSize = zoom;
    }
}
