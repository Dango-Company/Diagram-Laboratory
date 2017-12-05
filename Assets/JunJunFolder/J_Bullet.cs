using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class J_Bullet : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;

    // Use this for initialization
	void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();

        //一定の速度で弾幕を移動させたいならStart文
        rb.AddForce(transform.up * speed);

	}
    private void Update()
    {
        //徐々に弾幕の速度を上げたいならUpdate文
        //rb.AddForce(transform.up * speed);
    }

}
