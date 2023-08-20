using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceController : MonoBehaviour {
    public TMP_InputField diceCount;

    public GameObject diePrefab;

    public float offset = 250f;

    public void Generate() {
        for(int i = 0; i < int.Parse(diceCount.text); i++) {
            Instantiate(diePrefab, new Vector3(695 + offset * i, 1980, 0), Quaternion.identity, transform);
            foreach(Transform child in transform) {
                if(child.gameObject.tag == "Die") {
                    Destroy(child.gameObject);
                }
            }
        }
    }
}
