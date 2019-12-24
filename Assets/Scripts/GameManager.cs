using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour {

    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 8;
    private float scoreToNextLevel = 10;
    private float difficultyMultier;
    private bool secondPortal = false;
    private float playerSpeed;
    private string sceneName;

    public Player player;

    private void Start() {
        //Advertisement.Initialize("1800180", false);
        //Advertisement.Initialize("1800180");
        //AdManager.Instance.RequestRewardBasedVideo();

        sceneName = SceneManager.GetActiveScene().name;
        StartCoroutine(DelayOnStart());
    }

    void Update () {       
        if (GameController.Instance.IsGameON) {
            if (GameController.Instance.Score >= 450 && !secondPortal && sceneName == "02 Endles Game") {
                secondPortal = true;
                GameController.Instance.IsSpaceHoleShowed = false;
                GameController.Instance.AreExtraCoinsSpawned = false;
            }
            if (GameController.Instance.Score >= scoreToNextLevel)
                LevelUp();
            
            GameController.Instance.Score += Time.deltaTime * difficultyMultier;
        }
    }

    private void LevelUp() {
        if (difficultyLevel == maxDifficultyLevel) 
            return;
        
        scoreToNextLevel *= 2f;
        difficultyLevel++;
        GameController.Instance.PlayerMovementSpeed += difficultyLevel;
    }

    IEnumerator DelayOnStart() {
        yield return new WaitForSeconds(0.5f);
        if (PlayerPrefsManager.GetDifficulty() == "Easy") {
            playerSpeed = GameController.Instance.PlayerMovementSpeed / 15;
        }
        if (PlayerPrefsManager.GetDifficulty() == "Medium") {
            playerSpeed = (GameController.Instance.PlayerMovementSpeed * 1.8f) / 15;
        }
        if (PlayerPrefsManager.GetDifficulty() == "Hard") {
            playerSpeed = (GameController.Instance.PlayerMovementSpeed * 2.8f) / 15;
        }
        difficultyMultier = playerSpeed + (playerSpeed * player.SkinDistanceBonus / 100);
    }
}
