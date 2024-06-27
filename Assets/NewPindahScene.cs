using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPindahScene : MonoBehaviour
{
    public string scene_tujuan;
    public void PindahScene () {
         SceneManager.LoadScene(this.scene_tujuan);
     }
}
