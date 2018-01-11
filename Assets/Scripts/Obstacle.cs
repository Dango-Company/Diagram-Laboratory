using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Rigidbody2D _rigidbody2D = null;
	private float _speedPerSecond = 0f;

	private void Start () {
		_rigidbody2D = GetComponent <Rigidbody2D> ();
		_speedPerSecond = 300000f * Time.deltaTime;
		if (transform.position.y > 0f) {
			_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (-_speedPerSecond, 0f)));
		} else if (transform.position.y == 0f) {
			if (transform.position.x > 0f) {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, 0f), Random.Range (-_speedPerSecond, _speedPerSecond)));
			} else if (transform.position.x == 0f) {
				//error
			} else {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (0f, _speedPerSecond), Random.Range (-_speedPerSecond, _speedPerSecond)));
			}
		} else {
			_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (0f, _speedPerSecond)));
		}
	}

	private void Update () {
		if (!GetComponent <Renderer> ().isVisible) {
			Destroy (gameObject);
		}
	}
}
