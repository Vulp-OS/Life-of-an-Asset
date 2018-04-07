using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour {

    public Text statusText;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnButtonEnter(Text buttonText)
    {
        statusText.text = "Hovering on " + buttonText.text;
    }
    public void OnButtonExit()
    {
        statusText.text = "";
    }
}
