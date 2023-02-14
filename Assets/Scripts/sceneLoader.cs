using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void setLicensePlate()
    {
        SceneManager.LoadScene("licensePlate", LoadSceneMode.Single);
    }

    public void setFlagEU()
    {
        SceneManager.LoadScene("FlagEU", LoadSceneMode.Single);
    }
}
