using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Score score;

    public PlayerMovement movement;

    public bool godMode = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle" && !godMode)
        {
            movement.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

            AudioSource audio = GetComponent<AudioSource>();
            if(audio)
            {
                audio.Play();
            }
        }
    }

    public void disableCollision (bool status)
    {
        this.godMode = status;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coins")
        {
            PlayerPrefs.SetFloat("score", PlayerPrefs.GetFloat("score") + 100);
            other.gameObject.SetActive(false);
        }
    }
}
