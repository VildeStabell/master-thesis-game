using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour {
    RoundController roundCtrl;

    // Start is called before the first frame update
    void Start() {
        roundCtrl = GameObject.Find("RoundController").GetComponent<RoundController>();
    }
    
    /** 
        Triggers when an object falls below the board
        Destroys the object and detracts a life
    */
    void OnTriggerEnter(Collider collider) {
        roundCtrl.loseLife();
        Destroy(collider.gameObject);
    }
}
