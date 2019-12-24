using UnityEngine;

public class TileController : MonoBehaviour {

    private AudioSource audioSource;
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = GameController.Instance.TileMaterial;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && name == "Hole") {
            PlaySound();
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
