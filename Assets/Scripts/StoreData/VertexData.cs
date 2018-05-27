using System.Xml;
using System.Xml.Serialization;
using UnityEngine;
using System.Collections;

public class VertexData {
	
 	public Vector3 position;
	
	public VertexData( Vector3 pos ) {
		position = pos;
	}
	
	public VertexData() {}
}

