using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gestordevidas : MonoBehaviour
{
    public int vidas =3;
    public GameObject vida3;
    public GameObject vida2;
    public GameObject vida1;

    private void Update()
    {
        if (vidas == 2)
        {
            vida3.SetActive(false);
        }
        if (vidas == 1)
        {
            vida2.SetActive(false);

        }
        if (vidas == 0)
        {
            vida1.SetActive(false);

        }
        if (vidas < 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
          
    }

}
