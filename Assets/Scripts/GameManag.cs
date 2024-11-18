using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManag : MonoBehaviour
{
    public static GameManag Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI texto_pontuacao;
    private float pontuacao;

    private playerMov player;
    private spawnerPickups spawner;
    private void Awake()
    {
        if (Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<playerMov>();
        spawner = FindObjectOfType<spawnerPickups>();

        NewGame();
    }

    public void NewGame()
    {
        obstaculo[] obstacles = FindObjectsOfType<obstaculo>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        pontuacao = 0f;
        
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        
    }

    public void GameOver()
    {
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

    }

    private void Update()
    {
        pontuacao += 1f * Time.deltaTime;
        texto_pontuacao.text = Mathf.FloorToInt(pontuacao).ToString("D3");
    }

    private void FixedUpdate() {
        if (pontuacao >=30){
            SceneManager.LoadSceneAsync("YouWin");
        }
    }

}
