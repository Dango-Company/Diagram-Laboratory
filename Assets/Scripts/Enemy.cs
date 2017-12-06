using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject _straightBullet;
	private bool _gameOver = false;

	private void Start () {
		StartCoroutine ("GenerateBullets");
	}

	private IEnumerator GenerateBullets () {
		int _count = 0;
		while (!_gameOver) {
			for (int _radius = 0; _radius < 360; _radius += 10) {
				Instantiate (_straightBullet, transform.position, Quaternion.Euler (0f, 0f, _radius));
			}
			yield return new WaitForSeconds (4f);
			_count++;
		}
	}
}
