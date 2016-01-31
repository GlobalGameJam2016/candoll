using UnityEngine;
using System.Collections;

public class CandleScript : MonoBehaviour {

	public Player script;
	public GameManager gameManager;
	private bool alreadySped = false;
	void OnTriggerEnter2D(Collider2D obj){
		if (!alreadySped && obj.gameObject.tag == "Player" && script.hasShoe) {
			alreadySped = true;
			script.speed = script.speed * 2;
			gameManager.game = false;
			gameManager.level++;
		}
	}
}
