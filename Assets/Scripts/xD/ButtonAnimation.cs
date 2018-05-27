using UnityEngine;
using System.Collections;

public class ButtonAnimation : MonoBehaviour {

	public float moveSpeed = 0.5f;
	public float finishAngle = 10f;
	
	float startAngle;
	float targetAngle;

	void Start () {
		
		startAngle = transform.localRotation.eulerAngles.z;
		targetAngle = startAngle;
	}

	void OnMouseEnter() {
		targetAngle = transform.rotation.z + finishAngle;
	}

	void OnMouseExit() {
		targetAngle = startAngle;
	}
	
	void OnMouseDown() {
		targetAngle = startAngle;
	}

	void Update () {
		transform.rotation = Quaternion.Lerp( 
			transform.rotation, 
			Quaternion.Euler( new Vector3( transform.rotation.x, transform.rotation.y, targetAngle ) )
			, moveSpeed);
	}
}
