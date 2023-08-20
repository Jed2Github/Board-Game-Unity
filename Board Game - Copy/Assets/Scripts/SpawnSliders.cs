using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnSliders : MonoBehaviour {
    public GameObject sliderPrefab;

    public Vector4[] positions;
    public Vector3[] rotations;
    public float scale;

    PhotonView view;

    void Start() {
        view = GetComponent<PhotonView>();
        view.RPC("SyncTransform", RpcTarget.AllBuffered);
        if (view.IsMine) {
            for(int i = 0; i < 4; i++) {
                GameObject sliderGameObject = PhotonNetwork.Instantiate(sliderPrefab.name, Vector3.zero, Quaternion.identity);
                view.RPC("SetValues", RpcTarget.AllBuffered, sliderGameObject.GetComponent<PhotonView>().ViewID, i);
            }
        }
    }

    [PunRPC] 
    void SetValues(int sliderObjectIndex, int index) {
        GameObject sliderObject = PhotonView.Find(sliderObjectIndex).gameObject;
        sliderObject.transform.parent = transform;
        sliderObject.transform.localScale = new Vector3(scale, scale, scale);
        sliderObject.transform.rotation = Quaternion.Euler(rotations[index]);
        sliderObject.GetComponent<Slider>().positions = positions[index];
    }

    [PunRPC]
    void SyncTransform() {
        transform.localPosition = Vector3.zero;
        transform.localScale = new Vector3(0.1f, 0.1f, 1f);
    }
}
