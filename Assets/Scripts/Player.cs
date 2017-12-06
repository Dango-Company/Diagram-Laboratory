using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField]
	private Joystick _joystick = null;

	private const float SPEED = 0.1f;
	private GameObject _damageEffect;

	private void Start () {
		_damageEffect = GameObject.Find ("DamageEffect");
	}

	private void Update () {
		Vector3 _position = transform.position;
		_position.x += _joystick.Position.x * SPEED;
		_position.y += _joystick.Position.y * SPEED;
		transform.position = _position;
	}

	private void OnTriggerEnter (Collider _collider) {
		if (_collider.gameObject.tag == "Bullet") {
			StartCoroutine ("DamageEffect");
		}
	}

	private IEnumerator DamageEffect () {
		//test
		Debug.Log ("a");
		_damageEffect.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		_damageEffect.SetActive (false);
	}
}
