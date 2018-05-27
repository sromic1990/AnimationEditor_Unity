using UnityEngine;
using System.Collections;

public class KeyExecutor : Executor {
	
	public KeyCode targetKey;
	
	void Update () {
		if( Input.GetKeyDown( targetKey ) ) {
			ExecuteActions();
		}
	}
}
