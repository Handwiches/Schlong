using UnityEngine;
using System.Collections;
using System.Collections.Generic; //allows using lists

[RequireComponent(typeof(gameManager))]
public class gameManagerEvents : MonoBehaviour
{

    //event scripts are audio/visual feedback scripts of their regular counterparts

    gameManager gameMan;
    public List<int> scoreCheck = new List<int>(new int[0]); //checks score difference, must be same size as in gameManager

    public List<Material> backgrounds = new List<Material>(new Material[2]);
    public MeshRenderer bgImage;
    public cameraShake camShake;

    //AUDIO
    [FMODUnity.EventRef]
    public string logoSound = "event:/LogoSound";
    FMOD.Studio.EventInstance logoSoundStart; //eventInstance

    [FMODUnity.EventRef]
    public string musicSound = "event:/Music01";
    FMOD.Studio.EventInstance music01; //eventInstance

    [FMODUnity.EventRef]
    public string goalSound = "event:/WinSound";
    FMOD.Studio.EventInstance goalSFX; //eventInstance

    [FMODUnity.EventRef]
    public string winSound = "event:/GoalSound";
    FMOD.Studio.EventInstance winSFX; //eventInstance

    void Awake()
    {
        int randomBg = 0;
        randomBg = Random.Range(0, backgrounds.Count);
        //bgImage.sprite = backgrounds[randomBg]; 
        bgImage.material = backgrounds[randomBg];

        //AUDIO
        logoSoundStart = FMODUnity.RuntimeManager.CreateInstance(logoSound);
        logoSoundStart.start();
        music01 = FMODUnity.RuntimeManager.CreateInstance(musicSound);
        goalSFX = FMODUnity.RuntimeManager.CreateInstance(goalSound);
        winSFX = FMODUnity.RuntimeManager.CreateInstance(winSound);

        StartCoroutine(StartMatch());
    }

    // Use this for initialization
    void Start()
    {
        gameMan = transform.GetComponent<gameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < scoreCheck.Count; i++)
        {
            if (scoreCheck[i] < gameMan.scores[i])
            {
                scoreCheck[i] = gameMan.scores[i];
                Goal(i);
            }
        }
    }

    public IEnumerator StartMatch()
    {
        yield return new WaitForSeconds(1.5f);
        music01.start();
    }

    public void Goal(int playerThatScored)
    {
        gameMan.playerInfo[playerThatScored].Goal();
        camShake.Shake(0.25f);
        goalSFX.start();
    }

    public void EndGame()
    {
        winSFX.start();
    }
}
