using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerController : MonoBehaviour {
    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = view.Owner.NickName;
        if(view.IsMine) {
            gameObject.tag = "Player";
        }
    }

    void Update() {
        if (view.IsMine) {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            mousePosition.z = 0f;
            transform.position = mousePosition;
        }
    }
}
