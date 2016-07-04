using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; //allows using lists

[RequireComponent(typeof(Text))]
public class scoreDisplay : MonoBehaviour {

    public gameManager gManager;
    public int player = 0;
    Text scoreDisplayer;

    

	// Use this for initialization
	void Start () {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
        scoreDisplayer = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        if (gManager.scores.Count >= player)
        {
            scoreDisplayer.text = "" + gManager.scores[player];
        }

    }
}
