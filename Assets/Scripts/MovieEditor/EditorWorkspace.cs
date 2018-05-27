using UnityEngine;
using System.Collections;

public class EditorWorkspace : MonoBehaviour {
	
	public Cursor cursor;
	
	private VertexSelection _selectedVertex;
	public VertexSelection selectedVertex { get { return _selectedVertex; } }
	
	private FrameData _clipboardFrame;
	
	private GameObject _virtualLine;
	
	void Start () {
		cursor.state = CursorState.Create;
	}
	
	public void CopyFrame() {
		_clipboardFrame = EditorController.movieData.data.frames[ EditorController.framesControl.currentFrameNum - 1 ];		
		EditorController.messages.ShowMessage("Copied");
	}
	
	public void PasteFrame() {
		
		if( _clipboardFrame != null ) {
			EditorController.movieData.data.frames[ EditorController.framesControl.currentFrameNum - 1 ] = _clipboardFrame;
			EditorController.framesControl.ParseCurrentFrame();
			EditorController.messages.ShowMessage("Pasted");
		}
	}
	
	public Vertex[] GetAllVertexes() {
		return FindObjectsOfType<Vertex>();
	}
	
	public Line[] GetAllLines() {
		return FindObjectsOfType<Line>();
	}
	
	public void SetSelectedVertex( VertexSelection vertex ) {
		
		if (_selectedVertex != null) _selectedVertex.GetComponent<VertexSelectAnimation>().StopAnimation ();
		_selectedVertex = vertex;
		
		if (_selectedVertex != null) {
			_selectedVertex.GetComponent<VertexSelectAnimation>().StartAnimation ();
			ShowVirtualLine();
		} else {
			HideVirtualLine();
		}
	}
	
	public void ShowVirtualLine() {

		if( _virtualLine != null ) {
			Destroy( _virtualLine.gameObject );
		}
		
		_virtualLine = Instantiate( Resources.Load("VirtualLine"), Vector3.zero, Quaternion.identity ) as GameObject;
	}
	
	public void HideVirtualLine() {
		if( _virtualLine != null ) {
			Destroy( _virtualLine.gameObject );
		}		
	}
	
	public bool ManualCreateLine( Vertex vertexA, Vertex vertexB ) {
		
		/*
		 * Check whether there is already such a line
		 * */
		Line[] lines = FindObjectsOfType<Line>();
		for( int i = 0; i < lines.Length; i ++ ) {
			if( lines[i].IsMe( vertexA, vertexB ) ) {
				return false;
			}
		}
		
		EditorController.creator.InstantiateLine( vertexA, vertexB );
		
		return true;
	}
	
	public void ManualCreateVertex( Vector3 position ) {
		
		Vertex newVertex = EditorController.creator.InstantiateVertex( position );

		if( _selectedVertex != null )
			EditorController.creator.InstantiateLine( newVertex, _selectedVertex.GetComponent<Vertex>() );
		
		SetSelectedVertex( newVertex.GetComponent<VertexSelection>() );
	}

	public void ResetActivity() {
		
		EditorController.moviePlayer.Stop();
		HideVirtualLine();
		SetSelectedVertex( null );
	}
}
