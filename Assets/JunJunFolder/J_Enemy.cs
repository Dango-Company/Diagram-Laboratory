using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class J_Enemy : MonoBehaviour {

    public GameObject bulletSprite;

	// Use this for initialization
	void Start () {
        StartCoroutine("_Update1");
	}
	
    IEnumerator _Update1()
    {
        //float baseDir = GetAim();
        int count = 0;
        while (true)
        {
            // 8秒毎に、間隔６度、速度１で敵キャラを中心として全方位弾発射。
            for (int rad = 0; rad < 360; rad += 6)
            {
                Instantiate(bulletSprite,new Vector3(transform.position.x,transform.position.y,0),Quaternion.Euler(0,0,rad));
            }
            yield return new WaitForSeconds(4.0f);
            count++;
        }
    }
}
