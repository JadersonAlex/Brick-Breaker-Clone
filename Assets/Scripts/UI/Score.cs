using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Score : MonoBehaviour
{
    public int Pontos;
    public TMP_Text TextScore;


  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            Pontos++;
            TextScore.text = "Score: " + Pontos.ToString();

        }
    }
    
    
}
