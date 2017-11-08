using UnityEngine;
using UnityEditor;

[CustomEditor (typeof (Joystick))]
public class JoystickEditor : Editor {

	private SerializedProperty _radiusProperty;
	private SerializedProperty _positionProperty;

	private void OnEnable () {
		_radiusProperty = serializedObject.FindProperty ("_radius");
		_positionProperty = serializedObject.FindProperty ("_position");
	}

	public override void OnInspectorGUI () {
		serializedObject.Update ();
		Joystick _joystick = target as Joystick;
		if (!_joystick.IsInitialized) {
			if (GUILayout.Button ("Init")) {
				_joystick.InitIfNeeded ();
			}
		} else {
			float _radius = EditorGUILayout.FloatField ("動作範囲の半径", _radiusProperty.floatValue);
			if (_radius != _radiusProperty.floatValue) {
				_radiusProperty.floatValue = _radius;
			}
			EditorGUILayout.BeginVertical (GUI.skin.box);
			EditorGUILayout.LabelField (
				"現在地 (-1~1) x: " +
				_positionProperty.vector2Value.x.ToString ("F2") + ", y: " +
				_positionProperty.vector2Value.y.ToString ("F2")
			);
			EditorGUILayout.EndVertical ();
		}
		serializedObject.ApplyModifiedProperties ();
	}
}
