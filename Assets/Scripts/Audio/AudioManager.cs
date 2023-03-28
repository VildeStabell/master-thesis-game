using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour {
    public static AudioManager instance { get; private set; }

    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float sfxVolume = 1;

    private Bus masterBus;
    private Bus musicBus;
    private Bus sfxBus;

    private List<EventInstance> eventInstances;

    private EventInstance musicEventInstance;

    private void Awake() {
        if (instance != null) {
            Debug.LogError("Found more than one Audio Manager in the scene ");
        }
        instance = this;

        eventInstances = new List<EventInstance>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");

        // Get volume settings from json
        var json = PlayerPrefs.GetString("volume");
        VolumeSettings settings = JsonUtility.FromJson<VolumeSettings>(json);
        if (settings != null) {
            masterVolume = settings.masterVolume;
            musicVolume = settings.musicVolume;
            sfxVolume = settings.sfxVolume;
        }
    }

    private void Update() {
        masterBus.setVolume(masterVolume);
        musicBus.setVolume(musicVolume);
        sfxBus.setVolume(sfxVolume);
    }

    /**
        Play one sound until it is done (can overlap with others)
    */
    public void PlayOneShot(EventReference sound, Vector3 worldPos) {
        RuntimeManager.PlayOneShot(sound, worldPos);
    }

    /**
        Start an instance to be able to play continous sounds
    */
    public EventInstance CreateEventInstance(EventReference eventReference) {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.Add(eventInstance);
        return eventInstance;
    }

    /**
        Begin playing music
    */
    public void InitializeMusic(EventReference musicEventReference) {
        musicEventInstance = RuntimeManager.CreateInstance(musicEventReference);
        musicEventInstance.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(Vector3.zero));
        musicEventInstance.start();
    }

    /**
        Pause or resume the sound effects that were playing before this method was called
        True pauses, false unpauses
    */
    public void PauseSounds(bool pause) {
        foreach (EventInstance eventInstance in eventInstances) {
            eventInstance.setPaused(pause);
        }
    }

    /**
        Stop and release any created eventInstances
    */
    private void CleanUp() {
        foreach (EventInstance eventInstance in eventInstances) {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }

        musicEventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicEventInstance.release();
    }

    /**
        Cleanup any remaining eventInstances on scene change
    */
    private void OnDestroy() {
        CleanUp();

        //Save volume settings
        VolumeSettings volumeSettings = new VolumeSettings(masterVolume, musicVolume, sfxVolume);
        var json = JsonUtility.ToJson(volumeSettings);
        PlayerPrefs.SetString("volume", json);
    }
}
