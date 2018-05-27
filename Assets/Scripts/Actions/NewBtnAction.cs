using UnityEngine;
using System.Collections;

public class NewBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		
		EditorController.workspace.ResetActivity();
		EditorController.movieData.NewMovie();
		EditorController.framesControl.GoToFrame( 1 );
		EditorController.messages.ShowMessage("New movie was created");
	}
	
}
