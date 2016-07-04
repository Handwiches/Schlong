using UnityEngine;
using System.Collections;
using System.Collections.Generic; //allows using lists

[RequireComponent(typeof(gameManager))]
public class gameManagerEvents : MonoBehaviour {


    gameManager gameMan;
    public List<int> scoreCheck = new List<int>(new int[0]); //checks score difference, must be same size as in gameManager

    public List<Material> backgrounds = new List<Material>(new Material[2]);
    public MeshRenderer bgImage;
    
    void Awake()
    {
        int randomBg = 0;
        randomBg = Random.Range(0, backgrounds.Count);
        //bgImage.sprite = backgrounds[randomBg]; 
        bgImage.material = backgrounds[randomBg];
    }

    // Use this for initialization
    void Start () {
        gameMan = transform.GetComponent<gameManager>();
        
	}
	
	// Update is called once per frame
	void Update () {
	    for (int i =0; i < scoreCheck.Count; i++)
        {
            if (scoreCheck[i] < gameMan.scores[i])
            {
                scoreCheck[i] = gameMan.scores[i];
                Goal(i);
            }
        }
	}

    public void Goal (int playerThatScored)
    {
        gameMan.playerInfo[playerThatScored].Goal();
    }
}
