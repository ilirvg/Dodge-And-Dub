using UnityEngine;

public class LevelFinishRing : MonoBehaviour {

    private AudioSource audioSource;

    public LevelGoals levelGoals;
    public GameObject compleateLevelUI;
    public GameObject unCompleateLevelUI;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            int comulativeTokens = PlayerPrefsManager.GetComulativeTokens() + GameController.Instance.Token;
            PlayerPrefsManager.SetComulativeTokens(comulativeTokens);
            PlayerPrefsManager.SetLastTokensScore(GameController.Instance.Token);
            PlaySound();
            levelGoals.IsLevelCompleated(compleateLevelUI, unCompleateLevelUI);
            GameController.Instance.IsGameON = false;
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
