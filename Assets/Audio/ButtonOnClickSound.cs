using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonOnClickSound : MonoBehaviour
{
    public AudioSource sound;

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(PlaySound);
    }

    public void PlaySound()
    {
        sound.Play();
    }
}
