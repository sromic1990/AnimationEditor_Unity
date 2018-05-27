using System.Xml.Serialization;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Text;

public class EditorMovieData : MonoBehaviour {

	public MovieData data {get; private set; }

	void Start () {
		NewMovie();
	}
	
	public void NewMovie() {
		data = new MovieData();
		data.frames.Add( new FrameData() );
	}
	
	public void Save() {
		
		EditorController.messages.ShowMessage( "Try to save movie to: " + Settings.userMoviePath );
		
 		var serializer = new XmlSerializer(typeof(MovieData));

		
		
		var stream = new FileStream( Settings.userMoviePath, FileMode.Create );
		var streamWriter = new StreamWriter( stream, System.Text.Encoding.UTF8);
		serializer.Serialize( streamWriter, data );
		
		streamWriter.Close();
		stream.Close();

		EditorController.messages.ShowMessage( "The movie was saved to: " + Settings.userMoviePath );
	}
	
	public void LoadUserMovie() {
		
		EditorController.messages.ShowMessage( "Try to load movie from: " + Settings.userMoviePath );

		var serializer = new XmlSerializer(typeof(MovieData));
		
 		var stream = new FileStream( Settings.userMoviePath, FileMode.Open );
		var streamReader = new StreamReader( stream, System.Text.Encoding.UTF8);
		
		data = serializer.Deserialize( streamReader ) as MovieData;
		
		stream.Close();
		streamReader.Close();
		
		EditorController.messages.ShowMessage( "The movie was loaded from: " + Settings.userMoviePath );
	}
	
	public void LoadSampleMovie() {
		
		EditorController.messages.ShowMessage( "Try to load movie from: " + Settings.sampleMoviePath );
		
 		var serializer = new XmlSerializer(typeof(MovieData));
		
 		var stream = new FileStream( Settings.sampleMoviePath, FileMode.Open );
		var streamReader = new StreamReader( stream, System.Text.Encoding.UTF8);
		
		data = serializer.Deserialize(streamReader) as MovieData;
		
		stream.Close();
		streamReader.Close();
		
		EditorController.messages.ShowMessage( "The movie was loaded from: " + Settings.sampleMoviePath );
	}
	
	public void Trim() {
		
		/* Removing empty frames from the end of the movie */
		int lastIndexOfEmpty = data.frames.Count;
		for( int i = data.frames.Count - 1; i >= 0; i -- ) {
			if( data.frames[i].vertexes.Count > 0 ) {
				break;
			} else {
				lastIndexOfEmpty = i;
			}
		}
		
		if( lastIndexOfEmpty > 0 && lastIndexOfEmpty < data.frames.Count ) {
			int count = data.frames.Count - lastIndexOfEmpty;
			data.frames.RemoveRange( lastIndexOfEmpty, count );
		}
		
		if( EditorController.framesControl.currentFrameNum > data.frames.Count) {
			EditorController.framesControl.GoToFrame( data.frames.Count );
		}
	}
}
