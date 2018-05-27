using UnityEngine;
using System.Collections;

public class LoadUserMovieBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.ResetActivity();
		EditorController.movieData.LoadUserMovie();
		EditorController.framesControl.GoToFrame( 1 );
	}
	
}
