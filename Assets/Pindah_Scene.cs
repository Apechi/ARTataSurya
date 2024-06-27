using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pindah_Scene : MonoBehaviour
{
    public string namaScene;

    public void PindahKeScene(){

        Scene sceneIni = SceneManager.GetActiveScene ();

        if(sceneIni.name != namaScene){
            SceneManager.LoadScene (namaScene);
        }
    }
}
