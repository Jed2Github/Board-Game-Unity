using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CardController : MonoBehaviour {
    public int cardIndex;
    public GameObject sliderSpawner;
    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            GameObject sliderSpawnerGameObject = PhotonNetwork.Instantiate(sliderSpawner.name, Vector3.zero, Quaternion.identity);
            view.RPC("SetParent", RpcTarget.AllBuffered, sliderSpawnerGameObject.GetComponent<PhotonView>().ViewID);
            view.RPC("SetSprite", RpcTarget.AllBuffered, cardIndex);
        }
    }

    [PunRPC]
    void SetParent(int childID) {
        Transform child = PhotonView.Find(childID).transform;
        child.parent = transform;
    }

    [PunRPC]
    void SetSprite(int index) {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Card Deck").GetComponent<CardDeckController>().possibleCards[index];
    }
}
