using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ItemController : MonoBehaviour {
    public int itemIndex;
    PhotonView view;

    Transform GFX;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            view.RPC("SetSprite", RpcTarget.AllBuffered, itemIndex);
        }
    }

    [PunRPC]
    void SetSprite(int index) {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = GameObject.FindWithTag("Item Deck").GetComponent<ItemDeckController>().possibleItems[index];
    }
}
