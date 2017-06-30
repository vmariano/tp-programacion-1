using UnityEngine;
using System.Collections;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("p")){
			Time.timeScale = 0;
		}		
		
		if (Input.GetKeyDown("c")){
			Time.timeScale = 1;
		}
	}
}
