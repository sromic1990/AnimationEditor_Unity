using UnityEngine;
using System.Collections;

public class SaveBtnAction : GameAction {
	
	void Awake() {
	}
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		
		EditorController.workspace.ResetActivity();
		EditorController.framesControl.SaveCurrentFrame();
		EditorController.movieData.Trim();
		EditorController.movieData.Save();
	}
	
}
