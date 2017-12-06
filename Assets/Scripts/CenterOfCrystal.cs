using UnityEngine;

public class CenterOfCrystal : MonoBehaviour {

	private void FixedUpdate () {
		this.transform.Rotate (Vector3.forward * 3f);
	}
}
