using UnityEngine;

public class Bullet : MonoBehaviour {

	private float _speed = 0f;
	private Rigidbody2D _rigidbody2D = null;

	private void Start () {
		_speed = 3000f;
		_rigidbody2D = GetComponent <Rigidbody2D> ();
		_rigidbody2D.AddForce (transform.up * _speed);
	}

	private void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
