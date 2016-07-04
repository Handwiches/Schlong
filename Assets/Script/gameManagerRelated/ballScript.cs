using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class ballScript : MonoBehaviour {

    public Rigidbody2D rBody;
    public float startPower = 50.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed), Mathf.Lerp(currentScale, initialScale, Time.deltaTime * scaleSpeed), 0.6f);
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
