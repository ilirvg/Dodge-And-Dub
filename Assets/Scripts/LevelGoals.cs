using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelGoals : MonoBehaviour {

    private int tokensToCompleatLevel;
    private string sceneName;

    public LevelManager levelManager;
    public int levelToUnlock;
    public Instructions instructions;

    public TextMeshProUGUI tokensToCompleatLevelText;

    private void Awake() {
        sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "03a Level 02") {
            tokensToCompleatLevel = 10;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 03") {
            tokensToCompleatLevel = 12;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 04") {
            tokensToCompleatLevel = 30;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 06") {
            tokensToCompleatLevel = 8;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 07") {
            tokensToCompleatLevel = 15;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 08") {
            tokensToCompleatLevel = 25;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 09") {
            tokensToCompleatLevel = 30;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 10") {
            tokensToCompleatLevel = 60;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 11") {
            tokensToCompleatLevel = 10;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
        else if (sceneName == "03a Level 12") {
            tokensToCompleatLevel = 28;
            tokensToCompleatLevelText.text = tokensToCompleatLevel.ToString();
        }
    }

    void Start () {
        gameObject.SetActive(true);
        GameController.Instance.AreLevelGoalsShown = true;
        GameController.Instance.IsGameON = false;
        instructions.targetImg.SetActive(false);
        StartCoroutine(StartGame());
    }


    IEnumerator StartGame() {
        yield return new WaitForSeconds(2.2f);
        GameController.Instance.AreLevelGoalsShown = false;
        if (GameController.Instance.IsPlayerMoving == false) { 
            instructions.targetImg.SetActive(true);
        }
    }

    public void IsLevelCompleated(GameObject compleateUI, GameObject unCompleateUI) {
        if (PlayerPrefsManager.GetLastTokensScore() >= tokensToCompleatLevel) {
            WinLevel();
            compleateUI.SetActive(true);
            GameController.Instance.IsLevelCompleated = true;
            Invoke("LoadNextLevel", 2f);
        }
        else {
            unCompleateUI.SetActive(true);
            GameController.Instance.IsLevelCompleated = true;
        }
    }

    public void LoadNextLevel() {
        levelManager.LoadNextLevel();
    }

    private void WinLevel() {
        if (PlayerPrefsManager.GetUnlockedLevel() <= levelToUnlock)
            PlayerPrefsManager.SetUnlockedLevel(levelToUnlock);
    }

    public int TokensToCompleatLevel {
        get{ return tokensToCompleatLevel;}
    }

}
