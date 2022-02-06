using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool HraSkonèila = false;
    public void KonecHry() // Smrt
    {

        if (HraSkonèila == false)
        {

            HraSkonèila = true;
            Invoke("Restart", 2f);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
