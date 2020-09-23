using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip BackgroundIntro;
    [SerializeField]
    private AudioClip BackgroundNormalState;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(playEngineSound());
    }

    IEnumerator playEngineSound()
    {
            GetComponent<AudioSource>().clip = BackgroundIntro;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(BackgroundIntro.length);
            GetComponent<AudioSource>().clip = BackgroundNormalState;
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().loop = true;
    }

}
