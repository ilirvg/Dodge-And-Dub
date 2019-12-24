using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

    private Light lt;

    void Start() {
        lt = GetComponent<Light>();
    }

    void Update () {

        if (GameController.Instance.IsPlayerInPortal) {
            lt.color = new Color32(255, 5, 0, 255);
            lt.intensity = 100;
        }
        else {
            lt.color = new Color32(0, 52, 193, 255);
            lt.intensity = 2;
        }
	}
}
