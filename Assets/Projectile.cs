using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	private Vector2 shotDirection;
	private Vector2 initialPosition;
	private Vector2 finalPosition;

	public GameObject XMarker;
	private LineRenderer LineMarker;
	private bool activeMarker = false;
	// Use this for initialization

	void Start () {
		XMarker = Instantiate(XMarker, new Vector2(-100, -100), Quaternion.identity);
		XMarker.AddComponent<LineRenderer>();
		LineMarker = XMarker.GetComponent<LineRenderer>();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) 
		{
			InitialClick();
		}
		if(Input.GetMouseButton(0)) 
		{
			LineMarker.SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
		if(Input.GetMouseButtonUp(0))
		{
			FinalClick();
		}
		Debug.DrawRay(gameObject.transform.position, shotDirection, Color.red);
		
	}

	void InitialClick()
	{
		initialPosition = Input.mousePosition;
		XMarker.SetActive(true);
		activeMarker = true;

		XMarker.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		LineMarker.SetPosition(0, XMarker.transform.position);
	}
	void FinalClick()
	{
		finalPosition = (Vector2)Input.mousePosition;
		shotDirection = finalPosition - initialPosition;
		shotDirection.Scale(new Vector2(0.1f, 0.1f));
		gameObject.GetComponent<Rigidbody2D>().AddForce(shotDirection, ForceMode2D.Impulse);
	}
}
