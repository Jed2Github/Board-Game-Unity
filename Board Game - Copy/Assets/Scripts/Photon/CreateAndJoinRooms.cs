using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks {
    public TMP_InputField createInput;
    public TMP_InputField joinInput;
    public TMP_InputField userNameInput;

    public GameObject loadingScreen;
    public Sprite[] backGrounds;
    public string[] tips;

    bool isJoining;

    public void CreateRoom() {
        PhotonNetwork.CreateRoom(createInput.text);
        PhotonNetwork.NickName = userNameInput.text;
    }

    public void JoinRoom() {
        PhotonNetwork.JoinRoom(joinInput.text);
        PhotonNetwork.NickName = userNameInput.text;
    }
    
    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Game");
    }
}
