using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public GameObject bottomCube;
	public GameObject topCube;

	enum Directions {
		NONE,
		LEFT,
		RIGHT,
		UP,
		DOWN
	};

	private Directions inputDirection = Directions.NONE;

	// Use this for initialization
	void Start () {
		Debug.Log ("Init");
	}
	
	// Update is called once per frame
	void Update () {
		handleInput ();
	}

	void handleInput () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) && inputDirection == Directions.NONE) {
			bottomCube.transform.Translate (-1, 0, 0);
			topCube.transform.Translate (-1, 0, 0);
			inputDirection = Directions.LEFT;
		} else if (Input.GetKeyUp (KeyCode.LeftArrow) && inputDirection == Directions.LEFT) {
			bottomCube.transform.Translate (1, 0, 0);
			topCube.transform.Translate (1, 0, 0);
			inputDirection = Directions.NONE;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && inputDirection == Directions.NONE) {
			bottomCube.transform.Translate (1, 0, 0);
			topCube.transform.Translate (1, 0, 0);
			inputDirection = Directions.RIGHT;
		} else if (Input.GetKeyUp (KeyCode.RightArrow) && inputDirection == Directions.RIGHT) {
			bottomCube.transform.Translate (-1, 0, 0);
			topCube.transform.Translate (-1, 0, 0);
			inputDirection = Directions.NONE;
		}

		if (Input.GetKeyDown (KeyCode.UpArrow) && inputDirection == Directions.NONE) {
			bottomCube.SetActive (false);
			inputDirection = Directions.UP;
		} else if (Input.GetKeyUp (KeyCode.UpArrow) && inputDirection == Directions.UP) {
			bottomCube.SetActive (true);
			inputDirection = Directions.NONE;
		}

		if (Input.GetKeyDown (KeyCode.DownArrow) && inputDirection == Directions.NONE) {
			topCube.SetActive (false);
			inputDirection = Directions.DOWN;
		} else if (Input.GetKeyUp (KeyCode.DownArrow) && inputDirection == Directions.DOWN) {
			topCube.SetActive (true);
			inputDirection = Directions.NONE;
		}
	}

	void OnCollisionEnter (Collision collision) {
		Debug.Log ("collision detected");
		if (collision.collider.tag == "Obstacle") {
			Debug.Log ("We collided");
		}
	}
}
