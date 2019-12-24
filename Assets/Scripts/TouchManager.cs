using System.Collections;
using UnityEngine;

public class TouchManager : MonoBehaviour {

    public SecondChanceMenu secondChanceMenu;
    public Vector3 mouseOffset;
    public bool secondInstructionOFF = false;

    private int dir = 0;
    private int tapCount;
    private float firstTouch;
    private float timeDifference;

    public Vector3 SideMovement(Vector3 playerPosition, float playerDirection, float tileRightEdge, float tileLeftEdge) {
        Vector3 mousePos = playerPosition;
        
        if (Input.touchCount == 1) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Begin(playerPosition);
            }

            else if (touch.phase == TouchPhase.Moved) {
                mousePos = OnMove(playerPosition, playerDirection, tileRightEdge, tileLeftEdge, mousePos);
            }

            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
                CountTaps();
                mousePos = playerPosition;
            }
            if (Time.time > firstTouch + 0.3f) {
                tapCount = 0;
            }
        }

        else if (Input.touchCount > 1) { }

        else {
            if (Input.GetMouseButtonDown(0)) {
                Begin(playerPosition);
            }
            else if (Input.GetMouseButton(0)) {
                mousePos = OnMove(playerPosition, playerDirection, tileRightEdge, tileLeftEdge, mousePos);
            }
            else if (Input.GetMouseButtonUp(0)) {
                CountTaps();
                mousePos = playerPosition;
            }
            if (Time.time > firstTouch + 0.3f) {
                tapCount = 0;
            }
        }

        return mousePos;
    }

    private Vector3 OnMove(Vector3 playerPosition, float playerDirection, float tileRightEdge, float tileLeftEdge, Vector3 mousePos) {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {

            if (playerDirection == 0) {
                if (dir == 90 || dir == 270) {
                    for (int i = 0; i < 100; i++) {
                        mouseOffset = Vector3.Lerp(mouseOffset, Vector3.zero, Time.smoothDeltaTime * i);
                    }
                    
                    dir = 0;
                }
                if (hit.point.x + mouseOffset.x >= tileRightEdge) {
                    mousePos = new Vector3(tileRightEdge, playerPosition.y, playerPosition.z);
                }
                else if (hit.point.x + mouseOffset.x <= tileLeftEdge) {
                    mousePos = new Vector3(tileLeftEdge, playerPosition.y, playerPosition.z);
                }
                else {
                    mousePos = new Vector3(hit.point.x + mouseOffset.x, playerPosition.y, playerPosition.z);
                }
            }
            else if (playerDirection == 180) {
                if (dir == 90 || dir == 270) {
                    for (int i = 0; i < 100; i++) {
                        mouseOffset = Vector3.Lerp(mouseOffset, Vector3.zero, Time.smoothDeltaTime * i);
                    }
                    dir = 180;
                }

                if (hit.point.x + mouseOffset.x <= tileRightEdge) {
                    mousePos = new Vector3(tileRightEdge, playerPosition.y, playerPosition.z);
                }
                else if (hit.point.x + mouseOffset.x >= tileLeftEdge) {
                    mousePos = new Vector3(tileLeftEdge, playerPosition.y, playerPosition.z);
                }
                else {
                    mousePos = new Vector3(hit.point.x + mouseOffset.x, playerPosition.y, playerPosition.z);
                }
            }
            else if (playerDirection == 90) {
                if (dir == 0 || dir == 180) {
                    for (int i = 0; i < 100; i++) {
                        mouseOffset = Vector3.Lerp(mouseOffset, Vector3.zero, Time.smoothDeltaTime * i);
                    }
                    dir = 90;
                }
                if (hit.point.z + mouseOffset.z <= tileRightEdge) {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, tileRightEdge);
                }
                else if (hit.point.z + mouseOffset.z >= tileLeftEdge) {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, tileLeftEdge);
                }
                else {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, hit.point.z + mouseOffset.z);
                }
            }
            else if (playerDirection == 270) {
                if (dir == 0 || dir == 180) {
                    for (int i = 0; i < 100; i++) {
                        mouseOffset = Vector3.Lerp(mouseOffset, Vector3.zero, Time.smoothDeltaTime * i);
                    }
                    dir = 270;
                }
                if (hit.point.z + mouseOffset.z >= tileRightEdge) {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, tileRightEdge);
                }
                else if (hit.point.z + mouseOffset.z <= tileLeftEdge) {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, tileLeftEdge);
                }
                else {
                    mousePos = new Vector3(playerPosition.x, playerPosition.y, hit.point.z + mouseOffset.z);
                }
            }
        }
        return mousePos;
    }

    public void Begin(Vector3 playerPosition) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit oHit;
        Physics.Raycast(ray, out oHit);
        Vector3 hitPoint = oHit.point;
        mouseOffset = playerPosition - hitPoint;
    }

    public IEnumerator DoubleTap() {
        GameController.Instance.ClearPathEffect = true;
        GameController.Instance.IsClearPathEffectOn = true;
        tapCount = 0;
        yield return new WaitForSeconds(8f);
        GameController.Instance.IsClearPathEffectOn = false;
        yield return new WaitForSeconds(2f);
        GameController.Instance.ClearPathEffect = false;
    }

    public IEnumerator SecondChance() {
        GameController.Instance.ClearPathEffect = true;
        GameController.Instance.IsClearPathEffectOn = true;
        tapCount = 0;
        yield return new WaitForSeconds(1f);
        GameController.Instance.IsClearPathEffectOn = false;
        yield return new WaitForSeconds(2f);
        GameController.Instance.ClearPathEffect = false;
    }

    private void CountTaps() {
        tapCount += 1;
        if (tapCount == 1) {
            firstTouch = Time.time;
        }
        if (tapCount == 2) {
            timeDifference = Time.time - firstTouch;
            if (timeDifference < 0.3f) {
                if (PlayerPrefsManager.GetDoubleTap() > 0) {
                    PlayerPrefsManager.SetDoubleTap(PlayerPrefsManager.GetDoubleTap() - 1);
                    secondChanceMenu.doubleTapText.text = ((int)PlayerPrefsManager.GetDoubleTap()).ToString();
                    secondInstructionOFF = true;
                    StartCoroutine(DoubleTap());
                }
            }
        }
    }
}
