using UnityEngine;
using System.Collections;

public class LineSelectAnimation : BaseAnimation {

	public float scaleMult = 1.5f;
	public float time = 0.1f;
	
	private Vector3 _initScale;

	public override void StartAnimation() {
		_initScale = transform.localScale;
		
		/* Line is scaling only by X, and by Y it must be free. So ScaleTo - is not our choice */
		iTween.ValueTo ( gameObject, iTween.Hash( "time", time, "from", 1f, "to", scaleMult, "easetype", iTween.EaseType.linear, "looptype", iTween.LoopType.pingPong, "onupdate", "TweenUpd" ) );
	}

	private void TweenUpd( float tweenValue ) {
		transform.localScale = new Vector3( transform.localScale.x, _initScale.y * tweenValue, transform.localScale.z );
	}

	public override void StopAnimation() {
		iTween.Stop ( gameObject );
		transform.localScale = _initScale;
	}
}
