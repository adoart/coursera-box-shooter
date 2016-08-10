using UnityEngine;
using System.Collections;

public class BasicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Horizontal Input = " + Input.GetAxis ("Horizontal"));
	
	}
}
