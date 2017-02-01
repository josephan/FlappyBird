using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {

	public float upForce = 200f;

	private bool isDead = false;
	private Rigidbody2D rb;
	private Animator anim;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isDead) {
			if (Input.GetMouseButton(0)) {
				rb.velocity = Vector2.zero;
				rb.AddForce(new Vector2(0, upForce));
				anim.SetTrigger("Flap");
			}
		}
	}

	void OnCollisionEnter2D() {
		rb.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger("Die");
		GameControl.instance.BirdDied();
	}
}
