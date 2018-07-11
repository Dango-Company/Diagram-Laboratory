using UnityEngine;

public class ObstacleManager : MonoBehaviour {

	public GameObject _Obstacle = null;
	private GameObject[] _obstaclePoints = null;

	private void Start () {
		_obstaclePoints = GameObject.FindGameObjectsWithTag ("ObstaclePoint");
		InvokeRepeating ("GenerateObstacle", 10f, 10f);
	}

	private void GenerateObstacle () {
		GameObject _chosenObstaclePoint = _obstaclePoints [Random.Range (0, 6)];
		Instantiate (_Obstacle, _chosenObstaclePoint.transform.position, _chosenObstaclePoint.transform.rotation);
	}
}
