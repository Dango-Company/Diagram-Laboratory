using UnityEngine;

public class CameraManager : MonoBehaviour {

	private EnemyManager _enemyManager = null;

	private void Start () {
		_enemyManager = GameObject.Find ("EnemyManager").GetComponent <EnemyManager> ();
	}

	public void GoToUp () {
		if (transform.position.y < 750f) {
			transform.position += new Vector3 (0f, 750f, 0f);
			_enemyManager.GenerateEnemy ();
		}
	}

	public void GoToDown () {
		if (transform.position.y > 750f) {
			transform.position += new Vector3 (0f, -750f, 0f);
			_enemyManager.GenerateEnemy ();
		}
	}

	public void GoToLeft () {
		if (transform.position.y > 750f && transform.position.y < 1500f) {
			//Reset and level up
			transform.position = new Vector3 (-2133f, 375f, 0f);
			_enemyManager.GenerateEnemy ();
		}
	}

	public void GoToStraight () {
		if (transform.position.y > 750f && transform.position.y < 1500f) {
			//Reset and level up
			transform.position = new Vector3 (667f, 375f, 0f);
			_enemyManager.GenerateEnemy ();
		}
	}

	public void GoToRight () {
		if (transform.position.y > 750f && transform.position.y < 1500f) {
			//Reset and level up
			transform.position = new Vector3 (3467f, 375f, 0f);
			_enemyManager.GenerateEnemy ();
		}
	}
}
