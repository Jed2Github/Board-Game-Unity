using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class UIItemController : MonoBehaviour {
    public GameObject itemPrefab;
    public int itemIndex;

    public void PlaceCardDown() {
        GameObject itemGameObject = PhotonNetwork.Instantiate(itemPrefab.name, Vector3.zero, Quaternion.identity);
        itemGameObject.GetComponent<ItemController>().itemIndex = itemIndex;
        itemGameObject.GetComponent<Draggable>().count = 1;
        Destroy(gameObject);
    }
}
