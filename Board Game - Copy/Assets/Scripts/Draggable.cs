using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Draggable : MonoBehaviour {
    public bool startDrag = false;
    Vector2 difference = Vector2.zero;
    Vector3 targetPosition;
    public float smoothing = 0.1f;
    bool dragging = true;
    public int count = 0;
    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        if(!view.IsMine) {
            dragging = false;
        }
    }

    void OnMouseDown() {
        difference = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    void OnMouseDrag() {
        if (!dragging) {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
            if(gameObject.tag == "Token") {
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Debug.Log("is token");
            }
            view.RPC("SyncPositions", RpcTarget.OthersBuffered, transform.position);
        }
    }

    void Update() {
        if(dragging && startDrag) {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
            if(gameObject.tag == "Token") {
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Debug.Log("is token");
            }
            view.RPC("SyncPositions", RpcTarget.AllBuffered, transform.position);
        }

        if(Input.GetMouseButtonDown(0)) {
            count++;
            if(count < 2)
                return;
            dragging = false;
        }
    }

    [PunRPC] 
    void SyncPositions(Vector3 position) {
        transform.position = position;
    }
}
