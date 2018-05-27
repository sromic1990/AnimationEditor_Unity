using System;
using UnityEngine;
using System.Collections;

public class FrameCounterUI : MonoBehaviour {

	void Start () {
		EditorController.framesControl.frameChangedEvent += ChangeFrameHandler;
	}
	
	void ChangeFrameHandler( object s, EventArgs e ) {
		GetComponent<TextMesh>().text = EditorController.framesControl.currentFrameNum.ToString();
	}
}
