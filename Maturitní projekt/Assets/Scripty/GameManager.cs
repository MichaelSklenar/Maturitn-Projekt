using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool HraSkon�ila = false;
    public void KonecHry() // Smrt
    {

        if (HraSkon�ila == false)
        {

            HraSkon�ila = true;
            Invoke("Restart", 2f);
        }

    }
    public void V�hra()
    {
        if (HraSkon�ila == false)
        {

            HraSkon�ila = true;
            Invoke("Dal��Level", 2f);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void Dal��Level()
    {
        SceneManager.LoadScene(2);
    }

}
