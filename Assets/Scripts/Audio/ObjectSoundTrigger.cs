using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;

public class ObjectSoundTrigger : MonoBehaviour {
    // Whether or not the object is touching the board
    private bool onBoard = false;
    private EventInstance rollingSound;
    private EventInstance slidingSound;
    private Rigidbody rb;

    void Start() {
        rollingSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.objectRolling);
        slidingSound = AudioManager.instance.CreateEventInstance(FMODEvents.instance.objectSliding);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        // Update sound position
        FMOD.ATTRIBUTES_3D objectPos = FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform.position);
        rollingSound.set3DAttributes(objectPos);
        slidingSound.set3DAttributes(objectPos);

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
        // Start sound if the object is moving and is touching the board
        if (((Mathf.Abs(rb.velocity.x) > 0.1f) || (Mathf.Abs(rb.velocity.y) > 0.1f) || (Mathf.Abs(rb.velocity.z) > 0.1f)) && onBoard) {
            // Choose type of sound based on type of movement
            EventInstance sound;
            if ((Mathf.Abs(rb.angularVelocity.x) > 0.5f) || (Mathf.Abs(rb.angularVelocity.y) > 0.5f) || (Mathf.Abs(rb.angularVelocity.z) > 0.5f)) {
                sound = rollingSound;
                slidingSound.stop(STOP_MODE.ALLOWFADEOUT);
            } else {
                sound = slidingSound;
                rollingSound.stop(STOP_MODE.ALLOWFADEOUT);
            }

            // Start playing sound if not already started
            PLAYBACK_STATE playbackState;
            sound.getPlaybackState(out playbackState);
            if (playbackState.Equals(PLAYBACK_STATE.STOPPED)) {
                sound.start();
            }
        }
        // Otherwise stop the sound
        else {
            rollingSound.stop(STOP_MODE.ALLOWFADEOUT);
            slidingSound.stop(STOP_MODE.ALLOWFADEOUT);
        }
    }

    /**
        Stop sounds when object is destroyed
    */
    private void OnDestroy() {
        rollingSound.stop(STOP_MODE.ALLOWFADEOUT);
        slidingSound.stop(STOP_MODE.ALLOWFADEOUT);
    }
}
