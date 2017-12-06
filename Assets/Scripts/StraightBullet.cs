using UnityEngine;

public class StraightBullet : MonoBehaviour {

	private float _speed;
	private Rigidbody2D _rigidbody;

	private void Start () {
		_speed = 20f;
		_rigidbody = GetComponent <Rigidbody2D> ();
		_rigidbody.AddForce (transform.up * _speed);
	}
}
