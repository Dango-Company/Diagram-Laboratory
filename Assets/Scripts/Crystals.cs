using UnityEngine;

public class Crystals : MonoBehaviour {

	private void FixedUpdate () {
		transform.Rotate (Vector3.forward * 3f);
	}
}
