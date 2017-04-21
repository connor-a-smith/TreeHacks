using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockGameController : MonoBehaviour {

    private bool isTextActive;
    private bool isVoiceActive;

    private BlockColor desiredColor;
    private BlockShape desiredShape;

    private Text MonitorText;
    private AudioSource speaker;

    public Transform blockSpawnPosition;
    public GameObject blockPrefab;

    private GameObject[] blocks = new GameObject[3];
	// Use this for initialization
	void Start () {
        StartNewRound();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartNewRound()
    {
        for (int i = 0; i < 3; i++)
        {
            //Destroy old round blocks.
            Destroy(blocks[i]);
            blocks[i] = GameObject.Instantiate(blockPrefab, blockSpawnPosition.position + new Vector3(0, 0, .5f * i), Quaternion.identity);
            blocks[i].GetComponent<BlockProperties>().InitBlock();
        }

        int randomBlockIndex = Random.Range(0, blocks.Length);

        desiredColor = blocks[randomBlockIndex].GetComponent<BlockProperties>().color;
        
        //All same color.
        //All same shape.
        //Only voice for instructions.
        //Only text for instructions.
    }

    private void OnTriggerEnter(Collider other)
    {
        BlockProperties properties = other.gameObject.GetComponent<BlockProperties>();
        if (properties != null)
        {
            //Win
            if (properties.color == desiredColor)
            {
                GetComponentInChildren<ParticleSystem>().Play();

            }

            //Lose
            else
            {

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
