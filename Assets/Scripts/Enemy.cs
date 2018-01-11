using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject _StraightBullet = null;

	private void Start () {
		StartCoroutine ("GenerateBullets");
	}

	private IEnumerator GenerateBullets () {
		int _count = 0;
		for (int _radius = 0; _radius < 360; _radius += 10) {
			Instantiate (_StraightBullet, transform.position, Quaternion.Euler (0f, 0f, _radius));
		}
		yield return new WaitForSeconds (1f);
		_count++;
	}
}
