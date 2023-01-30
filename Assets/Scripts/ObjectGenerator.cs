using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public GameObject[] objectPrefabs;

    private RoundController roundCtrl;

    // Start is called before the first frame update
    void Start() {
        roundCtrl = gameObject.GetComponent<RoundController>();

        // ---- Temp code ----
        StartCoroutine( SpawnAfterSeconds(3.0f) );
        // -------------------
    }

    // Update is called once per frame
    void Update() {
        
    }

    void SpawnNewObject() {
        Instantiate(objectPrefabs[0], new Vector3(1, 5, 2), Quaternion.identity, roundCtrl.getBoardTransform());
    }

    /**
        Spawns an object after waiting for the specified amount of seconds
    */
    IEnumerator SpawnAfterSeconds(float seconds) {
       yield return new WaitForSeconds (seconds);

       SpawnNewObject();
    }

}
