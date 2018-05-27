 using System.Collections.Generic;
 using System.Xml;
 using System.Xml.Serialization;
 using System.IO;

[XmlRoot("MovieData")]
public class MovieData {

 	[XmlArray("Frames"),XmlArrayItem("Frame")]
 	public List<FrameData> frames = new List<FrameData>();
	
	public MovieData() {}
}
