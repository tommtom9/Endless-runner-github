using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiHandeler : MonoBehaviour {

    Text text;
    float score = 0f;

    void Start() 
    {
        text = GetComponent<Text>();
    }
	// Update is called once per frame
	void Update () {
        score += 1;
        text.text = ("score: " + score);
	}
}
