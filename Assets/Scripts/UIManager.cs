using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Text _DamageCount = null;
	private int _damageCount = 0;

	public void DamageCount () {
		_damageCount++;
		_DamageCount.text = "Damage Count " + _damageCount;
	}
}
