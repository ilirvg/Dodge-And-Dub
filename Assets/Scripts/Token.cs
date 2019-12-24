using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Token : MonoBehaviour {

    public GameObject collectExplosionPrefab;

    private AudioSource audioSource;
   
    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update () {
        if (transform.root.name == "HillTile" || transform.root.name == "HillTile(Clone)") {
        }
        else {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            PlaySound();
            GameController.Instance.Token++;
            GameObject expl = Instantiate(collectExplosionPrefab, transform.position, Quaternion.identity) as GameObject;
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
            Destroy(transform.parent.gameObject, 1f); // destroy token
            Destroy(expl, 1); // delete the explosion after 3 seconds
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
