using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class scriptParalax : MonoBehaviour
{
   [SerializeField] private Vector2 efeitoParallax; // colocando para ser manipulando no Unity
    private Transform cameraTransform;
    private Vector3 cameraUltimaPos; //ultima posição da camera
    private float texturaTamanhoX;
    private float texturaTamanhoY;


    private void Start(){
        cameraTransform = Camera.main.transform; //pegar a camera principal
        cameraUltimaPos = cameraTransform.position; //ultima posição da camera é a atual quando começa o jogo

        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D textura = sprite.texture;
        texturaTamanhoX = textura.width / sprite.pixelsPerUnit;
        texturaTamanhoY = textura.height / sprite.pixelsPerUnit;
    }

    private void LateUpdate(){
        Vector3 deltaMovCamera = cameraTransform.position - cameraUltimaPos; //lembre-se que o "delta" tbm é outro termo para variação
        
        transform.position += new Vector3(deltaMovCamera.x* efeitoParallax.x,deltaMovCamera.y* efeitoParallax.y);
        cameraUltimaPos = cameraTransform.position; //background seguindo a camera

        if(Mathf.Abs(cameraTransform.position.x - transform.position.x) >= texturaTamanhoX){
            //relocando o transform para a textura se repetir
            float offsetX = (cameraTransform.position.x - transform.position.x) % texturaTamanhoX; //margem de erro
            transform.position = new Vector3(cameraTransform.position.x + offsetX, transform.position.y);
        }

        if(Mathf.Abs(cameraTransform.position.y - transform.position.y) >= texturaTamanhoY){
            //relocando o transform para a textura se repetir
            float offsetY = (cameraTransform.position.y - transform.position.y) % texturaTamanhoY; //margem de erro
            transform.position = new Vector3(transform.position.x,cameraTransform.position.y + offsetY);
        }
    }

}

