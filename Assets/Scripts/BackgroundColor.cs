using System.Collections;
using UnityEngine;

public class BackgroundColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(changeBackgroundColor());
    }

    IEnumerator changeBackgroundColor()
    {
        gameObject.GetComponent<Camera>().backgroundColor = generateRandomColor();
        yield return new WaitForSeconds(1f);
        yield return changeBackgroundColor();
    }

    Color generateRandomColor()
    {
        return new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );
    }
}
