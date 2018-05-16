using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private float _positionX = 0f, _positionY = 0f;
	private float _beforePositionX = 0f, _beforePositionY = 0f;
	public GameObject _DamageEffect = null;

	private void Update () {
		float _distance = 0f;
		float _distanceX = 0f, _distanceY = 0f;
		float _radian = 0f;
		float _playerDistanceX = 0f, _playerDistanceY = 0f;
		if (Input.touchCount > 0) {
			Touch _touch = Input.GetTouch (0);
			if (_touch.phase == TouchPhase.Began) {
				_beforePositionX = _touch.position.x;
				_beforePositionY = _touch.position.y;
			}
			_positionX = _touch.position.x;
			_positionY = _touch.position.y;
			_distance = Vector2.Distance (new Vector2 (_beforePositionX, _beforePositionY), new Vector2 (_positionX, _positionY));
			_distanceX = _positionX - _beforePositionX;
			_distanceY = _positionY - _beforePositionY;
			_radian = Mathf.Atan2 (_distanceY, _distanceX);
			_playerDistanceX = _distance * Mathf.Cos (_radian);
			_playerDistanceY = _distance * Mathf.Sin (_radian);
			transform.position += new Vector3 (_playerDistanceX, _playerDistanceY, 0f);
			_beforePositionX = _positionX;
			_beforePositionY = _positionY;
		}
	}

	private void OnTriggerEnter2D (Collider2D _collider2D) {
		if (_collider2D.tag == "Wall") {
			//JunJun
		}
		if (_collider2D.tag == "LineToUp") {
			Camera.main.GetComponent <CameraManager> ().GoToUp ();
		}
		if (_collider2D.tag == "LineToDown") {
			Camera.main.GetComponent <CameraManager> ().GoToDown ();
		}
		if (_collider2D.tag == "LineToLeft") {
			transform.position = new Vector3 (-1575f, 75f, 0f);
			Camera.main.GetComponent <CameraManager> ().GoToLeft ();
		}
		if (_collider2D.tag == "LineToStraight") {
			transform.position = new Vector3 (667f, 75f, 0f);
			Camera.main.GetComponent <CameraManager> ().GoToStraight ();
		}
		if (_collider2D.tag == "LineToRight") {
			transform.position = new Vector3 (2909f, 75f, 0f);
			Camera.main.GetComponent <CameraManager> ().GoToRight ();
		}
	}

	private IEnumerator Damage () {
		GameObject.FindGameObjectWithTag ("Canvas").GetComponent <UIManager> ().DamageCount ();
		_DamageEffect.SetActive (true);
		yield return new WaitForSeconds (0.1f);
		_DamageEffect.SetActive (false);
	}
}
