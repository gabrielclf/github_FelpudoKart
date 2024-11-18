using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime;
    public string proxCena;
    
    public void LoadNextLevel()
    {
        StartCoroutine(CarregarCena(proxCena));
    }

     IEnumerator CarregarCena(string cena)
     {
          transition.SetTrigger("Start");

          yield return new WaitForSeconds(transitionTime); //pausar a co-rotina

          SceneManager.LoadSceneAsync(cena);
     }
}
