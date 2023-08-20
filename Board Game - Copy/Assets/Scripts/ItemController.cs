using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ItemController : MonoBehaviour {
    public Item item;
    PhotonView view;

    Transform GFX;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            view.RPC("SetSprite", RpcTarget.OthersBuffered, transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite);
        }
    }

    [PunRPC]
    void SetSprite(Sprite sprite) {
        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
