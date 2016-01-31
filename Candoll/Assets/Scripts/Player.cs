using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Actor {

    //private Animator animator;
    private int candleLife;
    private bool detected;
	public int hiddenRate;
	public int detectedRate;
	public Text candleText;
	public float speed;
	public int dogDamage;
	public bool hasShoe;
	public AudioClip collisionSound;
	public GameManager gameManager;
	// Dirty little hack...
	public GameObject gameOverImage;
	public Text gameOverText;
	public GameObject advanceLevelImage;
	public Text advanceLevelText;
	//public Text continueText;
	private string enter = "Press Enter to Continue.";


	// Use this for initialization
	protected override void Start () {
        candleLife = 100000;
        detected = false;
        base.moveSpeed = 8;
        base.Start();

		candleText.text = "Candlelight: " + candleLife;

		// Hack pt 2
		gameOverImage = GameObject.Find ("GameOverImage");
		gameOverText = GameObject.Find ("GameOverText").GetComponent<Text> ();
		gameOverImage.SetActive (false);

		advanceLevelImage = GameObject.Find ("CompleteImage");
		advanceLevelText = GameObject.Find ("CompletionText").GetComponent<Text>();

		advanceLevelImage.SetActive (false);
		//continueText = GameObject.Find ("PressEnter").GetComponent<Text>();


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

	private void GetDamage()
	{
		candleLife -= dogDamage;
	}

	private void Death(){
		gameOverText.text = "Game Over!";
		gameOverImage.SetActive (true);
	}
	 /*
	void OnCollisionEnter2D (Collision2D obj)
	{

		//SoundManager.instance.PlaySingle (collisionSound);
		switch (obj.gameObject.tag) {
		case "Enemy":
			Debug.Log ("Touched le dog");
			GetDamage ();
			break;

		case "Candle":
			Invoke("DisplayCutscene", 0.5f);
			break;

		case "Shoes":
			Debug.Log ("Collided");
			hasShoe = true;
			Destroy (GameObject.Find ("Shoes"));
			speed = (int)(speed * 1.5);

			break;


		}
	}
	*/

	private void DisplayCutscene(){
		advanceLevelImage.SetActive (true);
		advanceLevelText.text = "Goal Complete.";
		Invoke ("PressEnter", 0.5f);


	}

	private void PressEnter(){
		//continueText.text = enter;
		Invoke ("HideImages", 0.1f);
		Invoke ("ClearText", 0.1f);
		
	}

	private void ClearText(){
		gameOverText.text = "";
		advanceLevelText.text = "";
		//continue.text = "";
	}

	private void hideImages(){
		advanceLevelImage.SetActive (false);
		gameOverImage.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		if (gameManager.game == true) {
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
			if (candleLife <= 0)
				Death ();
			if (Input.GetKey (KeyCode.D)) {
				transform.Translate (Vector2.right * speed);
			}
			if (Input.GetKey (KeyCode.A)) {
				transform.Translate (Vector2.left * speed);
			}
			if (Input.GetKey (KeyCode.W)) {
				transform.Translate (Vector2.up * speed);
			}
			if (Input.GetKey (KeyCode.S)) {
				transform.Translate (Vector2.down * speed);
			}
		}
	}
}
