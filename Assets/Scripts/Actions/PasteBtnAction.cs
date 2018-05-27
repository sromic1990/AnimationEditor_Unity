using UnityEngine;
using System.Collections;

public class PasteBtnAction : GameAction {

	public override void ExecuteAction () {
		base.ExecuteAction ();
		
		EditorController.workspace.ResetActivity();
		
		/*
		 * Lazy Instantiating. 
		 * Good practice for this would be to create EditorModals and handle multiple modal windows with it.
		 * But a sense of this test is lying in other things.
		 * */
		if( EditorController.workspace.GetAllVertexes().Length > 0 ) {
			Instantiate( Resources.Load("ConfirmPasteModal") );
		} else {
			EditorController.workspace.PasteFrame();
		}
	}
}
