using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TileController : MonoBehaviour
{
    public Sprite tile;

    public float distance;

    [SerializeField]
    LayerMask mask;

    Transform topRight;
    Transform bottomRight;
    Transform bottomLeft;
    Transform topLeft;

    PhotonView view;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = tile;
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            view.RPC("SetSprite", RpcTarget.OthersBuffered, GetComponent<SpriteRenderer>().sprite);
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
                    Debug.Log("yes2");
                    Debug.Log(other == positioner);
                    if (other != positioner && other.gameObject.name != positioner.gameObject.name) {
                        Debug.Log(other);
                        Debug.Log(other.parent);
                        Vector3 offset = other.position - positioner.position;
                        Debug.Log("yes");
                        transform.position += offset;
                        break;
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
    void SetSprite(Sprite sprite) {
        GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
