using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject _Enemy = null;

	private void Start () {
		GenerateEnemy ();
	}

	public void GenerateEnemy () {
		Instantiate (_Enemy, Camera.main.transform.position + new Vector3 (0f, 375f, 0f), Quaternion.identity);
	}
}
