using UnityEngine;
using System.Collections;

public class CancelBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		
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
