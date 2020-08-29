using System.Collections;
using UnityEngine.Audio; 
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enums;

public class AudioManager : MonoBehaviour
{

    public AudioClip BoxDestructionClip;


    public List<AudioSource> AudioSources =  new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        DelegateHandler.BoxDestroyed += BoxDestroyed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BoxDestroyed(ColumnType columnType, BoxType boxType)
    {
        AudioSource audioSource = AudioSources.FirstOrDefault(x => x.isPlaying == false);
        if (audioSource)
        {
            audioSource.clip = BoxDestructionClip;
            audioSource.Play();
        }

    }

    private void OnDestroy()
    {
        DelegateHandler.BoxDestroyed -= BoxDestroyed;
    }
}
