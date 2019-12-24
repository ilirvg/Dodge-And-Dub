using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.Utility{

	public class SmoothFollow : MonoBehaviour{
		[SerializeField]
		private Transform target;
        [SerializeField]
        public float distance;
		[SerializeField]
        public float height;
		[SerializeField]
		private float rotationDamping;
		[SerializeField]
		private float heightDamping;

        void Start() {
            InvokeRepeating("DelayOnStart", 1.0f, 25.0f);
        }
        void DelayOnStart() {
            rotationDamping = GameController.Instance.PlayerMovementSpeed / 9;
            heightDamping = GameController.Instance.PlayerMovementSpeed / 40;
        }
        //void FixedUpdate()// 
        void LateUpdate()
		{
            // Early out if we don't have a target
            if (!target) 
                return;
            

			// Calculate the current rotation angles
			var wantedRotationAngle = target.eulerAngles.y;
			var wantedHeight = target.position.y + height;

			var currentRotationAngle = transform.eulerAngles.y;
			var currentHeight = transform.position.y;

            // Damp the rotation around the y-axis
            currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

            //uncoment this one and coment the one before if not smooth rotation is desired
            //currentRotationAngle = wantedRotationAngle;

            // Damp the height
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);
            //Debug.Log(wantedHeight - currentHeight);

			// Convert the angle into a rotation
			var currentRotation = Quaternion.Euler(0, currentRotationAngle, 0);

			// Set the position of the camera on the x-z plane to:
			// distance meters behind the target
			transform.position = target.position;
			transform.position -= currentRotation * Vector3.forward * distance;

			// Set the height of the camera
			transform.position = new Vector3(transform.position.x ,currentHeight , transform.position.z);

			// Always look at the target
			transform.LookAt(target);
        }
    }

}