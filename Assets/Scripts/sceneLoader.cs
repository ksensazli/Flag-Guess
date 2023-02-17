using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void setLicensePlate()
    {
        SceneManager.LoadScene("LicensePlate", LoadSceneMode.Single);
    }

    public void setMainMenu()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void setFlagEU_ez()
    {
        SceneManager.LoadScene("FlagEU", LoadSceneMode.Single);
    }

    public void setFlagAsia()
    {
        SceneManager.LoadScene("FlagAsia", LoadSceneMode.Single);
    }
}
