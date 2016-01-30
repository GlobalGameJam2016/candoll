using UnityEngine;
using System.Collections;

public class Player : Actor {

    //private Animator animator;
    private int candleLife;

	// Use this for initialization
	void Start () {
        candleLife = 100;
        base.moveSpeed = 0.1f;
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        int horizontalDir = 0;
        int verticalDir = 0;

        horizontalDir = (int)(Input.GetAxisRaw("Horizontal"));
        verticalDir = (int)(Input.GetAxisRaw("Vertical"));


	}
}
