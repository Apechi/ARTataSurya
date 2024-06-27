using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadingQuiz : MonoBehaviour
{
    public Text Conter;
    private int x;
    // Start is called before the first frame update
   void Start()
    {
        StartCoroutine(loading());
    }

    IEnumerator loading()  //  <-  its a standalone method
        {
            x=3;
            do{
                Conter.text=x.ToString();
                yield return new WaitForSeconds(1);
                x--;
                if(x==0){
                    Conter.text="";
                }
            }while(x>0);
            Conter.text="";
            SceneManager.LoadScene("Quiz", LoadSceneMode.Single);
        }
}
