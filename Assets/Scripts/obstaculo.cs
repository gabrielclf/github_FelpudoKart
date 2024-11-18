using UnityEngine;

public class obstaculo : MonoBehaviour
{
    //movendo obstáculo pela tela
    private float bordaEsquerda;

    private void Start() {
        bordaEsquerda = Camera.main.ScreenToWorldPoint(Vector3.zero).x;
    }
    private void Update() {
        transform.position += Vector3.left * Time.deltaTime;

        if (transform.position.x <bordaEsquerda){
            Destroy(gameObject);
        }
    }
}
