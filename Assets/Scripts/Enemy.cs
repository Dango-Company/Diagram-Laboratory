using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject _Bullet = null;
    public GameObject _FastBullet = null;
    private float GetAim () {
        Vector2 _origin = new Vector2 (1f, 0f);
        Vector2 _difference = transform.position - GameObject.Find("Player").transform.position;
        return Vector2.Angle (_difference, _origin);
    }

	private void Start () {
        InvokeRepeating ("ChooseBulletsType", 0f, 3f);
	}

    private void ChooseBulletsType () {
        int _bulletsType = Random.Range (0, 4);
        if (_bulletsType == 0) {
            GenerateBulletsAroundAtOnce ();
        }
        if (_bulletsType == 1) {
            StartCoroutine ("GenerateBulletsAroundStepByStep");
        }
        if (_bulletsType == 2) {
            StartCoroutine ("GenerateJailBullets");
        }
        if (_bulletsType == 3) {
            StartCoroutine ("GenerateBulletsInTheDirectionOfPlayer");
        }
    }

    //BulletsType:0
    private void GenerateBulletsAroundAtOnce () {
		for (int _radius = 0; _radius < 360; _radius += 10) {
			Instantiate (_Bullet, transform.position, Quaternion.Euler (0f, 0f, _radius));
		}
	}

    //BulletsType:1
    private IEnumerator GenerateBulletsAroundStepByStep () {
        for (int _radius = 0; _radius < 360; _radius += 5) {
            Instantiate (_Bullet, transform.position, Quaternion.Euler (0f, 0f, _radius));
            yield return new WaitForSeconds (0.05f);
        }
    }

    //BulletsType:2
    private IEnumerator GenerateJailBullets () {
        float _baseDirection = GetAim() + 90f;
        int _count = 0;
        while (true) {
            for (int _i_0 = 0; _i_0 < 50; _i_0++) {
                float _direction = _baseDirection + Mathf.Sin (_count * Mathf.Deg2Rad) * 30f;
                for (int _i_1 = -3; _i_1 < 3; _i_1++) {
                    Instantiate (_FastBullet, transform.position, Quaternion.Euler (0f, 0f, _direction + _i_1 * 30 + 15));
                }
                yield return new WaitForSeconds (0.05f);
                _count++;
            }
            break;
        }
    }

    //BulletsType:3
    private IEnumerator GenerateBulletsInTheDirectionOfPlayer () {
        while (true) {
            for (int _i_0 = 0; _i_0 < 5; _i_0++) {
                float _direction = GetAim () + 90f;
                for (int _i_1 = 0; _i_1 < 3; _i_1++) {
                    Instantiate (_FastBullet, transform.position, Quaternion.Euler (0f, 0f, _direction));
                    yield return new WaitForSeconds (0.1f);
                }
                yield return new WaitForSeconds (0.1f);
            }
            break;
        }
    }

	private void OnBecameInvisible () {
		Destroy (gameObject);
	}
}
