using UnityEngine;
using System.Collections;

public class Instructions : MonoBehaviour {

    public TouchManager touchManger;

    public GameObject targetImg;

    public GameObject firstInstruction;
    public GameObject secondInstruction;

    private bool isFirstInstructiOn = false;
    private RaycastHit hit;

    void Start() {
        GameController.Instance.IsGameON = false;
        GameController.Instance.InstructionsOn = true;
        isFirstInstructiOn = true;
    }
    private void Update() {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePosFar = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane);

            StartMoving(mousePosFar, mousePosNear);
        }
        else if (Input.touchCount > 0) {
            Vector3 mousePosFar = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.farClipPlane);
            Vector3 mousePosNear = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, Camera.main.nearClipPlane);

            StartMoving(mousePosFar, mousePosNear);
        }
        if (GameController.Instance.ExitStartPath ) { //&& AdManager.Instance.InstructionsShown == 0// Comented New
            //AdManager.Instance.InstructionsShown++;// Comented New
            GameController.Instance.InstructionsOn = true;
            GameController.Instance.ExitStartPath = false;
            GameController.Instance.IsGameON = false;
            firstInstruction.SetActive(true);
        }

        if (touchManger.secondInstructionOFF) {
            secondInstruction.SetActive(false);
        }
    }

    private void StartMoving(Vector3 mousePosFar, Vector3 mousePosNear) {
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);

        if (Physics.Raycast(mousePosN, mousePosF - mousePosN, out hit)) {
            if (hit.transform.name == "Player") {
                if (isFirstInstructiOn) {
                    GameController.Instance.IsPlayerMoving = true;
                    targetImg.SetActive(false);
                    GameController.Instance.IsGameON = true;
                    GameController.Instance.InstructionsOn = false;
                    isFirstInstructiOn = false;
                }
            }
        }
    }

    public void FirstInstructionFinished() {          
        firstInstruction.SetActive(false);
        if (PlayerPrefsManager.GetIfInstructionsAreShown() == 0) { // show only once this instruction
            PlayerPrefsManager.SetIfInstructionsAreShown(1);
            StartCoroutine(SecondInstruction());
        }
    }

    public IEnumerator SecondInstruction() {
        yield return new WaitForSeconds(2.5f);
        secondInstruction.SetActive(true);
    }
}
    
