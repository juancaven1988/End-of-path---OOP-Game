using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instancia { get;private set; }
    public static bool GameStart { get; set; }
    public static bool GameOver { get; set; }

    [Header ("Movimiento Fondo")]
    [SerializeField] GameObject background;
    [SerializeField] float backgroundSpeed;
    Vector3 startPos;
    float backgroundMinZ = 204;

    [Header("Timer")]
    [SerializeField] float tiempoPartida;
    bool tiempoCorriendo;
    float cuantaAtras = 4;


    //SCORE
    int Score = 0;

   


    // Start is called before the first frame update
    void Start()
    {
        startPos = background.transform.position;

        if(Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!tiempoCorriendo)
        {
            LaunchGame();
        }
        
        if(GameStart && !GameOver)
        {
            RunGame();
        }

       if(GameOver)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }

    public void IncreaseScore()
    {
        Score += 100;
        UIManager.instancia.ActualizarScore(Score);
    }

    public void runGameOver()
    {
        Debug.Log("Game Over");
        GameOver = true;
        UIManager.instancia.GameOver();
    }

    private void RunGame()
    {
        if (background.transform.position.z < startPos.z - backgroundMinZ)
        {
            background.transform.position = startPos;
        }

        background.transform.Translate(Vector3.back * backgroundSpeed * Time.deltaTime);

        if (tiempoCorriendo)
        {
            tiempoPartida = Mathf.Max(0, tiempoPartida - Time.deltaTime);
            UIManager.instancia.ActualizarTiempo(tiempoPartida);
           
        }
    }

    private void LaunchGame()
    {
        cuantaAtras = Mathf.Max(0, cuantaAtras - Time.deltaTime);

        UIManager.instancia.MostrarCuentaRegresiva((Mathf.FloorToInt(cuantaAtras % 60)));

        if (cuantaAtras == 0)
        {
            tiempoCorriendo = true;
            GameStart = true;
        }
    }
}
