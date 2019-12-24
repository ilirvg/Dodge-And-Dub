using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;

public class RestartSmoothFollow : MonoBehaviour {

	private SmoothFollow smoothFollow;

	private void Start() {
		smoothFollow = FindObjectOfType<SmoothFollow>();
		smoothFollow.enabled = false;
		
		StartCoroutine(EnableCoroutine());
	}

	private IEnumerator EnableCoroutine() {
		yield return new WaitForSeconds(0.1f);
		smoothFollow.enabled = true;
	}
}
