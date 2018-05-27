using UnityEngine;
using System.Collections;

/// <summary>
/// The game Action superclass that defines a virtual ExecuteAction that you should override in the 
/// childs for this class. 
/// </summary>
public class GameAction : MonoBehaviour {

	public virtual void ExecuteAction ()
	{		
	}
}