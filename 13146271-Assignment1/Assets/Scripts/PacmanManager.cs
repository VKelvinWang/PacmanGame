using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource PacmanSound;

    // Update is called once per frame
    void Update()
    {
        if (!PacmanSound.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                PacmanSound.Play();
            }
        }
    }
}
