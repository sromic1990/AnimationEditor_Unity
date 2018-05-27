using UnityEngine;
using System.Collections;

public class SpaceBarExecutor : Executor {
	 
	void Update () {
		if( Input.GetKeyDown( KeyCode.Space ) ) {
			ExecuteActions();
		}
	}


}
