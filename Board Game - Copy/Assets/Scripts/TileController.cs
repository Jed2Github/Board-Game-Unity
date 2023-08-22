using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TileController : MonoBehaviour
{
    public int tileIndex;

    public float distance;

    [SerializeField]
    LayerMask mask;

    Transform topRight;
    Transform bottomRight;
    Transform bottomLeft;
    Transform topLeft;

    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            view.RPC("SetSprite", RpcTarget.AllBuffered, tileIndex);
        }

        topRight = transform.GetChild(0);
        bottomRight = transform.GetChild(1);
        bottomLeft = transform.GetChild(2);
        topLeft = transform.GetChild(3);
    }

    void Update() {
        
    }

    void OnMouseOver() {
        if (Input.GetMouseButton(0)) {
            foreach (Transform positioner in transform) {
                Collider2D[] others = Physics2D.OverlapCircleAll(positioner.position, distance, mask);
                Transform other = null;
                for(int i = 0; i < others.Length; i++) {
                    if(others[i].transform != transform) {
                        other = others[i].transform;
                    }
                }
                if(other != null) {
                    GetComponent<Draggable>().view.RPC("UnSyncPlayers", RpcTarget.AllBuffered);
                    if (other != positioner && other.gameObject.name != positioner.gameObject.name) {
                        Debug.Log(other);
                        Debug.Log(other.parent);
                        Vector3 offset = other.position - positioner.position;
                        Debug.Log("yes");
                        transform.position += offset;
                        view.RPC("SyncPositions", RpcTarget.AllBuffered, transform.position);
                        break;
                    } else {
                        GetComponent<Draggable>().view.RPC("SyncPlayers", RpcTarget.AllBuffered, GetComponent<Draggable>().thisPlayer.GetComponent<PhotonView>().ViewID);
                    }
                }
            }
        }
    }

    void OnDrawGizmos() {
        foreach(Transform child in transform) {
            Gizmos.DrawSphere(child.position, distance);
        }
    }

    [PunRPC]
    void SetSprite(int index) {
        GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Tile Deck").GetComponent<TileDeckController>().possibleTiles[index];
    }

    [PunRPC] 
    void SyncPositions(Vector3 position) {
        transform.position = position;
    }
}
