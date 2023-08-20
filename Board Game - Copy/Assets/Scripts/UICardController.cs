using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UICardController : MonoBehaviour {
    public GameObject itemPrefab;

    public void PlaceCardDown() {
        GameObject itemGameObject = PhotonNetwork.Instantiate(itemPrefab.name, Vector3.zero, Quaternion.identity);
        itemGameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = GetComponent<Image>().sprite;
        itemGameObject.GetComponent<Draggable>().count = 1;
        Destroy(gameObject);
    }
}
