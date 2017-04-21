using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGameController : MonoBehaviour {

    private bool isTextActive;
    private bool isVoiceActive;

    private BlockColor desiredColor;
    private BlockShape desiredShape;

    private AudioSource speaker;

    public Transform blockSpawnPosition;
    public GameObject blockPrefab;
    public Text monitorText;

    private AudioSource source;
    public AudioClip goodClip;
    public AudioClip badClip;

    private GameObject[] blocks = new GameObject[3];
    private bool isGameActive = false;

	// Use this for initialization
	void Start () {
        StartNewRound();
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNewRound()
    {
        isGameActive = true;

        for (int i = 0; i < 3; i++)
        {
            //Destroy old round blocks.
            Destroy(blocks[i]);
            blocks[i] = GameObject.Instantiate(blockPrefab, blockSpawnPosition.position + new Vector3(0, 0, .3f * i), Quaternion.identity);
            blocks[i].GetComponent<BlockProperties>().InitBlock();
        }

        int randomBlockIndex = Random.Range(0, blocks.Length);

        desiredColor = blocks[randomBlockIndex].GetComponent<BlockProperties>().color;

        monitorText.text = "Place a " + desiredColor.ToString() + " cube in the container";
        
        //All same color.
        //All same shape.
        //Only voice for instructions.
        //Only text for instructions.
    }

    private void OnTriggerEnter(Collider other)
    {
        BlockProperties properties = other.gameObject.GetComponent<BlockProperties>();
        if (properties != null && isGameActive)
        {
            isGameActive = false;

            //Win
            if (properties.color == desiredColor)
            {
                monitorText.text = "Good!";

                GetComponentInChildren<ParticleSystem>().Play();

                source.clip = goodClip;
                source.Play();

            }

            //Lose
            else
            {
                monitorText.text = "Incorrect, you placed a " + properties.color.ToString() + " block";

                source.clip = badClip;
                source.Play();
            }

            StartCoroutine(StartNewRoundSoon());
        }
    }

    public IEnumerator StartNewRoundSoon()
    {
        yield return new WaitForSeconds(2.0f);
        StartNewRound();
    }
}
