using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    public GameObject lightTrailPrefab;
    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if (audioSource.time > 3) {
            audioSource.Stop();
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlaySound();
            GameObject expl = Instantiate(lightTrailPrefab, transform.position, transform.rotation) as GameObject;
            Destroy(gameObject, 5f);
            Destroy(expl, 5f); 
        }
    }
    private void PlaySound() {
        int mute = PlayerPrefsManager.GetMasterSound();
        if (mute == 0)
            audioSource.mute = false;
        else if (mute == 1)
            audioSource.mute = true;
        audioSource.Play();
    }


}
