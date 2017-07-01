using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

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

		if (Input.GetKeyDown("r")){
			SceneManager.LoadScene("MainMenu");
		}
	}
}
