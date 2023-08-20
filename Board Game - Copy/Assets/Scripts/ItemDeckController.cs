using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ItemDeckController : MonoBehaviour {
    public GameObject itemPrefab;
    public Transform hand;
    public Sprite[] possibleItems;

    void OnMouseDown() {
        Debug.Log("Click");
        GenerateItem();
    }

    public void GenerateItem() {
        GameObject itemGameObject = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, hand);
        itemGameObject.GetComponent<Image>().sprite = possibleItems[Random.Range(0, possibleItems.Length)];
    }
}
