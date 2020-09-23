using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacmanManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource PacmanSource;

    private void Start()
    {
        PacmanSource.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!PacmanSource.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                PacmanSource.Play();
            }
        }
    }
}
