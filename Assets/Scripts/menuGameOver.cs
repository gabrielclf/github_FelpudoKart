using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuGameOver : MonoBehaviour{
   public void FecharJogo(){
        Application.Quit();
        Debug.Log("Fechou!");
   }

   public void RetornaMenu(){
        SceneManager.LoadSceneAsync("MenuPrincipal");
   }

   public void ReiniciarJogo(){
        //SceneManager.LoadSceneAsync();
   }
}
