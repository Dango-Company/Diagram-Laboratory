﻿using UnityEngine;

public class Obstacle : MonoBehaviour {

	private Rigidbody2D _rigidbody2D = null;
	private float _speedPerSecond = 0f;
	//test
	private Vector2 _a = Vector2.zero;

	private void Start () {
		_rigidbody2D = GetComponent <Rigidbody2D> ();
		_speedPerSecond = 300000f * Time.deltaTime;
		if (transform.position.y > 0f) {
			_a = new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (-_speedPerSecond, 0f));
			_rigidbody2D.AddForce (_a);
			//test
			Debug.Log ("a");
			Debug.Log (_a);
		}
		if (transform.position.y == 0f) {
			if (transform.position.x > 0f) {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, 0f), Random.Range (-_speedPerSecond, _speedPerSecond)));
				//test
				Debug.Log ("b");
			}
			if (transform.position.x == 0f) {
				//error
			}
			if (transform.position.x < 0f) {
				_rigidbody2D.AddForce (new Vector2 (Random.Range (0f, _speedPerSecond), Random.Range (-_speedPerSecond, _speedPerSecond)));
				//test
				Debug.Log ("c");
			}
		}
		if (transform.position.y < 0f) {
			_rigidbody2D.AddForce (new Vector2 (Random.Range (-_speedPerSecond, _speedPerSecond), Random.Range (0f, _speedPerSecond)));
			//test
			Debug.Log ("d");
		}
	}

	private void Update () {
		if (!GetComponent <Renderer> ().isVisible) {
			Destroy (gameObject);
		}
	}
}
