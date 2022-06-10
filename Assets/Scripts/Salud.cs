using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Salud : MonoBehaviour
{

    [SerializeField] int SaludInicial;
    [SerializeField] ParticleSystem explosion;
    public  int saludActual;
    SFXScript soundEfector;
    

    // Start is called before the first frame update
    void Start()
    {
        saludActual = SaludInicial;
        soundEfector = FindObjectOfType<SFXScript>();
        explosion = FindObjectOfType<ParticleSystem>();
        
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
        soundEfector.PlayDestroy();
        explosion.transform.position = transform.position;
        explosion.Play();


        if(gameObject.CompareTag("Player"))
        { 
            GameManager.Instancia.runGameOver();
        }

        Destroy(gameObject);
    }
}
