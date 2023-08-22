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
        int randInt = Random.Range(0, possibleItems.Length);
        GameObject itemGameObject = Instantiate(itemPrefab, Vector3.zero, Quaternion.identity, hand);
        itemGameObject.GetComponent<Image>().sprite = possibleItems[randInt];
        itemGameObject.GetComponent<UIItemController>().itemIndex = randInt;
    }
}
