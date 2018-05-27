using System;
using UnityEngine;
using System.Collections;

public class Line : MonoBehaviour {
	
	/* If line is already on Workspace */
	public Vertex debugVertexA;
	public Vertex debugVertexB;

	public Vertex vertexA { get; private set; }
	public Vertex vertexB { get; private set; }
	
	void Awake() {
		
		if( debugVertexA != null && debugVertexB != null ) {
			Initialize( debugVertexA, debugVertexB );
		}
	}
	
	public void Initialize( Vertex vertA, Vertex vertB ) {
		vertexA = vertA;
		vertexB = vertB;
		
		CalculateLine ();
	}

	void Start () {
	}
	
	public bool IsMe( Vertex otherVertexA, Vertex otherVertexB ) {
		if( vertexA == otherVertexA && vertexB == otherVertexB ) return true;
		if( vertexA == otherVertexB && vertexB == otherVertexA ) return true;
		return false;
	}
	
	void Update () {
		CalculateLine ();
	}
	
	void CalculateLine() {
		
		if( vertexA == null || vertexB == null ) return;
		
		Vector3 centerPos = ( vertexA.transform.position + vertexB.transform.position ) / 2f;
		Vector3 diff = vertexB.transform.position - vertexA.transform.position;
		
		float distance = diff.magnitude;
		float angle = xDMath.AngleFromAToB( vertexB.transform.position, vertexA.transform.position ) * Mathf.Rad2Deg;
		
		transform.position = centerPos;
		transform.localScale = new Vector3 ( distance, transform.localScale.y, transform.localScale.z );
		transform.rotation = Quaternion.Euler ( new Vector3( 0f, 0f, angle) );
	}	
}
