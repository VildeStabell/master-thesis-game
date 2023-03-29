using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UISoundTrigger : MonoBehaviour, ISelectHandler {

    /**
        Plays the click sound when the element is clicked
        (must be set in the editor)
    */
    public void playClickSound() {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.uiClick, Vector3.zero);
    }

    /**
        Play sound when the element is selected
    */
    public void OnSelect(BaseEventData eventData) {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.uiMovement, Vector3.zero);
    }
}
