using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    public GameObject theCoin;

    public Transform player;

    public float yPos = 3f;
    private float zPos;

    public List<float> spawnX = new List<float>();
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerateCoins());
    }

    // Update is called once per frame
    IEnumerator GenerateCoins()
    {
        zPos = Random.Range((int)player.position.z + 700, (int)player.position.z + 1000);

        validateSpawn(-30, 30, yPos, zPos);
       
        yield return new WaitForSeconds(Random.Range(3, 11));
        yield return StartCoroutine(GenerateCoins());
    }

    void spawn (float xPos, float yPos, float zPos)
    {
        GameObject coin = Instantiate(theCoin, new Vector3(xPos, yPos, zPos), Quaternion.identity);
        coin.transform.Rotate(90, 0, 0, Space.Self);
    }

    void validateSpawn(float xStart, float xEnd, float yPos, float zPos)
    {
        float radius = 3f;
        for (float start = xStart; start < xEnd; start += 2) {
            if (!Physics.CheckSphere(new Vector3(start,yPos,zPos), radius)){
                spawnX.Add(start);
            }
        }
        
        if(spawnX.Count > 0)
        {
            spawn(spawnX[Random.Range(0, spawnX.Count+1)], yPos, zPos);
        }
    }
}
