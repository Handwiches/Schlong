using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ballScript : MonoBehaviour {

    public Rigidbody2D rBody;
    public float startPower = 50.0f;
    public TrailRenderer trail;
    public float trailLength = 1.5f; //trail.time
    public float trailSpeedLimit = 10.0f;//based on vMagnitude
    float currentTrailLength = 0.0f;

    public float velocityMagnitude; //just for reading
    public float maxSpeed = 100.0f;
    public float minSpeed = 5.0f;

    //AudioVisual
    public float scaleSpeed = 0.6f;
    public float initialScale = 0.7f;
    float currentScale = 1.0f;
    public float scaleUpHits = 1.5f;


    // Use this for initialization
    void Start () {
        //resetPosition();
        StartCoroutine(StartGame());
        trail = transform.GetComponent<TrailRenderer>();
    }

    void FixedUpdate()
    {
        //Max Velocity Limit
        if (rBody.velocity.magnitude > maxSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * maxSpeed;
        }
        if (rBody.velocity.magnitude < minSpeed)
        {
            rBody.velocity = rBody.velocity.normalized * minSpeed;
        }
        velocityMagnitude = rBody.velocity.magnitude;

        if (rBody.velocity.magnitude > trailSpeedLimit)
        {
            currentTrailLength = Mathf.Lerp(0.0f, trailLength, Time.deltaTime * 5.0f);
            trail.time = currentTrailLength;
        }
        else
        {
            print("lower trail");
            float nowLength = currentTrailLength;
            currentTrailLength = Mathf.Lerp(nowLength, 0.0f, Time.deltaTime * 1.5f);
            trail.time = currentTrailLength;
            //trail.time = Mathf.Lerp(0.0f, trailLength, Time.deltaTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float scaleLerp = Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed);
        transform.localScale = new Vector3(scaleLerp, scaleLerp, scaleLerp);
        currentScale = Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed);
    }



    public void ScaleUp()
    {
        currentScale = scaleUpHits;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        ScaleUp();
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.5f);
        resetPosition();
    }


    public void resetPosition()
    {
        currentTrailLength = 0.0f;
        trail.time = 0.0f;
        transform.position = new Vector3(0, 0, 0);
        rBody.velocity = new Vector2(0,0);

        StartCoroutine(coResetPosition());
    }

    public IEnumerator coResetPosition()
    {
        yield return new WaitForSeconds(0.6f);
        int leftOrRight = 0;
        leftOrRight = Random.Range(0, 2);

        if (leftOrRight == 0)
        {
            rBody.AddForce(new Vector2(startPower, 0));
        }
        else
        {
            rBody.AddForce(new Vector2(-startPower, 0));
        }
    }
}
