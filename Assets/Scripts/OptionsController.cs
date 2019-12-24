using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OptionsController : MonoBehaviour {

    public Toggle soundToggle;
    public string RATE_URL = "market://details?id=com.LucidVoid.DodgeAndDub";
    //public Image backgImage;

    private ToggleGroup difficultyToggleGroup;
    private MusicManager musicManager;

	void Start () {
        musicManager = FindObjectOfType<MusicManager>();

        difficultyToggleGroup = FindObjectOfType<ToggleGroup>();

        if (PlayerPrefsManager.GetMasterSound() == 0) 
            soundToggle.isOn = false;
        else if (PlayerPrefsManager.GetMasterSound() == 1)
            soundToggle.isOn = true;

        if (PlayerPrefsManager.GetDifficulty() == "Easy")
            ToggleDifficulty(0);
        else if (PlayerPrefsManager.GetDifficulty() == "Medium")
            ToggleDifficulty(1); 
        else if (PlayerPrefsManager.GetDifficulty() == "Hard")
            ToggleDifficulty(2); 
    }
    //private void Update() {
    //    backgImage.color = new Color32(214, 107, 20, 255);
    //}

    public void SoundToggle(bool toggle) {
        musicManager.AudioMute(toggle);
        if (toggle == true) {
            PlayerPrefsManager.SetMasterSound(1);
        }
        else if (toggle == false) {
            PlayerPrefsManager.SetMasterSound(0);
        }
    }

    public void ToggleDifficulty(int id) {
        var toggles = difficultyToggleGroup.GetComponentsInChildren<Toggle>();
        toggles[id].isOn = true;
    }

    public void SelectDifficulty() {
        PlayerPrefsManager.SetDifficulty(difficultyToggleGroup.ActiveToggles().FirstOrDefault().name);
    }

    public void RateUsButton() {
        Debug.Log("AA");
        Application.OpenURL(RATE_URL);
    }

}
