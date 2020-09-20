using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource BackgroundIntro;
    public AudioSource BackgroundNormalState;
    // Start is called before the first frame update
    void Start()
    {
        BackgroundIntro.Play();
        Invoke("PlayBackground", 144f);
    }

    void PlayBackground()
    {
        BackgroundNormalState.Play();
    }

}
