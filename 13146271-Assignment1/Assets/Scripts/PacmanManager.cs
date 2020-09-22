using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip BackgroundIntro;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<AudioSource>().clip = BackgroundIntro;
            GetComponent<AudioSource>().Play();
        }
    }
}
