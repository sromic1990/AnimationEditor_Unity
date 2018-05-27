using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EditorFramesControl : MonoBehaviour {
	
	public EventHandler frameChangedEvent;
	
	private int _currentFrameNum;
	public int currentFrameNum { get{ return _currentFrameNum; } }
	
	void Start () {
		_currentFrameNum = 1;
	}
	
	public void ParseCurrentFrame() {
		ParseFrame( _currentFrameNum );
	}
	
	public void ParseFrame( int frameNum ) {
		int frameId = frameNum - 1;
		FrameData currFrame = EditorController.movieData.data.frames[ frameId ];
		
		ParseFrame( currFrame );
	}
	
	public void CleanFrame() {
		DeletableItem[] items = FindObjectsOfType<DeletableItem>();
		for( int i = 0; i < items.Length; i ++ ) {
			Destroy( items[i].gameObject );
		}		 
	}
	
	public void ParseFrame ( FrameData frameData ) {
		
		CleanFrame();
		
		/* 
		 * Creating all vertexes 
		 * */
		List<Vertex> vertexes = new List<Vertex>();
		for( int i = 0; i < frameData.vertexes.Count; i ++ ) {
			Vertex newVertex = EditorController.creator.InstantiateVertex( frameData.vertexes[i].position );
			vertexes.Add( newVertex );
		}

		/* 
		 * Creating lines by vertexes
		 * */
		for( int i = 0; i < frameData.lines.Count; i ++ ) {
			int vertexAId = frameData.lines[i].vertexAId;
			int vertexBId = frameData.lines[i].vertexBId;
			EditorController.creator.InstantiateLine( vertexes[ vertexAId ], vertexes[ vertexBId ] );
		}	
	}
	
	public void SaveCurrentFrame() {
		
		/**/
		Vertex[] vertexes = FindObjectsOfType<Vertex>();
		List<VertexData> vertexDatas = new List<VertexData>(); 
		for( int i = 0; i < vertexes.Length; i ++ ) {
			vertexDatas.Add( new VertexData( vertexes[i].position ) );
		}
		
		/**/
		Line[] lines = FindObjectsOfType<Line>();
		List<LineData> lineDatas = new List<LineData>(); 
		for( int i = 0; i < lines.Length; i ++ ) {
			int vertexAId = Array.IndexOf( vertexes, lines[i].vertexA );
			int vertexBId = Array.IndexOf( vertexes, lines[i].vertexB );

			lineDatas.Add( new LineData( vertexAId, vertexBId ) );
		}
		
		/**/
		FrameData newFrame = new FrameData();
		newFrame.vertexes = vertexDatas;
		newFrame.lines = lineDatas;
		
		EditorController.movieData.data.frames[ _currentFrameNum - 1 ] = newFrame;
	}
	
	public void GoToFrame( int frameNum ) {

		if( frameNum < 1 ) return;
		
		/* fill empty frames */
		if( frameNum > EditorController.movieData.data.frames.Count ) {
			while( frameNum > EditorController.movieData.data.frames.Count ) {
				EditorController.movieData.data.frames.Add( new FrameData() );
			}
		}
		
		_currentFrameNum = frameNum;
		
		ParseCurrentFrame();
		
		if( frameChangedEvent != null ) { frameChangedEvent( this, EventArgs.Empty ); }
	}	
}
