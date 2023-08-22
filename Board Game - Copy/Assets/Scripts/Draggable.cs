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
    public PhotonView view;
    GameObject player = null;
    public GameObject thisPlayer;
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
            if(startDrag) {
                Debug.Log(thisPlayer);
                view.RPC("SyncPlayers", RpcTarget.AllBuffered, thisPlayer.GetComponent<PhotonView>().ViewID);
            }
        }
    }

    void OnMouseDown() {
        difference = (Vector2)(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
    }

    void OnMouseDrag() {
        if (!dragging) {
            view.RPC("SyncPlayers", RpcTarget.AllBuffered, thisPlayer.GetComponent<PhotonView>().ViewID);
        }
    }
    
    void OnMouseUp() {
        view.RPC("UnSyncPlayers", RpcTarget.AllBuffered);
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            count++;
            if(count < 2)
                return;
            dragging = false;
            view.RPC("UnSyncPlayers", RpcTarget.AllBuffered);
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
