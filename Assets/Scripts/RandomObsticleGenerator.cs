using System.Collections;
using UnityEngine;

public class RandomObsticleGenerator : MonoBehaviour
{
    public GameObject theBrick;
    public GameObject theAbyss;
    public GameObject theWhirpool;
    public GameObject theTree;

    public GameObject[] objects;
    public Transform player;

    private int xPos;
    private int zPos;
    private float yPos;
    private int objectToGenerate;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("game_ended", 0);
        StartCoroutine(GenerateObjects());
        StartCoroutine(RemoveObjects());
    }

    IEnumerator GenerateObjects()
    {
        if(PlayerPrefs.GetInt("game_ended") == 0)
        {
            // create validation, to check if object can be spawned, if (validation) - make sure that we can spawn object safely
            objectToGenerate = GenerateRandomInt(1,7);
            this.xPos = Random.Range(-30, 30);
            this.zPos = Random.Range((int)player.position.z + 700, (int)player.position.z + 1000);

            if (objectToGenerate >= 1 && objectToGenerate <= 4)
            {
                yPos = 3f;
                GenerateBrick(xPos, yPos, zPos, objectToGenerate);
            }
            else if (objectToGenerate == 5)
            {
                yPos = 0.1f;
                GenerateAbyss(this.xPos, yPos, this.zPos);
            }
            else if (objectToGenerate == 6)
            {
                yPos = 0.1f;
                GenerateWhirpool(this.xPos, yPos, this.zPos);
            }
            else if (objectToGenerate == 7)
            {
                yPos = 0f;
                GenerateTree(this.xPos, yPos, this.zPos);
            }

            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(GenerateObjects());
        }
    }

    IEnumerator RemoveObjects()
    {
        this.objects = GameObject.FindGameObjectsWithTag("Obstacle");

        foreach(GameObject oneObject in objects)
        {
            if(oneObject.transform.position.z < player.position.z && oneObject.tag == "Obstacle")
            {
                Destroy(oneObject);
            }
        }

        yield return new WaitForSeconds(5f);
        yield return StartCoroutine(RemoveObjects());
    }

    void GenerateBrick (int xPos, float yPos, int zPos, int objectToGenerate)
    {
        for (int index = 0; index < objectToGenerate; index++)
        {
            int xScale = GenerateRandomInt(7, 13);
            theBrick.transform.localScale = new Vector3(xScale, 5, 7);
            zPos += 5 + xScale; // Moving blocks forward so they don't stack up

            // 75% chance that object will be spawned randomly
            if(GenerateRandomInt(1, 4) != 1)
            {
                if (xPos < 0 && xPos - 5 > -40 + xScale)
                {
                    xPos -= 5;
                }
                else if (xPos + 5 < 40 - xScale)
                {
                    xPos += 5;
                }
                else
                {
                    xPos -= 10;
                }
            }
            // 25% chance that object will be spawned in front of the player
            else
            {
                xPos = (int)player.transform.position.x;

                if (xPos + xScale/2 > 30)
                {
                    xPos = (int)player.transform.position.x - xScale / 2;
                } else if(xPos - xScale / 2 < 30)
                {
                    xPos = (int)player.transform.position.x + xScale / 2;
                } 
            }

            Instantiate(theBrick, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        }
    }

    void GenerateAbyss (int xPos, float yPos, int zPos)
    {
        theAbyss.transform.localScale = GenerateScale(3, 3, 3);
        Instantiate(theAbyss, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    void GenerateWhirpool (int xPos, float yPos, int zPos)
    {
        theWhirpool.transform.localScale = GenerateScale(3, 3, 3);
        Instantiate(theWhirpool, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    void GenerateTree (int xPos, float yPos, int zPos)
    {
        Instantiate(theTree, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    Vector3 GenerateScale (int maxScaleX, int maxScaleY, int maxScaleZ)
    {
        return new Vector3(Random.Range(1, maxScaleX), Random.Range(1, maxScaleY), Random.Range(1, maxScaleZ));
    }

    int GenerateRandomInt (int start, int end)
    {
        // Incresing end to 1, since Range doesn't include last value
        return Random.Range(start, end + 1);
    }
}
