using UnityEngine;

public class ObjectOrigin : MonoBehaviour {

	private void Update () {
		transform.position = Camera.main.transform.position;
	}
}
