using UnityEngine;

public class Obstacle : MonoBehaviour {
    public GameObject loseExplosionPrefab;
    public Renderer rend;
    public AudioSource audioSource;
    private bool isSpecialEffectOn = false;

    private void Start() {
        rend.sharedMaterial = GameController.Instance.ObsMaterial;
    }

    private void Update() {
        if (GameController.Instance.ClearPathEffect && !isSpecialEffectOn) {
            isSpecialEffectOn = true;
            rend.sharedMaterial = GameController.Instance.ObsHideMaterial;
            rend.enabled = false;
        }
        if (GameController.Instance.ClearPathEffect && !GameController.Instance.IsClearPathEffectOn) {
            rend.enabled = true;
        }
        if (!GameController.Instance.ClearPathEffect && isSpecialEffectOn) {
            isSpecialEffectOn = false;
            rend.sharedMaterial = GameController.Instance.ObsMaterial;
        }

        if (name == "Middle Part") {
            transform.Rotate(Vector3.up * 90 * Time.deltaTime, Space.World);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player" && !GameController.Instance.ClearPathEffect) {
            PlaySound();
            rend.enabled = false;
            GameController.Instance.IsGameON = false;
            GameObject expl = Instantiate(loseExplosionPrefab, other.transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject, 2.5f); // destroy the obs
            Destroy(expl, 2.5f); // delete the explosion after 3 seconds
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
