using UnityEngine;
using System.Collections;

public class CreateMoveBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.cursor.state = CursorState.Create;
	}
	
}
