using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public GameObject[] objectPrefabs;

    private RoundController roundCtrl;
    
    // Spawnable area coordinates
    private float spawnMin;
    private float spawnMax;

    private float spawnHeight = 5;
    private bool coordinatesSet = false;


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
        GameObject prefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];
        float xCoord = Random.Range(spawnMin, spawnMax);
        float zCoord = Random.Range(spawnMin, spawnMax);
        
        Instantiate(prefab, new Vector3(xCoord, spawnHeight, zCoord), Quaternion.identity, roundCtrl.getBoard().transform);
    }

    /**
        Spawns an object after waiting for the specified amount of seconds
    */
    IEnumerator SpawnAfterSeconds(float seconds) {
       yield return new WaitForSeconds (seconds);

       // Calculates the spawnable area
       if (!coordinatesSet) {
           Vector3 boxColliderSize = roundCtrl.getBoard().GetComponent<BoxCollider>().size;
           float sideLength = Mathf.Sqrt(Mathf.Pow(boxColliderSize.x, 2) + Mathf.Pow(boxColliderSize.z, 2))/2;

           spawnMin = -sideLength/2;
           spawnMax = sideLength/2;

           coordinatesSet = true;  
       }

       SpawnNewObject();
    }

}
