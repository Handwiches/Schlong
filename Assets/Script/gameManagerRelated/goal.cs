using UnityEngine;
using System.Collections;

public class goal : MonoBehaviour {

    public int goalNumber = 0;
    public gameManager gManager;

    // Use this for initialization
    void Start () {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<gameManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            col.transform.SendMessage("resetPosition");
            Goal();
        }
    }

            void Goal()
    {
        gManager.scores[goalNumber] += 1;
    }
}
