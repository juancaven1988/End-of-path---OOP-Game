using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{

    [SerializeField] int SaludInicial;
    public  int saludActual;

    // Start is called before the first frame update
    void Start()
    {
        saludActual = SaludInicial;
    }

    public void perderSalud()
    {
        saludActual--;
        if(saludActual <= 0)
        {
            Morir();
        }
    }

    private void Morir()
    {
        if(gameObject.CompareTag("Player"))
        { 
            GameManager.Instancia.runGameOver();
        }

        Destroy(gameObject);
    }
}
