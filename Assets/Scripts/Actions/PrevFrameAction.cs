using UnityEngine;
using System.Collections;

public class PrevFrameAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.ResetActivity();
		EditorController.framesControl.SaveCurrentFrame();
		EditorController.framesControl.GoToFrame( EditorController.framesControl.currentFrameNum - 1 );
	}
}
