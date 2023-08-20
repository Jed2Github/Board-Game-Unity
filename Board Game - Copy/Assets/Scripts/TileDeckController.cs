using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TileDeckController : MonoBehaviour {
    public Sprite[] possibleTiles;
    public Sprite boss;
    public Sprite item;
    public Sprite coin;
    public Sprite skull;
    public GameObject tilePrefab;

    void OnMouseDown() {
        Debug.Log("Click");
        GenerateTile();
    }

    public void GenerateTile() {
        Sprite tile = possibleTiles[Random.Range(0, possibleTiles.Length)];
        GameObject tileGameobject = PhotonNetwork.Instantiate(tilePrefab.name, new Vector3(transform.position.x, transform.position.y - 2.3f, transform.position.z), Quaternion.identity);
        tileGameobject.GetComponent<TileController>().tile = tile;
        SpriteRenderer special = tileGameobject.transform.GetChild(4).gameObject.GetComponent<SpriteRenderer>();
        if(Random.Range(0, 5) == 0) {
            if(Random.Range(0, 10) == 0) {
                special.sprite = boss;
            } else if(Random.Range(0, 4) == 0) {
                special.sprite = skull;
            } else if(Random.Range(0, 2) == 0) {
                special.sprite = coin;
            } else {
                special.sprite = item;
            }
        }
    }
}
