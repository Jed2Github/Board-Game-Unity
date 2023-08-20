using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CardController : MonoBehaviour {
    public GameObject sliderSpawner;

    void Start() {
        GameObject sliderSpawnerGameObject = PhotonNetwork.Instantiate(sliderSpawner.name, Vector3.zero, Quaternion.identity);
        sliderSpawnerGameObject.transform.parent = transform;
    }
}
