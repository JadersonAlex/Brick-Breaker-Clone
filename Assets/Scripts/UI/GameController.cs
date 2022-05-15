using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Animator anim;


     void Start()
    {
        anim.SetTrigger("StartLevel");
        StartCoroutine("Level_Text_EndAnim"); // chamando a corrotina 

    }


    IEnumerator Level_Text_EndAnim()
    {
        //Debug.Log("Executando corrotina");
        yield return new WaitForSeconds(3f);
        anim.SetTrigger("LevelEND");
        //Debug.Log("Executando após WaitForSeconds (5 segundos)");
    }
}
