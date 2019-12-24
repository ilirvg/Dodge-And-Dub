using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawnController : MonoBehaviour {

    public Transform[] ObstaclesSpawnPoints;
    public Transform[] CoinsSpawnPoints;
    public GameObject[] Obstacles;
    public GameObject[] Coins;
    public GameObject[] Tiles;

    private int tileToActivate;
    private string sceneName;
    private int randomIndex;

    void Start() {
        sceneName = SceneManager.GetActiveScene().name;
        GameController.Instance.IsGameInLevels = true;
        tileToActivate = 0;

        foreach (Transform t in ObstaclesSpawnPoints) {
            if (sceneName == "03a Level 01") {
                randomIndex = Random.Range(0, 3);
            }
            else if (sceneName == "03a Level 02") {
                randomIndex = Random.Range(0, 5);
            }
            else if (sceneName == "03a Level 03" || sceneName == "03a Level 04") {
                randomIndex = Random.Range(0, 6);
            }
            else if (sceneName == "03a Level 05") {
                randomIndex = Random.Range(0, 7);
            }
            else if (sceneName == "03a Level 06") {
                randomIndex = Random.Range(0, 8);
            }
            else if (sceneName == "03a Level 07") {
                randomIndex = Random.Range(0, 5);
            }
            else if (sceneName == "03a Level 08") {
                randomIndex = Random.Range(0, 6);
            }
            else if (sceneName == "03a Level 09") {
                randomIndex = Random.Range(0, 5);
            }
            else if (sceneName == "03a Level 10") {
                randomIndex = Random.Range(0, 5);
            }
            else if (sceneName == "03a Level 11") {
                randomIndex = Random.Range(0, 8);
            }
            else if (sceneName == "03a Level 12") {
                randomIndex = Random.Range(0, 6);
            }
            GameObject currentObs = Instantiate(Obstacles[randomIndex], t.position, t.rotation) as GameObject;
            currentObs.transform.parent = t;
        }

        foreach (Transform t in CoinsSpawnPoints) {
                int randomIndex = Random.Range(0, 3);
                GameObject currentCoin = Instantiate(Coins[randomIndex], t.position, t.rotation) as GameObject;
                currentCoin.transform.parent = t;
        }
    }

    public void ActivateTile(){
        if(tileToActivate<= Tiles.Length) { 
            Tiles[tileToActivate].SetActive(true);
            tileToActivate++;
        }
    }
    
}
