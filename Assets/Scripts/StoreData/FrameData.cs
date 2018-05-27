using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

public class FrameData {

 	[XmlArray("vertexes"),XmlArrayItem("VertexData")]
 	public List<VertexData> vertexes = new List<VertexData>();
	
 	[XmlArray("lines"),XmlArrayItem("LineData")]
 	public List<LineData> lines = new List<LineData>();
	
	public FrameData() {}
}
