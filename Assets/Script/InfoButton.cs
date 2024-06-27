using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    // Referensi ke objek "infoError"
    public GameObject infoError;

    // Fungsi yang akan dipanggil ketika tombol ditekan
    public void OnButtonPress()
    {
        // Dapatkan semua objek children dari objek parent ini
        var children = transform.GetComponentsInChildren<Transform>();

        // Cari objek children yang aktif
        foreach (var child in children)
        {
            if (child.gameObject.activeInHierarchy)
            {
                // Cari objek "Info" di dalam objek children yang aktif
                var info = GameObject.FindGameObjectWithTag("Infoplanet");
                if (info != null)
                {
                    // Dapatkan referensi ke component Canvas
                    var canvas = info.GetComponent<Canvas>();
                    if (canvas != null)
                    {
                        // Aktifkan component Canvas
                        canvas.enabled = true;
                    }
                    else
                    {
                        // Component Canvas tidak ditemukan
                        infoError.SetActive(true);
                        StartCoroutine(DeactivateAfterSeconds(infoError, 2f));
                    }
                }
                else
                {
                    // Objek "Info" tidak ditemukan
                    infoError.SetActive(true);
                    StartCoroutine(DeactivateAfterSeconds(infoError, 2f));
                }
                break;
            }
        }
    }

    private IEnumerator DeactivateAfterSeconds(GameObject obj, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        obj.SetActive(false);
    }
}

