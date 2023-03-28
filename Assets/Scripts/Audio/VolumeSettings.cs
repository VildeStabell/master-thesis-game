using System;
using UnityEngine;

[Serializable]
public class VolumeSettings {
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;

    public VolumeSettings(float masterVolume, float musicVolume, float sfxVolume) {
        this.masterVolume = verified(masterVolume);
        this.musicVolume = verified(musicVolume);
        this.sfxVolume = verified(sfxVolume);
    }

    /**
        Changes the volume to acceptable levels if it is too low or too high
    */
    private float verified(float value) {
        if (value > 1) {
            return 1;
        } else if (value < 0) {
            return 0;
        }

        return value;
    }
}
