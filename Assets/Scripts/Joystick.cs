using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour {

	[SerializeField] [Header ("実際に動くスティック部分 (自動設定)")]
	private GameObject _stick = null;
	private const string STICK_NAME = "Stick";

	[SerializeField] [Header ("スティックが動く範囲の半径")]
	private float _radius = 100f;

	[SerializeField] [Header ("現在地 (自動更新)")]
	private Vector2 _position = Vector2.zero;

	public Vector2 Position {
		get {
			return _position;
		}
	}
	private Vector3 _stickPosition {
		set {
			_stick.transform.localPosition = value;
			_position = new Vector2 (
				_stick.transform.localPosition.x / _radius,
				_stick.transform.localPosition.y / _radius
			);
		}
	}

	public bool IsInitialized {
		get {
			if (_stick != null) {
				return true;
			}
			if (transform.Find (STICK_NAME) != null) {
				_stick = transform.Find (STICK_NAME).gameObject;
				return true;
			}
			return false;
		}
	}

	private void Awake () {
		InitIfNeeded ();
		_stick.GetComponent <Image> ().raycastTarget = false;
		transform.localScale = Vector3.zero;
		TouchEventHandler.Instance.onBeginPress += OnBeginPress;
		TouchEventHandler.Instance.onEndPress += OnEndPress;
		TouchEventHandler.Instance.onEndDrag += OnEndDrag;
		TouchEventHandler.Instance.onDrag += OnDrag;
	}

	public void InitIfNeeded () {
		if (IsInitialized) {
			return;
		}
		_stick = new GameObject (STICK_NAME);
		_stick.transform.SetParent (gameObject.transform);
		_stick.transform.localRotation = Quaternion.identity;
		_stickPosition = Vector3.zero;
		_stick.AddComponent <Image> ();
	}

	private Vector3 GetTouchPointInWorld () {
		Vector2 _screenPosition = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (
			GetComponent <RectTransform> (),
			new Vector2 (Input.mousePosition.x, Input.mousePosition.y),
			null,
			out _screenPosition
		);
		return _screenPosition;
	}

	public void OnBeginPress () {
		transform.localScale = Vector3.one;
		transform.localPosition = Vector3.zero;
		transform.localPosition = GetTouchPointInWorld ();
		_stickPosition = Vector3.zero;
	}

	public void OnEndPress () {
		OnEndDrag ();
	}

	public void OnEndDrag () {
		_stickPosition = Vector3.zero;
		transform.localScale = Vector3.zero;
	}

	public void OnDrag (Vector2 _delta) {
		_stickPosition = GetTouchPointInWorld ();
		float _currentRadius = Vector3.Distance (Vector3.zero, _stick.transform.localPosition);
		if (_currentRadius > _radius) {
			float _radian = Mathf.Atan2 (_stick.transform.localPosition.y, _stick.transform.localPosition.x);
			Vector3 _limitedPosition = Vector3.zero;
			_limitedPosition.x = _radius * Mathf.Cos (_radian);
			_limitedPosition.y = _radius * Mathf.Sin (_radian);
			_stickPosition = _limitedPosition;
		}
	}

	#if UNITY_EDITOR
	private void OnDrawGizmos () {
		UnityEditor.Handles.color = Color.green;
		UnityEditor.Handles.DrawWireDisc (transform.position, transform.forward, _radius * 0.5f);
	}
	#endif
}
