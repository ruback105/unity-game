using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public Score score;
    private PlayerCollision playerCollision;

    public float forwardForce = 20000f;
    public float sidewaysForce = 600f;
    public float minYPosition = 5f;
    public float xOffset = 46f;


    private void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d")) 
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        } else if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("space"))
        {
            if (PlayerPrefs.GetFloat("score") >= 1000f)
            {
                score.setScore(-1000);
                StartCoroutine(boostPlayer(forwardForce * 100 * Time.deltaTime));
            }
        }

        if (rb.position.y < minYPosition)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if(rb.transform.position.x > xOffset || rb.transform.position.x < -xOffset)
        {
            rb.velocity = new Vector3(-rb.transform.position.x/3, 0, rb.velocity.z);
        }
    }

    IEnumerator boostPlayer(float force) 
    {
        playerCollision = gameObject.GetComponent<PlayerCollision>();
        playerCollision.disableCollision(true);
        rb.AddForce(0, 0, force);

        yield return new WaitForSeconds(3);
        playerCollision.disableCollision(false);
    }
}
