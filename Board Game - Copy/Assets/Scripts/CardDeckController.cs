using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeckController : MonoBehaviour {
    public Sprite[] possibleCards;
    public GameObject cardPrefab;

    void OnMouseDown() {
        Debug.Log("Click");
        GenerateCard();
    }

    public void GenerateCard() {
        GameObject cardGameObject = Instantiate(cardPrefab, new Vector3(transform.position.x, transform.position.y - 2.3f, transform.position.z), Quaternion.identity);
        cardGameObject.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = possibleCards[Random.Range(0, possibleCards.Length)];
    }
}
