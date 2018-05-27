using UnityEngine;
using System.Collections;

public class PlayBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		
		if( !EditorController.moviePlayer.isPlay ) {
			
			EditorController.workspace.ResetActivity();

			EditorController.framesControl.SaveCurrentFrame();
			EditorController.movieData.Trim();
			
			EditorController.moviePlayer.Play();
			
		} else {
			EditorController.moviePlayer.Stop();
		}
	}
	
}
