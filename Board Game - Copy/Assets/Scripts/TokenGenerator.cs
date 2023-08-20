using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class TokenGenerator : MonoBehaviour {
    public Color[] colors;
    
    public GameObject tokenPrefab;

    public int tokenCount = 3;
    public float offset = 5f;

    void Start() {
        if(PhotonNetwork.IsMasterClient) {
            for(int i = 0; i < colors.Length; i++) {
                for(int ii = 0; ii < tokenCount; ii++) {
                    Vector3 spawnPosition = new Vector3(transform.position.x + i * offset, transform.position.y - ii * offset, transform.position.z - 1);
                    GameObject token = PhotonNetwork.Instantiate(tokenPrefab.name, spawnPosition, Quaternion.identity);
                    token.GetComponent<TokenController>().colour = i;
                    token.GetComponent<TokenController>().number = (ii + 1).ToString();
                }
            }
            for(int i = 0; i < colors.Length; i++) {
                for(int ii = 0; ii < tokenCount; ii++) {
                    Vector3 spawnPosition = new Vector3(transform.position.x + i * offset + offset * colors.Length, transform.position.y - ii * offset, transform.position.z - 1);
                    GameObject token = PhotonNetwork.Instantiate(tokenPrefab.name, spawnPosition, Quaternion.identity);
                    token.GetComponent<TokenController>().colour = i;
                    token.GetComponent<TokenController>().number = (ii + 1).ToString();
                }
            }
        }
    }
}
