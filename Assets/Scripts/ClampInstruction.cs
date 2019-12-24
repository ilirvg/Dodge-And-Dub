using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClampInstruction : MonoBehaviour {

    //public Image instructionImg;
    public Image targetImg;

    void Start () {
        
	}
	

	void Update () {
        Vector3 imgPos = Camera.main.WorldToScreenPoint(this.transform.position);
        //instructionImg.transform.position = imgPos;
        targetImg.transform.position = imgPos;
    }
}
