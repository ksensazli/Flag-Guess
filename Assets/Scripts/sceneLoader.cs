using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void setLicensePlate()
    {
        SceneManager.LoadScene("licensePlate", LoadSceneMode.Single);
    }

    public void setFlagEU_ez()
    {
        SceneManager.LoadScene("FlagEU_EZ", LoadSceneMode.Single);
    }

    public void setFlagEU_hd()
    {
        SceneManager.LoadScene("FlagEU_HD", LoadSceneMode.Single);
    }
}
