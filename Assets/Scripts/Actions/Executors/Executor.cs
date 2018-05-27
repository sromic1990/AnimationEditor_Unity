using UnityEngine;
using System.Collections;

public class Executor : MonoBehaviour {

	public virtual void ExecuteActions()
	{
		GameAction [] actionsInComponent = gameObject.GetComponents<GameAction>();

		foreach( GameAction action in actionsInComponent) {
			action.ExecuteAction();
		}
	}
}
