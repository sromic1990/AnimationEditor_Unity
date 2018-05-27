using UnityEngine;
using System.Collections;

public class VertexDragNDrop : MonoBehaviour {

	private bool _isClicked = false;
	public bool isDragged = false;

	private Vector3 mouseDelta;
	
	void Update () {
		if( _isClicked ) {
			Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
			Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z) - mouseDelta;
			
			if( transform.position != newPosition ) {
				isDragged = true;
				transform.position = newPosition;
			}
		}
	}

	void OnMouseDown() {
		
		if( EditorController.workspace.cursor.state == CursorState.Create ) {
			/* We can move vertex only if it is not selected */
			if( EditorController.workspace.selectedVertex == null ) {
				Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
				Vector3 newPosition = new Vector3 (mousePosition.x, mousePosition.y, transform.position.z);
				
				mouseDelta = newPosition - transform.position;
				
				_isClicked = true;
				
				isDragged = false;
			}
		}
	}

	void OnMouseUp() {
		_isClicked = false;
	}
}
