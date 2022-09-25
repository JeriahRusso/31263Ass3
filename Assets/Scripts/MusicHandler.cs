using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicHandler : MonoBehaviour
{
    [SerializeField] private AudioClip introMusic;
    [SerializeField] private AudioClip mainMusic;
    private AudioSource source;

    void Start() 
    {
        source = GetComponent<AudioSource>();
        StartCoroutine(playIntroMusic());
    }

    void Update()
    {

    }

    IEnumerator playIntroMusic() 
    {
        source.clip = introMusic;
        source.Play();
        yield return new WaitForSeconds(introMusic.length);
        source.clip = mainMusic;
        source.Play();
        source.loop = true;
    }
}
