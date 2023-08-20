using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class TokenController : MonoBehaviour {
    PhotonView view;
    public int colour;
    public string number;
    public Color[] colours;

    void Start() {
        view = GetComponent<PhotonView>();
        if(view.IsMine) {
            view.RPC("SetColour", RpcTarget.AllBuffered, colour, number);
        }
    }

    [PunRPC]
    void SetColour(int trueColour, string trueNumber) {
        GetComponent<SpriteRenderer>().color = colours[trueColour];
        transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = trueNumber;
    }
}
