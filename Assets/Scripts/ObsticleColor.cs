using UnityEngine;

public class ObsticleColor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color background = generateRandomColor();

        gameObject.GetComponent<Renderer>().material.SetColor("_Color", background);

    }
    Color generateRandomColor ()
    {
        return new Color(
          Random.Range(0f, 1f),
          Random.Range(0f, 1f),
          Random.Range(0f, 1f)
        );
    }
}
