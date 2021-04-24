using UnityEngine;

public class ValidateSpawn : MonoBehaviour
{
    public GameObject gameManager;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Obstacle")
        {
            if (PlayerPrefs.GetInt("game_ended") == 0)
            {
                Destroy(collision.collider.gameObject);
            }
        }
    }
}
