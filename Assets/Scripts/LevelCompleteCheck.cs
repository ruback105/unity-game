using UnityEngine;
using UnityEngine.UI;

public class LevelCompleteCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetInt(this.transform.parent.gameObject.name) == 1)
        {
            this.GetComponent<Toggle>().isOn = true;
        }
    }

}
