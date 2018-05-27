using System;
using UnityEngine;
using System.Collections;

[ RequireComponent( typeof( DeletableItem ) ) ]
public class LineDeletingWithVertex : MonoBehaviour {

	private Line _line;
	
	void Awake() {
		_line = GetComponent<Line>();
	}
	
	void Start () {
		if( _line.vertexA == null || _line.vertexB == null ) Debug.LogError("Line must be instant initialized");
		
		_line.GetComponent<DeletableItem>().deleteEvent += DeleteLineHandler;
		
		_line.vertexA.GetComponent<DeletableItem>().deleteEvent += DeleteVertexHandler;
		_line.vertexB.GetComponent<DeletableItem>().deleteEvent += DeleteVertexHandler;
		
		_line.vertexA.GetComponent<DeletableItem>().deleteAnimStartEvent += DeleteAnimStartHandler;
		_line.vertexB.GetComponent<DeletableItem>().deleteAnimStartEvent += DeleteAnimStartHandler;
		
		_line.vertexB.GetComponent<DeletableItem>().deleteAnimStopEvent += DeleteAnimStopHandler;
		_line.vertexA.GetComponent<DeletableItem>().deleteAnimStopEvent += DeleteAnimStopHandler;
	}
	
	void DeleteAnimStartHandler( object s, EventArgs e ) {
		GetComponent<BaseAnimation>().StartAnimation();
	}
	
	void DeleteAnimStopHandler( object s, EventArgs e ) {
		GetComponent<BaseAnimation>().StopAnimation();
	}	
	
	void DeleteVertexHandler( object s, EventArgs e ) {
		GetComponent<DeletableItem>().DestroyItem();
	}
	
	void DeleteLineHandler( object s, EventArgs e ) {
		
		_line.GetComponent<DeletableItem>().deleteEvent -= DeleteLineHandler;
		
		_line.vertexA.GetComponent<DeletableItem>().deleteEvent -= DeleteVertexHandler;
		_line.vertexB.GetComponent<DeletableItem>().deleteEvent -= DeleteVertexHandler;
		
		_line.vertexA.GetComponent<DeletableItem>().deleteAnimStartEvent -= DeleteAnimStartHandler;
		_line.vertexB.GetComponent<DeletableItem>().deleteAnimStartEvent -= DeleteAnimStartHandler;
		
		_line.vertexA.GetComponent<DeletableItem>().deleteAnimStopEvent -= DeleteAnimStopHandler;
		_line.vertexB.GetComponent<DeletableItem>().deleteAnimStopEvent -= DeleteAnimStopHandler;
		
	}
}
