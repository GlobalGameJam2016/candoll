using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Time to wait to start a level (display black screen)
	public float levelStartDelay = 1f;
    public static GameManager instance = null;
    public int level = 1;
	public bool game = false;

	// Display level
	private Text levelText;
	// Use this to show or hide level loading screen
	private GameObject levelImage;

	// Prevent player from moving during setup
	private bool doingSetup;

	private GameManager(){
	}

	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			// Game is over
			Destroy (gameObject);
		// Background music keeps playing in between levels
		DontDestroyOnLoad (gameObject);

		InitGame ();

	}

	private void HideLevelImage()
	{
		levelImage.SetActive (false);
		levelText.text = "";
		doingSetup = false;
	}

	public void GameOver()
	{
		Debug.Log ("GAME OVER");

		enabled = false;
	}

	private void OnLevelWasLoaded (int index)
	{
		level++;
		InitGame ();
	}

    public void InitGame()
	{
		
		doingSetup = true;
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text> ();
		levelText.text = "Night " + level;
		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		game = true;
	}

	// Update is called once per frame
	void Update () 
	{
		if (doingSetup)
			return;
		if (Input.GetKey (KeyCode.Return)) {
			InitGame ();
		}
	
	}
}
