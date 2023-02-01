using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour {
    public GameObject[] objectPrefabs;

    private RoundController roundCtrl;

    // Spawnable area coordinates
    private float spawnMin;
    private float spawnMax;

    // Tweakable from inspector
    public float spawnHeight = 5;
    public float startTime = 2.0f;
    public float startFrequency = 20.0f;
    public float frequencyIncrease = 0.99f;

    // Start is called before the first frame update
    void Start() {
        roundCtrl = gameObject.GetComponent<RoundController>();

        StartCoroutine(SpawnAfterSeconds());
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
        Starts the recursive spawning of objects
    */
    IEnumerator SpawnAfterSeconds() {
       yield return new WaitForSeconds (startTime);

       // Calculates the spawnable area
       Vector3 boxColliderSize = roundCtrl.getBoard().GetComponent<BoxCollider>().size;
       float sideLength = Mathf.Sqrt(Mathf.Pow(boxColliderSize.x, 2) + Mathf.Pow(boxColliderSize.z, 2))/2;
       spawnMin = -sideLength/2;
       spawnMax = sideLength/2;

       SpawnNewObject();

       StartCoroutine(SpawnAfterSeconds(startFrequency));
    }
    
    /**
        Spawns an object after waiting for the specified amount of seconds
    */
    IEnumerator SpawnAfterSeconds(float seconds) {
       yield return new WaitForSeconds (seconds);

       SpawnNewObject();

       StartCoroutine(SpawnAfterSeconds(seconds*frequencyIncrease));
    }
}
