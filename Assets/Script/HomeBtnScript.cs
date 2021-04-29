using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeBtnScript : MonoBehaviour
{
    public void GoBackHome()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void Retry()
    {
        SceneManager.LoadScene("BasicGamemodeScene");
    }
}
