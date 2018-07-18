using UnityEngine;

public class FastBullet : MonoBehaviour {

    private float _speed = 0f;
    private Rigidbody2D _rigidbody2D = null;

    private void Start () {
        _speed = 15000f;
        _rigidbody2D = GetComponent <Rigidbody2D> ();
        _rigidbody2D.AddForce (transform.up * _speed);
    }

    private void OnTriggerEnter2D (Collider2D _collider2D) {
        if (_collider2D.tag == "Wall") {
            Destroy (gameObject);
        }
    }

    private void OnBecameInvisible () {
        Destroy (gameObject);
    }
}
