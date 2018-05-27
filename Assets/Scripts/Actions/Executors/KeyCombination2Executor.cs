using UnityEngine;
using System.Collections;

public class KeyCombination2Executor : Executor {
	
	public KeyCode targetKey1;
	public KeyCode targetKey2;
	
	bool isPressed = false;
	
	void Update () {
		if( Input.GetKey( targetKey1 ) && Input.GetKey( targetKey2 ) ) {
			if( isPressed == false ) {
				HandleCombination();
				isPressed = true;
			}
		} else {
			isPressed = false;
		}
	}
	
	void HandleCombination() {
		ExecuteActions();
	}
}
