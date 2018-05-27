using UnityEngine;
using System.Collections;

public class EditorMoviePlayer : MonoBehaviour {

	public bool isPlay { get; private set; }
	
	private float _frameInitTime = 1f / 10f;
	private float _frameTime;
	
	void Start () {
		isPlay = false;
	}
	
	void Update () {
		
		if( isPlay ) {
			
			_frameTime -= Time.deltaTime;
			
			if( _frameTime < 0 ) {
				
				NextFrame();
				_frameTime = _frameInitTime;
			}
		}
	}
	
	public void Play() {
		if( EditorController.movieData.data.frames.Count > 1 ) {
			isPlay = true;
			
			EditorController.messages.ShowMessage("The movie is playing with 10 FPS");
			
			_frameTime = _frameInitTime;
		}
	}
	
	public void Stop() {
		isPlay = false;
	}
	
	private void NextFrame() {
		int nextFrameNum = EditorController.framesControl.currentFrameNum + 1;
		/* Looping */
		if( nextFrameNum > EditorController.movieData.data.frames.Count ) { nextFrameNum = 1; }
		
		EditorController.framesControl.GoToFrame( nextFrameNum );
	}
}
