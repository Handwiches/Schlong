using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class pauseScript : MonoBehaviour {

    public Image controlsDisplay;
    public Color pauseImageOn;
    public Color pauseImageOff;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKey("c"))
        {
            //controlsDisplay.CrossFadeColor(pauseImageOn, 0.25f, true, true);
            controlsDisplay.color = pauseImageOn;
            Time.timeScale = 0.001f;
        }
        else
        {
            //controlsDisplay.CrossFadeColor(pauseImageOff, 0.05f, true, true);
            controlsDisplay.color = pauseImageOff;
            Time.timeScale = 1.0f;
        }
	}
}
