using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

    private int IsHit = 0;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public Transform startMarker;
    public Transform endMarker;
    public float speed = 1.0F;
    private float startTime;
    private float journeyLength;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (IsHit < 1)
        {
            if (other.gameObject.tag == "Player")
            {
                float x = transform.position.x;
                float y = transform.position.y;
                transform.Translate(-1, -4, 0);
                IsHit += 1;
            }
        }
    }
    
        
    
}
