using UnityEngine;
using System.Collections;

public class Workspace : MonoBehaviour {
	
	void OnMouseDown() {
		if( EditorController.workspace.cursor.state == CursorState.Create ) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
			EditorController.workspace.ManualCreateVertex( newPosition );
		}
	}
}
