using System;
using UnityEngine;
using System.Collections;

public class DeletableItem : MonoBehaviour {
		
	public EventHandler deleteEvent;
	public EventHandler deleteAnimStartEvent;
	public EventHandler deleteAnimStopEvent;
	
	void OnMouseEnter() {
		if( EditorController.workspace.cursor.state == CursorState.Delete ) {
			GetComponent<BaseAnimation>().StartAnimation();
			if( deleteAnimStartEvent != null ) deleteAnimStartEvent( this, EventArgs.Empty );
		}
	}

	void OnMouseExit() {
		if( EditorController.workspace.cursor.state == CursorState.Delete ) {
			GetComponent<BaseAnimation>().StopAnimation();
			if( deleteAnimStopEvent != null ) deleteAnimStopEvent( this, EventArgs.Empty );
		}
	}
	
	void OnMouseDown() {
		if( EditorController.workspace.cursor.state == CursorState.Delete ) {
			DestroyItem();
		}		
	}
	
	public void DestroyItem() {
		if( deleteEvent != null ) deleteEvent( this, EventArgs.Empty );
		Destroy( gameObject );
	}
}
