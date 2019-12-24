using UnityEngine;

public class MaterialManager : MonoBehaviour {

    public Material[] tileMaterialsArray;
    public Material[] obsMaterialsArray;

    int tileRandomMaterial;
    int obsRandomMaterial;

    void Awake () {
        tileRandomMaterial = Random.Range(0, 4);
        GameController.Instance.TileMaterial = tileMaterialsArray[tileRandomMaterial];

        obsRandomMaterial = Random.Range(0, 5);
        GameController.Instance.ObsMaterial = obsMaterialsArray[obsRandomMaterial];
        GameController.Instance.ObsHideMaterial = obsMaterialsArray[5];
    }
}
