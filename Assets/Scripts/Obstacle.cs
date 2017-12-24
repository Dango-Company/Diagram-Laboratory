using UnityEngine;

public class Obstacle : MonoBehaviour {

	public GameObject _obstacle;
	private GameObject[] _obstaclePoint;

	private void Start () {
		_obstaclePoint = GameObject.FindGameObjectsWithTag ("ObstaclePoint");
		InvokeRepeating ("GenerateObstacle", 10f);
	}

	private void GenerateObstacle () {
		Instantiate (_obstacle, _obstaclePoint (Random.Range (0, 6)).position, _obstaclePoint (Random.Range (0, 6)).rotation);
	}
}
