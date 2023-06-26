using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

	protected Rigidbody2D rb;
	protected SpriteRenderer sr;
	protected Animator animator;
	protected Collider2D collider;
	
	protected virtual void Start() {
	    rb = gameObject.GetComponent<Rigidbody2D>();
	    collider = gameObject.GetComponent<Collider2D>();
	    
	    sr = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
	    animator = gameObject.transform.GetChild(0).GetComponent<Animator>();	    
	}
 
}
