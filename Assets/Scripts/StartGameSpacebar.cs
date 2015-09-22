using UnityEngine;
using System.Collections;

public class StartGameSpacebar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("hey");
            Application.LoadLevel("Game");
        }
	}
}
