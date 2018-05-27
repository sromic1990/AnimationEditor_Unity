using UnityEngine;
using System.Collections;

public class CopyBtnAction : GameAction {

	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.ResetActivity();
		
		EditorController.framesControl.SaveCurrentFrame();		
		EditorController.workspace.CopyFrame();
	}
}
