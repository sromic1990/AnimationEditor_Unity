using UnityEngine;
using System.Collections;

public class xDMath {

	public static float AngleFromAToB( Vector2 a, Vector2 b ) {
		Vector2 diff = b - a;
		return Mathf.Atan2(diff.y, diff.x);		
	}
}
