using UnityEngine;
using System.Collections;

public class LoadSampleMovieBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.ResetActivity();
		EditorController.movieData.LoadSampleMovie();
		EditorController.framesControl.GoToFrame( 1 );
	}
	
}
