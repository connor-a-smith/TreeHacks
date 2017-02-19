using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour {

    private int lastSoundIndex = -1;

    [SerializeField]
    private AudioClip[] clips;

    private AudioSource currentSource;

	// Use this for initialization
	void Start () {
        currentSource = GetComponent<AudioSource>();
        StartCoroutine(playClips());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private IEnumerator playClips()
    {
        //Start with first clip.
        lastSoundIndex = 0;
        currentSource.clip = clips[0];
        currentSource.Play();

        while (true)
        {
            while (currentSource.isPlaying)
            {
                yield return null;
            }

            int clipIndex = Random.Range(0, clips.Length - 1);

            //If the clip has just been played or is after that one, increment by 1.    
            if (clipIndex>= lastSoundIndex)
            {
                clipIndex += 1;
            }

            currentSource.clip = clips[clipIndex];
            lastSoundIndex = clipIndex;
            currentSource.Play();
        }
    }
}
