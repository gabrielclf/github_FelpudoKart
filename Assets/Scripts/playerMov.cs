using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMov : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float movimento_Horizontal = 0f;
    public float velocidade_mov = 40f;
    public bool pular = false;
    public bool abaixar = false;

    // Update is called once per frame
    void Update()
    {
        movimento_Horizontal = Input.GetAxisRaw("Horizontal") * velocidade_mov;


        if (Input.GetButtonDown("Jump"))
        {
            pular = true;
            anim.SetBool("estaPulando",true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            abaixar = true;
            // anim.SetBool("estaAbaixado",true);
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            abaixar = false;
            //anim.SetBool("estaAbaixado",false);
        }
    }

    public void OnLanding(){
        anim.SetBool("estaPulando",false);
    }

    public void noAbaixamento(bool abaixado)
    {
        anim.SetBool("estaAbaixado", abaixado);
    }

    private void FixedUpdate()
    { //similar ao update mas tem limites de quantas vezes pode ser chamado
        //Movimentar o personagem
        controller.Move(movimento_Horizontal * Time.fixedDeltaTime, abaixar, pular); // (movimentação?,abaixa?,pula?)
        pular = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstaculo"))
        {
            controladorVidas.vidas -= 1;
        }
        if (other.CompareTag("Pickup"))
        {
            controladorVidas.vidas += 1;
        }
    }
}
