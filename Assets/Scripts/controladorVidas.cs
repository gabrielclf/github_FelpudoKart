using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorVidas : MonoBehaviour
{
    public GameObject vida1, vida2, vida3;
    public static int vidas;
    // Start is called before the first frame update
    void Start()
    {
        vidas = 3;
        vida1.gameObject.SetActive(true);
        vida2.gameObject.SetActive(true);
        vida3.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (vidas > 3)
        {
            vidas = 3;
        } else if (vidas == 0){
            SceneManager.LoadScene("GameOver");
        }

        switch (vidas)
        {
            case 3:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(true);
                vida3.gameObject.SetActive(true);
                break;

            case 2:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(true);
                vida3.gameObject.SetActive(false);
                break;

            case 1:
                vida1.gameObject.SetActive(true);
                vida2.gameObject.SetActive(false);
                vida3.gameObject.SetActive(false);

                break;

            case 0:
                vida1.gameObject.SetActive(false);
                vida2.gameObject.SetActive(false);
                vida3.gameObject.SetActive(false);
                Time.timeScale = 0;
            break;

            
        }
    }
}
