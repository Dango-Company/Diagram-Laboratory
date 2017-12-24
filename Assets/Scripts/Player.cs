using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Joystick _joystick = null;

	public GameObject _damageEffect;
	private const float SPEED = 0.1f;

	private void Update () {
		Vector3 _position = transform.position;
		_position.x += _joystick.Position.x * SPEED;
		_position.y += _joystick.Position.y * SPEED;
		transform.position = _position;
	}

	private void OnTriggerEnter2D (Collider2D _collider) {
		if (_collider.gameObject.tag == "Bullet") {
			StartCoroutine ("DamageEffect");
		}
	}

	private IEnumerator DamageEffect () {
		_damageEffect.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		_damageEffect.SetActive (false);
	}
}
