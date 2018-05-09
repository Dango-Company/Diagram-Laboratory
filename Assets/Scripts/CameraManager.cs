using UnityEngine;

public class CameraManager : MonoBehaviour {

	public void GoToUp () {
		if (transform.position == new Vector3 (667f, 375f, 0f)) {
			transform.position = new Vector3 (667f, 1125f, 0f);
		}
	}

	public void GoToDown () {
		if (transform.position == new Vector3 (667f, 1125f, 0f)) {
			transform.position = new Vector3 (667f, 375f, 0f);
		}
	}
}
