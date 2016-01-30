using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    public LayerMask blockingLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb2D;
    protected float moveSpeed;

	// Use this for initialization
	protected virtual void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        rb2D = GetComponent<Rigidbody2D>();
	}

    protected bool Move(int xDir, int yDir, out RaycastHit2D hit)
    {
        Vector2 start = transform.position;
        Vector2 end = start + new Vector2(xDir, yDir);
        boxCollider.enabled = false;
        hit = Physics2D.Linecast(start, end, blockingLayer);
        boxCollider.enabled = true;
        //if (hit.transform == null) add to this to handle movemend
        //succeeding/not succeeding
        Vector3 newPosition = Vector3.MoveTowards(rb2D.position, end, Time.deltaTime);
        rb2D.MovePosition(newPosition);
        return false;
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
}
