using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour {

    public GameObject lastPath, newPath;
    private Vector3 _dir;
    void Start() {

        for (int i = 0; i < 50; i++) {
            int randomPath = Random.Range(0, 2);
            int randomPoint = Random.Range(0, 10);

            if (randomPath == 0) {
                _dir = new Vector3(-1.5f, 0, 0);
            } else {
                _dir = new Vector3(0, 0, 1.5f);
            }


            lastPath = Instantiate(newPath, lastPath.transform.position + _dir, Quaternion.identity);

            if (randomPoint == 5) {
                lastPath.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    void Update() {

    }
    public void SpawnPath() {
            int randomPath = Random.Range(0, 2);
            int randomPoint = Random.Range(0, 10);

            if (randomPath == 0) {
                _dir = new Vector3(-1.5f, 0, 0);
            } else {
                _dir = new Vector3(0, 0, 1.5f);
            }


            lastPath = Instantiate(newPath, lastPath.transform.position + _dir, Quaternion.identity);

            if (randomPoint == 5) {
                lastPath.transform.GetChild(0).gameObject.SetActive(true);
            }
    }
}