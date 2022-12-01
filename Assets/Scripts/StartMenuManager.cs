using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuManager : MonoBehaviour
{
    public void LoadGame()
    {
        DataAndScore.Instance.playerName = GameObject.Find("PlayerNameField").transform.GetChild(2).gameObject.GetComponent<Text>().text;
        SceneManager.LoadScene("main");
    }

    public void QuitGame()
    {
        Application.Quit();
        DataAndScore.Instance.SaveData();
    }
}
