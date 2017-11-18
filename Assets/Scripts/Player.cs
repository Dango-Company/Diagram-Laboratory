using UnityEngine;

public class Player : MonoBehaviour {

	[SerializeField]
	private Joystick _joystick = null;

	private const float SPEED = 0.1f;

	private void Update () {
		//test
		Vector3 _position = transform.position;
		_position.x += _joystick.Position.x * SPEED;
		_position.y += _joystick.Position.y * SPEED;
		transform.position = _position;
	}
}
