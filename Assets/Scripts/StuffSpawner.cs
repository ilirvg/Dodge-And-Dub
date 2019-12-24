using System.Collections;
using UnityEngine;

public class StuffSpawner : MonoBehaviour {

    public Transform[] ObstaclesSpawnPoints;    
    public Transform[] CoinsSpawnPoints;
    public Transform[] ExtraCoinsSpawnPoints;
    public GameObject[] Obstacles;
    public GameObject[] Coins;
    public Transform smokeSpawnPoint;
    public GameObject somoke;
    public GameObject rotationOff;
    public bool extraCoinsSpawned = false;

    private int randomIndex;
    private int smokeTileCode;

    void Start () {
        GameController.Instance.AreExtraCoinsSpawned = false;
        StartCoroutine(RotateOff());
        GameController.Instance.IsGameInLevels = false;

        foreach (Transform t in ObstaclesSpawnPoints) {

            #region difficultyEasy
            if (PlayerPrefsManager.GetDifficulty() == "Easy") {
                if (GameController.Instance.PlayerMovementSpeed < 62) 
                    randomIndex = Random.Range(0, 7);
                else if (GameController.Instance.PlayerMovementSpeed >= 62 && GameController.Instance.PlayerMovementSpeed < 70) 
                    randomIndex = Random.Range(0, 10);
                else 
                    randomIndex = Random.Range(0, 13);

                if (GameController.Instance.PlayerMovementSpeed >= 60 && !GameController.Instance.IsSpaceHoleShowed) {
                    ActivateSpaceHole();
                }
            }
            #endregion

            #region difficultyMedium
            else if (PlayerPrefsManager.GetDifficulty() == "Medium") {
                if (GameController.Instance.PlayerMovementSpeed < 62) 
                    randomIndex = Random.Range(0, 7);
                else if (GameController.Instance.PlayerMovementSpeed >= 62 && GameController.Instance.PlayerMovementSpeed < 70) 
                    randomIndex = Random.Range(0, 10);
                else if (GameController.Instance.PlayerMovementSpeed >= 70 && GameController.Instance.PlayerMovementSpeed < 80) 
                    randomIndex = Random.Range(3, 12);
                else 
                    randomIndex = Random.Range(3, 13);
                
                if (GameController.Instance.PlayerMovementSpeed >= 70 && !GameController.Instance.IsSpaceHoleShowed) {
                    ActivateSpaceHole();
                }
            }
            #endregion

            #region difficultyHard
            else if (PlayerPrefsManager.GetDifficulty() == "Hard") {
                if (GameController.Instance.PlayerMovementSpeed < 62) 
                    randomIndex = Random.Range(0, 7);
                else if (GameController.Instance.PlayerMovementSpeed >= 62 && GameController.Instance.PlayerMovementSpeed < 70) 
                    randomIndex = Random.Range(0, 12);
                else if (GameController.Instance.PlayerMovementSpeed >= 70 && GameController.Instance.PlayerMovementSpeed < 80) 
                    randomIndex = Random.Range(4, 13);
                else
                    randomIndex = Random.Range(5, 13);

                if (GameController.Instance.PlayerMovementSpeed >= 80 && !GameController.Instance.IsSpaceHoleShowed) {
                    ActivateSpaceHole();
                }
            }
            #endregion

            GameObject currentObs = Instantiate(Obstacles[randomIndex], t.position, t.rotation) as GameObject;
            currentObs.transform.parent = t;
        }

        foreach (Transform t in CoinsSpawnPoints) {

            #region difficultyEasy
            if (PlayerPrefsManager.GetDifficulty() == "Easy") {
                int randomIndex = Random.Range(0, 3);
                float chance = Random.value;
                if (chance < 0.40) {
                    GameObject currentCoin = Instantiate(Coins[randomIndex], t.position, t.rotation) as GameObject;
                    currentCoin.transform.parent = t;
                }
            }
            #endregion

            #region difficultyMedium
            else if (PlayerPrefsManager.GetDifficulty() == "Medium") {
                int randomIndex = Random.Range(0, 3);
                float chance = Random.value;
                if (chance < 0.70) {
                    GameObject currentCoin = Instantiate(Coins[randomIndex], t.position, t.rotation) as GameObject;
                    currentCoin.transform.parent = t;
                }
            }
            #endregion

            #region difficultyHard
            else if (PlayerPrefsManager.GetDifficulty() == "Hard") {
                int randomIndex = Random.Range(0, 3);
                float chance = Random.value;
                if (chance < 1) {
                    GameObject currentCoin = Instantiate(Coins[randomIndex], t.position, t.rotation) as GameObject;
                    currentCoin.transform.parent = t;
                }
            }
            #endregion
        }
    } 

    void Update() {
        if (GameController.Instance.IsPlayerInPortal && !GameController.Instance.AreExtraCoinsSpawned) {
            
            for (int i = 0; i < ExtraCoinsSpawnPoints.Length; i++) {
                if (smokeTileCode == ExtraCoinsSpawnPoints[i].transform.parent.GetHashCode()) {
                    GameController.Instance.AreExtraCoinsSpawned = true;
                    int selectToken;
                    if (i <= 10)  selectToken = 0; 
                    else if (i > 10 && i <= 18)  selectToken = 1; 
                    else  selectToken = 2; 
                    GameObject currentCoin = Instantiate(Coins[selectToken], ExtraCoinsSpawnPoints[i].position, ExtraCoinsSpawnPoints[i].rotation) as GameObject;
                    currentCoin.transform.parent = ExtraCoinsSpawnPoints[i];
                }  
            }
        }
    }

    private void ActivateSpaceHole() {
        GameController.Instance.IsSpaceHoleShowed = true;
        GameObject portal = Instantiate(somoke, smokeSpawnPoint.position, smokeSpawnPoint.rotation) as GameObject;
        portal.transform.parent = smokeSpawnPoint;
        smokeTileCode = smokeSpawnPoint.transform.parent.GetHashCode();
    }

    IEnumerator RotateOff() {
        yield return new WaitForSeconds(2f);
        if (name == "FirstTile") {
            rotationOff.transform.position += new Vector3(650 / GameController.Instance.PlayerMovementSpeed, 0, 0);
        }        
        else if (name == "LeftTile(Clone)") {
            float x = 950 / GameController.Instance.PlayerMovementSpeed;
            rotationOff.transform.Translate(-x, 0, 0, Space.Self);
        }
        else if (name == "RightTile(Clone)") {
            float x = 950 / GameController.Instance.PlayerMovementSpeed;
            rotationOff.transform.Translate(x, 0, 0, Space.Self);
        }
    }

}
