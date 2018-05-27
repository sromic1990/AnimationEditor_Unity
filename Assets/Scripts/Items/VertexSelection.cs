using UnityEngine;
using System.Collections;

public class VertexSelection : MonoBehaviour {
	
	void OnMouseDown() {
		
	}
	
	void OnMouseUp() {
		if( EditorController.workspace.cursor.state == CursorState.Create ) {
			/* If nothing is selected */
			if( EditorController.workspace.selectedVertex == null ) {
				/* If user don't move vertex, then select it. */
				if ( !GetComponent<VertexDragNDrop>().isDragged ) {
					EditorController.workspace.SetSelectedVertex( this );
				}
				
			/* If some vertex is already selected */
			} else {
				
				/* If I'm is selected - then deselect me */
				if( EditorController.workspace.selectedVertex == this ) {
					EditorController.workspace.SetSelectedVertex( null );
				} else {
	
					/* If selected other vertex, then try to draw line between us */
					EditorController.workspace.ManualCreateLine( GetComponent<Vertex>(), EditorController.workspace.selectedVertex.GetComponent<Vertex>() );
					EditorController.workspace.SetSelectedVertex( null );
				}
			}
		}
	}

}
