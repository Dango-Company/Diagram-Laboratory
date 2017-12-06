using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class TouchEventHandler : SingletonMonoBehaviour <TouchEventHandler>,
IPointerDownHandler,
IPointerUpHandler,
IBeginDragHandler,
IEndDragHandler,
IDragHandler {

	private bool _isPressing = false;
	public bool IsPressing {
		get {
			return _isPressing;
		}
	}
	private bool _isDragging = false;
	public bool IsDragging {
		get {
			return _isDragging;
		}
	}
	private bool _isPinching = false;
	public bool IsPinching {
		get {
			return _isPinching;
		}
	}
	private Vector3 _beforeTapWorldPoint;
	private float _beforeDistanceOfPinch;
	public event Action <bool> onPress = delegate {};
	public event Action onBeginPress = delegate {};
	public event Action onEndPress = delegate {};
	public event Action <Vector2> onDrag = delegate {};
	public event Action <Vector3> onDragIn3D = delegate {};
	public event Action onBeginDrag = delegate {};
	public event Action onEndDrag = delegate {};
	public event Action <float> onPinch = delegate {};
	public event Action onBeginPinch = delegate {};
	public event Action onEndPinch = delegate {};
	private Dictionary <int, PointerEventData> _draggingDataDictionary = new Dictionary<int, PointerEventData> ();

	public void OnPointerDown (PointerEventData _eventData) {
		_isPressing = true;
		onBeginPress ();
		onPress (true);
	}

	public void OnPointerUp (PointerEventData _eventData) {
		_isPressing = false;
		onEndPress ();
		onPress (false);
		if (_isPinching && _draggingDataDictionary.Count < 2) {
			_isPinching = false;
			onEndPinch ();
		}
	}

	public void OnBeginDrag (PointerEventData _eventData) {
		if (!_isDragging) {
			_beforeTapWorldPoint = GetTapWorldPoint ();
		}
		_isDragging = true;
		onBeginDrag ();
		_draggingDataDictionary [_eventData.pointerId] = _eventData;
	}

	public void OnEndDrag (PointerEventData _eventData) {
		_isDragging = false;
		onEndDrag ();
		if (_draggingDataDictionary.ContainsKey (_eventData.pointerId)) {
			_draggingDataDictionary.Remove (_eventData.pointerId);
		}
	}

	public void OnDrag (PointerEventData _eventData) {
		if (!_isDragging) {
			OnBeginDrag (_eventData);
			return;
		}
		_draggingDataDictionary [_eventData.pointerId] = _eventData;
		if (_draggingDataDictionary.Count >= 2) {
			if (_isDragging) {
				_isDragging = false;
				onEndDrag ();
			}
			OnPinch ();
		} else if (Input.touches.Length <= 1) {
			if (_isPinching) {
				_isDragging = false;
				_isPinching = false;
				onEndPinch ();
				OnBeginDrag (_eventData);
			}
			onDrag (_eventData.delta);
			OnDragInWorldPoint ();
		}
	}

	public void OnDragInWorldPoint () {
		Vector3 _tapWorldPoint = GetTapWorldPoint ();
		onDragIn3D (_tapWorldPoint - _beforeTapWorldPoint);
		_beforeTapWorldPoint = _tapWorldPoint;
	}

	private Vector3 GetTapWorldPoint () {
		Vector2 _screenPosition = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (
			GetComponent <RectTransform> (),
			new Vector2 (Input.mousePosition.x, Input.mousePosition.y),
			null,
			out _screenPosition
		);
		Vector3 _tapWorldPoint = Camera.main.ScreenToWorldPoint (
			new Vector3 (_screenPosition.x, _screenPosition.y, -Camera.main.transform.position.z)
		);
		return _tapWorldPoint;
	}

	private void OnPinch () {
		Vector2 _firstTouch = Vector2.zero, _secondTouch = Vector2.zero;
		int _count = 0;
		foreach (var _draggingData in _draggingDataDictionary) {
			if (_count == 0) {
				_firstTouch = _draggingData.Value.position;
				_count = 1;
			} else if (_count == 1) {
				_secondTouch = _draggingData.Value.position;
				break;
			}
		}
		float _distanceOfPinch = Vector2.Distance (_firstTouch, _secondTouch);
		if (!_isPinching) {
			_isPinching = true;
			_beforeDistanceOfPinch = _distanceOfPinch;
			onBeginPinch ();
			return;
		}
		float _pinchDifference = _distanceOfPinch - _beforeDistanceOfPinch;
		onPinch (_pinchDifference);
		_beforeDistanceOfPinch = _distanceOfPinch;
		//test
		Debug.Log (_firstTouch + _secondTouch);
	}
}
