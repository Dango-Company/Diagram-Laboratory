using UnityEngine;

public class StageManager : MonoBehaviour {

    public static string _StateNow;
    private Collider2D _layer2Collider;
    private Collider2D _layer3Collider;
    private Collider2D _layer4Collider;
    private Collider2D _layer5Collider;
    private Collider2D _layer6Collider;

	private void Start () {
        _layer2Collider = GameObject.FindGameObjectWithTag ("LineToUp").GetComponent <Collider2D> ();
        _layer3Collider = GameObject.FindGameObjectWithTag ("LineToDown").GetComponent <Collider2D> ();
        _layer4Collider = GameObject.FindGameObjectWithTag ("LineToLeft").GetComponent <Collider2D> ();
        _layer5Collider = GameObject.FindGameObjectWithTag ("LineToStraight").GetComponent <Collider2D> ();
        _layer6Collider = GameObject.FindGameObjectWithTag ("LineToRight").GetComponent <Collider2D> ();
	}

	private void Update () {
        switch (_StateNow) {
            case "Bottom":
                Bottom ();
                break;
            case "Center":
                Center ();
                break;
            case "Top":
                Top ();
                break;
        }
        Debug.Log (_StateNow);
	}

    private void Bottom () {
        _layer2Collider.enabled = true;
        _layer3Collider.enabled = false;
        _layer4Collider.enabled = false;
        _layer5Collider.enabled = false;
        _layer6Collider.enabled = false;
    }

    private void Center () {
        _layer2Collider.enabled = true;
        _layer3Collider.enabled = true;
        _layer4Collider.enabled = false;
        _layer5Collider.enabled = false;
        _layer6Collider.enabled = false;
    }

    private void Top () {
        _layer2Collider.enabled = false;
        _layer3Collider.enabled = true;
        _layer4Collider.enabled = true;
        _layer5Collider.enabled = true;
        _layer6Collider.enabled = true;
    }
}
