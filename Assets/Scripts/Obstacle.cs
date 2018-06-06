using UnityEngine;

public class Obstacle : MonoBehaviour {

	private GameObject _obstacleOrigin = null;
	private Rigidbody2D _rigidbody2D = null;
	private float _speedPerSecond = 0f;

	private void Start () {
		_obstacleOrigin = GameObject.Find ("ObstacleOrigin");
		transform.parent = _obstacleOrigin.transform;
		_rigidbody2D = GetComponent <Rigidbody2D> ();
		_speedPerSecond = 300000f * Time.deltaTime;
		if (transform.localPosition.y > 0f) {
			_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (-_speedPerSecond, 0f)));
		}
		if (transform.localPosition.y == 0f) {
			if (transform.localPosition.x > 0f) {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, 0f), Random.Range (-_speedPerSecond, _speedPerSecond)));
			}
			if (transform.localPosition.x < 0f) {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (0f, _speedPerSecond), Random.Range (-_speedPerSecond, _speedPerSecond)));
			}
		}
		if (transform.localPosition.y < 0f) {
			_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (0f, _speedPerSecond)));
		}
	}

	private void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
