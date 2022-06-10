using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instancia { get; private set; }


    [SerializeField] TextMeshProUGUI CuentaAtras;
    [SerializeField] TextMeshProUGUI tiempoTXT;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject gameOver;
    

    // Start is called before the first frame update
    void Start()
    {
        if(instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActualizarScore(int value)
    {
        ScoreText.text = value.ToString();
    }

    public void MostrarCuentaRegresiva(int value)
    {
        CuentaAtras.text = value.ToString();
        if(value == 0)
        {
            CuentaAtras.gameObject.SetActive(false);
        }
    }

    public void ActualizarTiempo(float time)
    {
        tiempoTXT.text = string.Format("{00:00}:{01:00}", Mathf.FloorToInt(time / 60), Mathf.FloorToInt(time % 60));
    }


    public void GameOver()
    {
        gameOver.SetActive(true);
    }

}
