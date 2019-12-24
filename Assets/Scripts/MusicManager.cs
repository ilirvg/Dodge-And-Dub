using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    public AudioSource audioSource;
    private AudioClip thisLevelMusic;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        //audioSource.clip = levelMusicChangeArray[1];
        //Invoke("af", audioSource.clip.length);
    }
    void OnEnable()
    {
        //Tell our 'OnSceneLoaded' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnDisable()
    {
        //Tell our 'OnSceneLoaded' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 4) {
            if (PlayerPrefsManager.GetDifficulty() == "Easy") {
                thisLevelMusic = levelMusicChangeArray[1];
            }
            else if (PlayerPrefsManager.GetDifficulty() == "Medium") {
                thisLevelMusic = levelMusicChangeArray[2];
            }
            else if (PlayerPrefsManager.GetDifficulty() == "Hard") {
                thisLevelMusic = levelMusicChangeArray[3];
            }
            audioSource.volume = 0.7f;
        }
        else if (scene.buildIndex == 1) { 
            thisLevelMusic = levelMusicChangeArray[0];
            audioSource.volume = 1;
        }
        else if (scene.buildIndex == 5 || scene.buildIndex == 6 || scene.buildIndex == 7 || scene.buildIndex == 8) {
            thisLevelMusic = levelMusicChangeArray[1];
            audioSource.volume = 0.7f;
        }
        else if (scene.buildIndex == 9 || scene.buildIndex == 10 || scene.buildIndex == 11 || scene.buildIndex == 12) {
            thisLevelMusic = levelMusicChangeArray[2];
            audioSource.volume = 0.7f;
        }
        else if (scene.buildIndex == 13 || scene.buildIndex == 14 || scene.buildIndex == 15 || scene.buildIndex == 16) {
            thisLevelMusic = levelMusicChangeArray[3];
            audioSource.volume = 0.7f;
        }
        int mute = PlayerPrefsManager.GetMasterSound();
        audioSource.clip = thisLevelMusic;
        audioSource.loop = true;
        Mute(mute);
        audioSource.Play();
    }

    private void Mute(int mute) {
        if (mute == 0)
            audioSource.mute = false;
        else if (mute == 1)
            audioSource.mute = true;
    }
    public void ChangeVolume(float vol) {
        audioSource.volume = vol;
    }
    public void AudioMute(bool mute) {
        audioSource.mute = mute;
    }
}
