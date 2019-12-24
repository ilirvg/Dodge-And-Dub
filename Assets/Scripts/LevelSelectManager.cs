using UnityEngine;
using UnityEngine.UI;

public class LevelSelectManager : MonoBehaviour {

    public LevelManager levelManager;
    public Button[] levelButtons;
    public GameObject[] levelLockedPanel;

    private void Start() {
        int levelReached = PlayerPrefsManager.GetUnlockedLevel();

        for (int i = 0; i < levelButtons.Length; i++) {

            if (i + 1 > levelReached)
                levelButtons[i].interactable = false;
            else
                levelLockedPanel[i].SetActive(false);
        }
    }
    public void Select(string levelName) {
        levelManager.LoadLevel(levelName);

    }
}
