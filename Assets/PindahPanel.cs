using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PindahPanel : MonoBehaviour
{
    public GameObject PanelAwal;
    public GameObject PanelTujuan;

    public void GantiKePanelBaru(){
        PanelAwal.SetActive (false);
        PanelTujuan.SetActive(true);
    }

}
