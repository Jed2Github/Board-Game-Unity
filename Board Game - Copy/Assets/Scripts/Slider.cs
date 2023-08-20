using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Slider : MonoBehaviour {
    public Vector4 positions;

    float startX;
    float startY;

    bool isBeingDragged;

    public bool isPointerOver;
    public float multiplier = 0.1f;

    PhotonView view;

    Vector3 targetPosition;
    public float smoothing = 0.1f;

    void Start() {
        view = GetComponent<PhotonView>();
        if(transform.localPosition.x > positions.y) 
            transform.localPosition = new Vector3(positions.y, transform.localPosition.y, 0);
        if(transform.localPosition.x < positions.x)
            transform.localPosition = new Vector3(positions.x, transform.localPosition.y, 0);
        if(transform.localPosition.y < positions.z)
            transform.localPosition = new Vector3(transform.localPosition.x, positions.z, 0);
        if(transform.localPosition.y > positions.w)
            transform.localPosition = new Vector3(transform.localPosition.x, positions.w, 0);
        if(transform.localPosition.x > positions.y) 
            Debug.Log("No");
        if(transform.localPosition.x < positions.x)
            Debug.Log("No");
        if(transform.localPosition.y < positions.z)
            Debug.Log("No");
        if(transform.localPosition.y > positions.w)
            Debug.Log("No");
    }

    void OnMouseOver() {
        if(Input.GetMouseButton(0)) {
            isBeingDragged = true;
        }
    }
    
    void OnMouseUp() {
        view.RPC("SyncPosition", RpcTarget.AllBuffered, transform.position);
    }

    void Update() {
        if(isBeingDragged) {
            transform.localPosition = new Vector3(transform.localPosition.x + Input.GetAxisRaw("Mouse X") * multiplier, transform.localPosition.y + Input.GetAxisRaw("Mouse Y") * multiplier, 0);
            if(transform.localPosition.x > positions.y) 
                transform.localPosition = new Vector3(positions.y, transform.localPosition.y, 0);
            if(transform.localPosition.x < positions.x)
                transform.localPosition = new Vector3(positions.x, transform.localPosition.y, 0);
            if(transform.localPosition.y < positions.z)
                transform.localPosition = new Vector3(transform.localPosition.x, positions.z, 0);
            if(transform.localPosition.y > positions.w)
                transform.localPosition = new Vector3(transform.localPosition.x, positions.w, 0);
        }

        if(Input.GetMouseButtonUp(0) && isBeingDragged) {
            isBeingDragged = false;
        }
    }

    [PunRPC]
    void SyncPosition(Vector3 position) {
        transform.position = position;
    }

    void OnMouseEnter() {
        isPointerOver = true;
    }

    void OnMouseExit() {
        isPointerOver = false;
    }
}
