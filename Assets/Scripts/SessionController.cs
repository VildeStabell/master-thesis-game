using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionController : MonoBehaviour {
    public string[] gameModes = {"BalanceMode"};
    //public Player player;
    public static GameObject board;
    public string[] steeringModes = {"AngleRotation"};

    //These vars are public to be able to quickly change in inspector
    public int eqCad = 10; //TODO: temp num
    public int volume = 100;
    public bool invert = false;

    private RoundController roundCtrl;


    // Start is called before the first frame update
    void Start()
    {
        //---- Temp Code ----
        roundCtrl = new RoundController(board, gameModes[0], steeringModes, startMovement); 
        //-------------------
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**
        Get the current value of the volume setting
    */
    public int getVolume() {
        return volume;
    }

    /**
        Get the current value of the invert setting
    */
    public bool getInvert() {
        return invert;
    }

    /**
        Set the value of the volume setting
    */
    public void setVolume(int newVolume) {
        volume = newVolume;
    }

    /**
        Set the value of the invert setting
    */
    public void setInvert(bool newInvert) {
        invert = newInvert;
    }

    // ---- EventListeners ----
    public void moveRight() {
        if (roundCtrl != null) {
            roundCtrl.moveRight();
        }
    }

    public void moveLeft() {
        if (roundCtrl != null) {
            roundCtrl.moveLeft();
        }
    }

    /**
        Used by steeringmodes to run smooth movements
    */
    public void startMovement(IEnumerator movementTracker) {
        StartCoroutine(movementTracker);
    }
}
