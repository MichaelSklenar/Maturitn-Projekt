using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool HraSkončila = false;
    public void KonecHry() // Smrt
    {

        if (HraSkončila == false)
        {

            HraSkončila = true;
            Invoke("Restart", 2f);
        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}
