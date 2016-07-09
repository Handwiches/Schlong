using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class loadSceneTimer : MonoBehaviour {

    public float timeToLoad = 3.25f;
    public string sceneToLoad = "Test";

	// Use this for initialization
	void Start () {
        StartCoroutine(LoadLevel());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator LoadLevel()
    {
        yield return new WaitForSeconds(timeToLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
