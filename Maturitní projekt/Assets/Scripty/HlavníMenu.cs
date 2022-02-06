using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HlavníMenu : MonoBehaviour
{
    public void Odejít()
    {
        Application.Quit();
    }

    public void Hrát()
    {
        SceneManager.LoadScene(1);
    }
}
