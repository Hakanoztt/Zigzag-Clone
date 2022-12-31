using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public Transform playerLocation;
    Vector3 distance;

    public Player player;

    void Start() {
        distance = transform.position - playerLocation.position;
    }

    private void LateUpdate() {
        CamMovement();
    }

    void CamMovement() {
        if (player.isFall==false) {
            transform.position = playerLocation.position + distance;
        }
 
    }
}
