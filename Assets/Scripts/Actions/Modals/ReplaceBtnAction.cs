using UnityEngine;
using System.Collections;

public class ReplaceBtnAction : GameAction {

	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.PasteFrame();
		
		/*
		 * Finding a root parent
		 * */
		Transform modalTransform = gameObject.transform;
		while( modalTransform.parent != null ) {
			modalTransform = modalTransform.parent;
		}
		
		Destroy( modalTransform.gameObject );			
	}
}
