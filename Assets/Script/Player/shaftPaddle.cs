using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class shaftPaddle : MonoBehaviour {

    //Sub-script of playerEvent and playerMovement

    float power = 75.0f;
    bool hitting = false;
    float velocityDamping = 2.0f; //Damping

    float originalZRotation = 0.0f;
    Rigidbody2D rBody;

    public playerEvents playerEvent;
    Transform tipPosition;

    public bool scalable = false; //if true, use variables below
    public float initialScale = 1.0f;
    float currentScale = 1.0f;
    public float scaleUpHits = 1.5f;
    public float scaleSpeed = 1.5f;

    //AUDIO
    [FMODUnity.EventRef]
    public string wallShaftSound = "event:/Hits/ShaftWallHit";
    FMOD.Studio.EventInstance wallHit; //eventInstance

    // Use this for initialization
    void Start()
    {
        //initialScale = transform.localScale.x;

        if (playerEvent != null)
        {
            tipPosition = playerEvent.tipPosition;
            rBody = transform.GetComponent<Rigidbody2D>();
            originalZRotation = rBody.rotation;
        }

        //AUDIO
        wallHit = FMODUnity.RuntimeManager.CreateInstance(wallShaftSound);
    }
	
	// Update is called once per frame
	void Update () {
	    
        if (scalable)
        {
            float scaleLerp = Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed);
            transform.localScale = new Vector3(scaleLerp, scaleLerp, scaleLerp);
            currentScale = Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed);
        }
	}

    public void ScaleUp()
    {
        scalable = false;
        currentScale += scaleUpHits;
        StartCoroutine(CoScaleUp());
    }

    public IEnumerator CoScaleUp()
    {
        yield return new WaitForSeconds(0.2f);
        scalable = true;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ball")
        {
            if (scalable)
                ScaleUp();

            ContactPoint2D contact;
            contact = col.contacts[0];
            Hit(col.collider, contact);
        }

        if (col.gameObject.tag == "Wall")
        {
            wallHit.start();
        }

    }

    void Hit(Collider2D col, ContactPoint2D contact)
    {
        if (hitting == false)
        {
            hitting = true;
            //Damp velocity
            col.GetComponent<Rigidbody2D>().velocity = (col.GetComponent<Rigidbody2D>().velocity / velocityDamping);
            //AddForce towards the normal of the contact point
            col.GetComponent<Rigidbody2D>().AddForce(-contact.normal * power);

            //Small Cum
            if (playerEvent != null)
            {
                float lookDirection = tipPosition.rotation.z;
                Transform cumSmallClone = Instantiate(playerEvent.cumParticleSmall, tipPosition.position, Quaternion.Euler(new Vector3(0, 0, lookDirection))) as Transform;
                cumSmallClone.parent = tipPosition; //so that the trail will follow the player
            }


            //if (flipOnAndOffOnHit == true)  //if true, the collider will turn on and off based on flipOffTime
            //StartCoroutine(collisionOffAndOn(flipOffTime));
            StartCoroutine(CoHit());
        }
    }

    public IEnumerator CoHit()
    {
        yield return new WaitForSeconds(0.1f);
        hitting = true;
    }

    public void GetHard()
    {
        rBody.MoveRotation(originalZRotation);
        StartCoroutine(CoGetHard());
    }

    public IEnumerator CoGetHard()
    {
        for (int i = 0; i < 50; i++)
        {
            yield return new WaitForSeconds(0.005f);
            rBody.MoveRotation(originalZRotation);
        }
        yield return new WaitForSeconds(0.1f);
    }

    public void GetHard(float rotation)
    {
        rBody.MoveRotation(rotation);
        StartCoroutine(CoGetHard(rotation));
        //transform.localPosition += new Vector3(transform.localPosition.x, transform.localPosition.y + 0.01f, transform.localPosition.z);
    }

    public IEnumerator CoGetHard(float rotation)
    {
        for (int i = 0; i < 65; i++)
        {
            yield return new WaitForSeconds(0.005f);
            rBody.MoveRotation(rotation);
        }
        yield return new WaitForSeconds(0.1f);
    }

}
