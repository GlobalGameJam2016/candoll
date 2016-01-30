using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Actor {

    //private Animator animator;
    private int candleLife;
    private bool detected;
	private int hiddenRate = 1;
	private int detectedRate = 2;
	public Text candleText;
	public float speed;

	// Use this for initialization
	protected override void Start () {
        candleLife = 100000;
        detected = false;
        base.moveSpeed = 8;
        base.Start();

		candleText.text = "Candlelight: " + candleLife;
	}

    public int getCandleLife() 
	{
        return candleLife;
    }

    public void detect() 
	{
        detected = true;

    }

    public void hide()
    {
        detected = false;
    }

	// Decrements the candle life once every frame depending
	// on the hidden state
	private void TickCandle()
	{
		if (detected) {
			candleLife -= detectedRate;
		} else {
			candleLife -= hiddenRate;
		}
	}

	// Update is called once per frame
	void Update () {
		TickCandle ();
		candleText.text = "Candlelight: " + candleLife;
//        int horizontal = 0;
//        int vertical = 0;
//
//        horizontal = (int)(Input.GetAxisRaw("Horizontal"));
//        vertical = (int)(Input.GetAxisRaw("Vertical"));
//
//        if (horizontal != 0 || vertical != 0) {
//            base.Move(horizontal, vertical);
//        }
//
		if (Input.GetKey(KeyCode.D)) {
			transform.Translate (Vector2.right * speed);
		}
		if (Input.GetKey(KeyCode.A)) {
			transform.Translate (Vector2.left * speed);
		}
		if (Input.GetKey(KeyCode.W)) {
			transform.Translate (Vector2.up * speed);
		}
		if (Input.GetKey(KeyCode.S)) {
			transform.Translate (Vector2.down * speed);
		}
	}
}
