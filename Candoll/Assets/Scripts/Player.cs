using UnityEngine;
using System.Collections;

public class Player : Actor {

    //private Animator animator;
    private int candleLife;
    private bool detected;

	// Use this for initialization
	protected override void Start () {
        candleLife = 100;
        detected = false;
        base.moveSpeed = 8;
        base.Start();
	}

    public int getCandleLife() {
        return candleLife;
    }

    public void detect() {
        detected = true;
    }

    public void hide()
    {
        detected = false;
    }

	// Update is called once per frame
	void Update () {
        candleLife--;
        int horizontal = 0;
        int vertical = 0;

        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
        vertical = (int)(Input.GetAxisRaw("Vertical"));

        if (horizontal != 0 || vertical != 0) {
            base.Move(horizontal, vertical);
        }

	}
}
