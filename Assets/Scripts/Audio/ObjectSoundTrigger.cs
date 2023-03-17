using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class ObjectSoundTrigger : MonoBehaviour {
    // Whether or not the object is touching the board
    private bool onBoard = false;
    private EventInstance rollingSound;
    private Rigidbody rb;

    void Start() {
        rollingSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.objectRolling);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Update sound position
        FMOD.ATTRIBUTES_3D objectPos = FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform.position);
        rollingSound.set3DAttributes(objectPos);

        UpdateSound();
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Board")) {
            onBoard = true;
        }
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.CompareTag("Board")) {
            onBoard = false;
        }
    }

    /**
        Start or stop the rolling sound, depending on the objects state
    */
    private void UpdateSound() {
        // Start rolling sound if the object is moving and is touching the board
        if (!rb.IsSleeping() && onBoard) {
            // Start playing sound if not already started
            PLAYBACK_STATE playbackState;
            rollingSound.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED)) {
                rollingSound.start();
            }
        }
        // Otherwise stop the rolling sound
        else {
            rollingSound.stop(STOP_MODE.ALLOWFADEOUT);
        }

        // TODO: Different sounds for different objects (using tags?)
    }
}
