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
    GameObject player;
    GameObject thisPlayer;
    GameObject[] players;

    void Start() {
        view = GetComponent<PhotonView>();
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++) {
            if(players[i].GetComponent<PhotonView>().IsMine)
                thisPlayer = players[i];
        }
        if(!view.IsMine) {
            dragging = false;
        } else {
            Debug.Log(thisPlayer);
            view.RPC("SyncPlayers", RpcTarget.OthersBuffered, thisPlayer.GetComponent<PhotonView>().ViewID);
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
            view.RPC("SyncPlayers", RpcTarget.OthersBuffered, thisPlayer.GetComponent<PhotonView>().ViewID);
        }
    }
    
    void OnMouseUp() {
        view.RPC("UnSyncPlayers", RpcTarget.OthersBuffered);
    }

    void Update() {
        if(dragging && startDrag) {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
            if(gameObject.tag == "Token") {
                transform.position = new Vector3(transform.position.x, transform.position.y, -1);
                Debug.Log("is token");
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            count++;
            if(count < 2)
                return;
            dragging = false;
            view.RPC("UnSyncPlayers", RpcTarget.OthersBuffered);
        }

        if(player != null) {
            transform.position = player.transform.position;
        }
    }

    [PunRPC] 
    void SyncPlayers(int playerID) {
        player = PhotonView.Find(playerID).gameObject;
    }

    [PunRPC]
    void UnSyncPlayers() {
        player = null;
    }
}
