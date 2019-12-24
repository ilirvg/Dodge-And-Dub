using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;
    public GameObject currentTile;

    private static TileManager instance;

    public static TileManager Instance {
        get {
            if (!instance) {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

    void Start () {
        for (int i = 0; i <= 0; i++) {
            SpawnTile();
        }
    }

    public void SpawnTile() {
        int randomIndex = Random.Range(0, 4);
        Transform currentTileSpawn = currentTile.transform.GetChild(0).transform.GetChild(randomIndex);
        currentTile = Instantiate(tilePrefabs[randomIndex], currentTileSpawn.position, currentTileSpawn.rotation) as GameObject;
    }
}
