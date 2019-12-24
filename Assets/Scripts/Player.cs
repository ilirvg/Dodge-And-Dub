using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Utility;

public class Player : MonoBehaviour {

    private float tileRightEdge = 4.3f;
    private float tileLeftEdge = -4.3f;
    private float direction = 0;
    private float tileCenterX = 0;
    private float tileCenterZ = 0;
    private string collided;
    private string exitCollider;
    private bool isTurning = false;
    private int skinSelected;
    private int skinDistanceBonus;
    private int skinSpeedBonus;
    private string sceneName;
    private Collider tileExit;

    public GameObject secondChanceMenuUI;
    //public bool isSecondInstructiOn = false;
    public TouchManager touchManager;
    public SmoothFollow smoothFollow;
    public float playerInLevelSpeed;
    public LevelSpawnController levelSpawnController;
    public GameObject firstSkin;
    public GameObject secondSkin;
    public GameObject thirdSkin;
    public GameObject fourthSkin;
    public GameObject instructionPosition;

    private void Start() {
        sceneName = SceneManager.GetActiveScene().name;
        skinSelected = PlayerPrefsManager.GetSelectedSkin();

        if (sceneName == "02 Endles Game") {
            if (PlayerPrefsManager.GetDifficulty() == "Easy")
                GameController.Instance.PlayerMovementSpeed = 46;
            else if (PlayerPrefsManager.GetDifficulty() == "Medium")
                GameController.Instance.PlayerMovementSpeed = 55;
            else if (PlayerPrefsManager.GetDifficulty() == "Hard")
                GameController.Instance.PlayerMovementSpeed = 63;
        }
        else
            GameController.Instance.PlayerMovementSpeed = playerInLevelSpeed;

        if (skinSelected == 0) {
            skinDistanceBonus = 0;
            skinSpeedBonus = 0;
            firstSkin.SetActive(true);
            secondSkin.SetActive(false);
            thirdSkin.SetActive(false);
            fourthSkin.SetActive(false);
        }
        else if (skinSelected == 1) {
            skinDistanceBonus = 1;
            skinSpeedBonus = 0;
            firstSkin.SetActive(false);
            secondSkin.SetActive(false);
            thirdSkin.SetActive(true);
            fourthSkin.SetActive(false);
        }
        else if (skinSelected == 2) {
            skinDistanceBonus = 2;
            skinSpeedBonus = -2;
            firstSkin.SetActive(false);
            secondSkin.SetActive(false);
            thirdSkin.SetActive(true);
            fourthSkin.SetActive(false);
        }
        else if (skinSelected == 3) {
            skinDistanceBonus = 3;
            skinSpeedBonus = -3;
            firstSkin.SetActive(false);
            secondSkin.SetActive(false);
            thirdSkin.SetActive(false);
            fourthSkin.SetActive(true);
        }
        GameController.Instance.PlayerMovementSpeed += skinSpeedBonus;
    }

    void Update() {
        if (GameController.Instance.IsGameON)
            Move();
    }

    private void Move() {
        transform.Translate(0, 0, 1 * GameController.Instance.PlayerMovementSpeed * Time.deltaTime);
        if (!isTurning)
            transform.position = touchManager.SideMovement(transform.position, direction, tileRightEdge, tileLeftEdge);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.name == "IsTurning") {
            collided = "";
            isTurning = false;
        }

        if (other.name == "Hole") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(90.0f, Vector3.right);
            }
        }
        if (other.name == "First") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                smoothFollow.height = 25;
            }
        }

        if (other.name == "Bottom Hole") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(-90f, Vector3.right);
                transform.position = new Vector3(transform.position.x, -10.5f, transform.position.z);
            }
        }
        if (other.name == "Stair Collider") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(-41.47f, Vector3.right);
                transform.position = new Vector3(transform.position.x, -10.5f, transform.position.z);
            }
        }
        if (other.name == "Third Stair") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                smoothFollow.height = 25;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(41.47f, Vector3.right);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
        if (other.name == "Start Path") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
            }
        }
        if (other.name == "RightTileCollider" || other.name == "FirstTileCollider") {
            if (collided == other.name) {
                return;
            }
            else {
                collided = other.name;
                isTurning = true;
                Quaternion currentRotation = transform.rotation;
                transform.rotation = currentRotation * Quaternion.AngleAxis(90, Vector3.up);
                direction += 90;
                DirectionReset();
                MinMaxSwipe(other);
            }
        }

        if (other.name == "LeftTileCollider") {
            if (collided == other.name) {
                return;
            }
            else {
                collided = other.name;
                isTurning = true;
                Quaternion currentRotation = transform.rotation;
                transform.rotation = currentRotation * Quaternion.AngleAxis(-90, Vector3.up);
                direction -= 90;
                DirectionReset();
                MinMaxSwipe(other);
            }
        }
        if (other.tag == "upTile") {
            if (collided == other.name)
                return;
            else {
                smoothFollow.distance = 55;
                collided = other.name;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(-30.011f, Vector3.right);
            }
        }
        if (other.tag == "streightTail") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                smoothFollow.height = 45;

                transform.rotation = transform.rotation * Quaternion.AngleAxis(30.011f, Vector3.right);
                transform.position = new Vector3(transform.position.x, 110, transform.position.z);
            }
        }
        if (other.tag == "downTile") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(30.011f, Vector3.right);
            }
        }
        if (other.tag == "lowDownTile") {
            if (collided == other.name)
                return;
            else {
                collided = other.name;
                smoothFollow.height = 25;
                smoothFollow.distance = 45;
                transform.rotation = transform.rotation * Quaternion.AngleAxis(-30.011f, Vector3.right);
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            }
        }
        if (other.name == "Portal(Clone)") {
            GameController.Instance.IsPlayerInPortal = true;
            StartCoroutine(OutOfPortal());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (sceneName == "02 Endles Game") {
            if (other.tag == "destroyTile" || other.tag == "lowDownTile") {
                if (!secondChanceMenuUI.activeSelf) {
                    TileManager.Instance.SpawnTile();
                    Destroy(other.transform.parent.gameObject, 8f);
                }
            }
            else if (other.name == "Start Path") {
                if (exitCollider == other.name)
                    return;
                else {
                    exitCollider = other.name;
                    TileManager.Instance.SpawnTile();
                    Destroy(other.gameObject, 8f);
                    GameController.Instance.ExitStartPath = true;
                    instructionPosition.SetActive(false);
                }
            }
        }
        else {
            if (other.tag == "destroyTile" || other.tag == "lowDownTile") {
                levelSpawnController.ActivateTile();
                Destroy(other.transform.parent.gameObject, 8f);
            }
            else if (other.name == "Start Path") {
                if (exitCollider == other.name)
                    return;
                else {
                    exitCollider = other.name;
                    levelSpawnController.ActivateTile();
                    Destroy(other.gameObject, 8f);
                    instructionPosition.SetActive(false);
                }
            }
        }
    }

    private void MinMaxSwipe(Collider other) {
        if (direction == 0) {
            tileCenterX = other.transform.parent.position.x;
            tileRightEdge = other.transform.parent.position.x + 4.3f;
            tileLeftEdge = other.transform.parent.position.x - 4.3f;
        }
        if (direction == 90) {
            tileCenterZ = other.transform.parent.position.z;
            tileRightEdge = other.transform.parent.position.z - 4.3f;
            tileLeftEdge = other.transform.parent.position.z + 4.3f;
        }
        if (direction == 180) {
            tileCenterX = other.transform.parent.position.x;
            tileRightEdge = other.transform.parent.position.x - 4.3f;
            tileLeftEdge = other.transform.parent.position.x + 4.3f;
        }
        if (direction == 270) {
            tileCenterZ = other.transform.parent.position.z;
            tileRightEdge = other.transform.parent.position.z + 4.3f;
            tileLeftEdge = other.transform.parent.position.z - 4.3f;
        }
    }

    private void DirectionReset() {
        if (direction == 360)
            direction = 0;
        else if (direction == -90)
            direction = 270;
    }

    public float Direction {
        get { return direction; }
    }

    public float TileCenterX {
        get { return tileCenterX; }
    }

    public float TileCenterZ {
        get { return tileCenterZ; }
    }

    public int SkinDistanceBonus {
        get { return skinDistanceBonus; }
    }

    IEnumerator OutOfPortal() {
        yield return new WaitForSeconds(0.1f);
        GameController.Instance.IsPlayerInPortal = false;
    }

    IEnumerator DelayHill() {
        yield return null;
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        Debug.Log(transform.position.y);
    }

    IEnumerator DelayTileDestroy(Collider tileExit) {
        yield return new WaitForSeconds(4f);
        if (!secondChanceMenuUI.activeSelf) {
            Debug.Log("D");
            Destroy(tileExit.transform.parent.gameObject);
        }
    }
}


