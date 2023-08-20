using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CardController : MonoBehaviour {
    public GameObject sliderSpawner;
    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            GameObject sliderSpawnerGameObject = PhotonNetwork.Instantiate(sliderSpawner.name, Vector3.zero, Quaternion.identity);
            view.RPC("SetParent", RpcTarget.AllBuffered, sliderSpawnerGameObject.GetComponent<PhotonView>().ViewID);
            view.RPC("SetSprite", RpcTarget.OthersBuffered, transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }

    [PunRPC]
    void SetParent(int childID) {
        Transform child = PhotonView.Find(childID).transform;
        child.parent = transform;
    }

    [PunRPC]
    void SetSprite(Sprite sprite) {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
