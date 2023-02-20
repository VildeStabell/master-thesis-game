using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameModeEnum {
    BalanceMode,
    ShapesMode,
    MarbleMode
};

public class SessionController : MonoBehaviour {
    public GameModeEnum[] gameModes = { GameModeEnum.BalanceMode };
    //public Player player;
    public string[] steeringModes = { "AngleRotation" };

    private float eqCad = 0.5f; //TODO: temp num

    //These vars are public to be able to quickly change in inspector


    public int volume = 100;
    public bool invert = false;

    public static SessionController sessionCtrl; // Needed for persistance, can be accessed for settings etc.

    void Awake() {
        //Makes sure the data is persistent between scenes
        if (sessionCtrl == null) {
            DontDestroyOnLoad(gameObject);
            sessionCtrl = this;
        } else if (sessionCtrl != this) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

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

    public void setEqCadence(float newEqCad) {
        eqCad = newEqCad;
    }

    public float getEqCadence() {
        return eqCad;
    }
}
