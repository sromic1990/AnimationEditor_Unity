using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	private CursorState _state ;
	
	public Sprite createMoveCursorSprite;
	public Sprite deleteCursorSprite;
	
	void Start () {
		_state = CursorState.Create;
	}

	public CursorState state { 
		get { return _state; }
		set {
			EditorController.workspace.ResetActivity();
			EditorController.framesControl.SaveCurrentFrame();
			
			if( value == CursorState.Create ) {
				GetComponent<SpriteRenderer>().sprite = createMoveCursorSprite;
			}
			if( value == CursorState.Delete ) {
				GetComponent<SpriteRenderer>().sprite = deleteCursorSprite;
			}
			_state = value;			
		}
	}
	
	void Update() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint( Input.mousePosition );
		Vector3 newPosition = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
		
		transform.position = newPosition;
	}
}
