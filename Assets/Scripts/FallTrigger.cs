using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("FallingBlock");
        foreach(GameObject block in blocks)
        {
            block.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }
}
