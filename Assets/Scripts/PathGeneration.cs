using System.Collections;
using UnityEngine;

public class PathGeneration : MonoBehaviour
{
    public GameObject theRoad;
    public GameObject theTurn;
    public Transform player;

    public float initialRoadPosition;

    // Start is called before the first frame update
    void Start()
    {
        this.initialRoadPosition = theRoad.transform.position.z;
        StartCoroutine(MoveRoad());
    }

    IEnumerator MoveRoad()
    {
        this.theRoad.transform.position = new Vector3(0, 0, this.initialRoadPosition + this.player.position.z);

        yield return new WaitForSeconds(1f);
        yield return StartCoroutine(MoveRoad());
    }

    void turnRoad ()
    {
        // get end road pos

        // generate side to turn road
        int sideToGenerate = Random.Range(1, 3);

        // generate turn
        if(sideToGenerate == 1)
        {

        } else
        {

        }

        // continue road on the turn side

        // delete old road
        Destroy(theRoad);
    }

}
