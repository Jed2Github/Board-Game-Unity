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
        }
    }

    [PunRPC]
    void SetParent(int childID) {
        Transform child = PhotonView.Find(childID).transform;
        child.parent = transform;
    }
}
