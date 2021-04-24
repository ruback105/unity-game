using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickAction : MonoBehaviour
{
	void Start()
	{
		Button btn = this.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick(){
		SceneManager.LoadScene("Scenes/" + gameObject.name);
	}
}
