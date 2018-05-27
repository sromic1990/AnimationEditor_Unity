using UnityEngine;
using System.Collections;

public class VirtualLine : MonoBehaviour {
	
	void Start() {
	}
	
	void CalculateLine() {
		/* alias */
		VertexSelection selectedVertex = EditorController.workspace.selectedVertex;
		
		if( selectedVertex == null ) return;
		
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
		
		Vector3 centerPos = ( selectedVertex.transform.position + newPosition ) / 2f;
		Vector3 diff = newPosition - selectedVertex.transform.position;
		
		float distance = diff.magnitude;
		float angle = xDMath.AngleFromAToB( newPosition, selectedVertex.transform.position ) * Mathf.Rad2Deg;
		
		transform.position = centerPos;
		transform.localScale = new Vector3 ( distance, transform.localScale.y, transform.localScale.z );
		transform.rotation = Quaternion.Euler ( new Vector3( 0f, 0f, angle) );
	}
	
	void Update () {
		CalculateLine ();
	}
}
