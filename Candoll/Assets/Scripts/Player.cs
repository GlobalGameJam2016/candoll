using UnityEngine;
using System.Collections;

public class Player : Actor {

    //private Animator animator;
    private int candleLife;

	// Use this for initialization
	void Start () {
        candleLife = 100;
        base.moveSpeed = 5;
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0 || vertical != 0) {
            base.Move(horizontal, vertical);
        }

	}
}
