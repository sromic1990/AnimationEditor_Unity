using UnityEngine;
using System.Collections;

public class EditorMessages : MonoBehaviour {

	public TextMesh labelTF;
	
	public void ShowMessage( string messageText ) {
		labelTF.text = messageText;
	}
}
