using UnityEngine;
using System.Collections;

public class VertexSelectAnimation : BaseAnimation {

	public float scaleMult = 1.5f;
	
	public float time = 0.1f;
	
	private Vector3 _initScale;


	public override void StartAnimation() {
		_initScale = transform.localScale;
		iTween.ScaleTo( gameObject, iTween.Hash( "time", time, "x", scaleMult, "y", scaleMult, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong ) );
	}

	public override void StopAnimation() {
		iTween.Stop ( gameObject );
		transform.localScale = _initScale;
	}
}
