using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;

[ RequireComponent( typeof( EditorMovieData ) ) ]
[ RequireComponent( typeof( EditorCreator ) ) ]
[ RequireComponent( typeof( EditorMoviePlayer ) ) ]
[ RequireComponent( typeof( EditorMessages ) ) ]
[ RequireComponent( typeof( EditorWorkspace ) ) ]

public class EditorController : SceneSingleton<EditorController> {

	/* aliases */
	public static EditorMovieData movieData {
		get { return EditorController.Instance.GetComponent<EditorMovieData>(); }
	}
	public static EditorCreator creator {
		get { return EditorController.Instance.GetComponent<EditorCreator>(); }
	}
	public static EditorMoviePlayer moviePlayer {
		get { return EditorController.Instance.GetComponent<EditorMoviePlayer>(); }
	}
	public static EditorMessages messages {
		get { return EditorController.Instance.GetComponent<EditorMessages>(); }
	}
	public static EditorFramesControl framesControl {
		get { return EditorController.Instance.GetComponent<EditorFramesControl>(); }
	}	
	public static EditorWorkspace workspace {
		get { return EditorController.Instance.GetComponent<EditorWorkspace>(); }
	}		
	
	void Start() {
		messages.ShowMessage("Hello!");
	}
	
}
