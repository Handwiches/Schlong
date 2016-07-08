using UnityEngine;
using System.Collections;
using System.Collections.Generic; //allows using lists
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class gameManager : MonoBehaviour {

    gameManagerEvents gmEvent;
    public List<int> scores = new List<int>(new int[2]); //characters preloaded into game
    public List<playerEvents> playerInfo = new List<playerEvents>(new playerEvents[2]);
    public int firstTo = 5;
    public bool gameEnded = false;

    public GameObject gameEndObject; //turns on at end of game
    public Text winningMessage;
    public string sceneToLoad = "Test";
    public float timeBeforeNewLoad = 2.0f;

    void Awake()
    {
        gmEvent = transform.GetComponent<gameManagerEvents>();
        gameEndObject.SetActive(false);
        scores.Add(0); //player1
        scores.Add(0); //player2
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if (scores[0] >= firstTo || scores[1] >= firstTo)
        {
            if (gameEnded == false)
            {
                EndGame();
                gameEnded = true;
                gmEvent.EndGame();
            }
        }
	}

    public void EndGame()
    {
        int winningPlayer = 0;
        int maxNumber = 0;
        for (int i = 0; i < scores.Count; i++)
        {
            if (scores[i] > maxNumber)
            {
                winningPlayer = i;  //Sorting the winning player by the highest number
                maxNumber = scores[i];
            }
        }


        
        gameEndObject.SetActive(true);
        winningMessage.text = "P" + (winningPlayer + 1) + " WINS!";
        StartCoroutine(CoEndGame());
    }
    public IEnumerator CoEndGame()
    {
        yield return new WaitForSeconds(timeBeforeNewLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
