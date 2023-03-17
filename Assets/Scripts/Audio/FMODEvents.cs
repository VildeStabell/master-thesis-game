using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour {
    [field: Header("Object SFX")]
    [field: SerializeField] public EventReference objectSpawned { get; private set; }
    [field: SerializeField] public EventReference objectRolling { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one Audio Manager in the scene ");
        }
        instance = this;
    }

}
