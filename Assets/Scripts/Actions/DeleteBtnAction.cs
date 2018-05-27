using UnityEngine;
using System.Collections;

public class DeleteBtnAction : GameAction {
	
	public override void ExecuteAction () {
		base.ExecuteAction ();
		EditorController.workspace.cursor.state = CursorState.Delete;
	}
}
