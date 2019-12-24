using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour {

    public float fadeInTime;

    private Image myPanel;
    private Color currentColor = Color.black;

	void Start () {
        myPanel = GetComponent<Image>();
        myPanel.color = currentColor;    
	}

	void Update () {
        if (Time.timeSinceLevelLoad < fadeInTime){
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            myPanel.color = currentColor;
        }
        else {
            gameObject.SetActive(false);
        }   
	}
}
