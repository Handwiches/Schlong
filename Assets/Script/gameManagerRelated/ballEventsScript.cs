using UnityEngine;
using System.Collections;

//Attach this to the ball with ballScript
public class ballEventsScript : MonoBehaviour {

    //AUDIO ELEMENTS
    [FMODUnity.EventRef]
    public string ballWallSound = "event:/Hits/BallWallHit";
    FMOD.Studio.EventInstance wallHit; //eventInstance
    //FMOD.Studio.ParameterInstance gamePlaying;

    [FMODUnity.EventRef]
    public string ballBallsSound = "event:/Hits/BallBallsHit";
    FMOD.Studio.EventInstance ballsHit; //eventInstance

    [FMODUnity.EventRef]
    public string ballShaftSound = "event:/Hits/ShaftBallHit";
    FMOD.Studio.EventInstance shaftHit; //eventInstance


    void Awake()
    {
        //Audio
        wallHit = FMODUnity.RuntimeManager.CreateInstance(ballWallSound);
        ballsHit = FMODUnity.RuntimeManager.CreateInstance(ballBallsSound);
        shaftHit = FMODUnity.RuntimeManager.CreateInstance(ballShaftSound);

    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
            wallHit.start();

        if (col.gameObject.tag == "Balls")
            ballsHit.start();

        if (col.gameObject.tag == "Shaft")
            shaftHit.start();

    }
}
