using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour {
    public Item item;

    Transform GFX;

    void Start() {
        GFX = transform.GetChild(0);

        GFX.GetChild(2).gameObject.GetComponent<SpriteRenderer>().sprite = item.image;
        GFX.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = item.name;
        GFX.GetChild(1).gameObject.GetComponent<TextMeshPro>().text = item.description;
    }
}
