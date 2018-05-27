using System.Xml;
using System.Xml.Serialization;

public class LineData {
	
	public int vertexAId;
	public int vertexBId;
	
	public LineData( int verAId, int verBId) {
		vertexAId = verAId;
		vertexBId = verBId;
	}
	
	public LineData() {}
}
