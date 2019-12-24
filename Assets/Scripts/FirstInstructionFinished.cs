using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstInstructionFinished : MonoBehaviour {

    public Instructions instruction;
	
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FinishedFirstInsruction() {
        GameController.Instance.ExitStartPath = false;
        GameController.Instance.InstructionsOn = false;
        GameController.Instance.IsGameON = true;
        instruction.FirstInstructionFinished();
    }
}
