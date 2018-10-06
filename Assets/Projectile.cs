using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private Vector2 shotDirection;
	private Vector2 initialPosition;
	private Vector2 finalPosition;
	// Use this for initialization

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) 
		{
			InitialClick();
		}
		if(Input.GetMouseButtonUp(0))
		{
			FinalClick();
		}
		Debug.DrawRay(gameObject.transform.position, shotDirection, Color.red);
		
	}

	void InitialClick()
	{
		initialPosition = (Vector2)Input.mousePosition;
	}
	void FinalClick()
	{
		finalPosition = (Vector2)Input.mousePosition;
		shotDirection = finalPosition - initialPosition;
		shotDirection.Scale(new Vector2(0.1f, 0.1f));
		gameObject.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
	}
}
