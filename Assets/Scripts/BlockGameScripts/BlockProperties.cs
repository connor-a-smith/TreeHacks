using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockColor
{
    Green, Red, Brown, Blue, Purple, Yellow, Gray, Black
};

public enum BlockShape
{
    Cube, Sphere, Cylinder
};

public class BlockProperties : MonoBehaviour {
    
    public BlockColor color;
    public BlockShape shape;

    private static Shader standardShader;

	// Use this for initialization
	void Start () {
        //Set the standard shader only once.
        if (!standardShader)
        {
            standardShader = Shader.Find("Standard");
        }
    }

    public void InitBlock()
    {
        RandomizeColor();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void RandomizeColor()
    {
        //Pick a random enum.
        color = (BlockColor) Random.Range(0, System.Enum.GetNames(typeof(BlockColor)).Length);

        Color matColor;

        //Set the color.
        switch (color)
        {
            case BlockColor.Green:
                matColor = Color.green;
                break;
            case BlockColor.Red:
                matColor = Color.red;
                break;
            case BlockColor.Brown:
                matColor = new Color(.71f, .396f, .114f);
                break;
            case BlockColor.Blue:
                matColor = Color.blue;
                break;
            case BlockColor.Purple:
                matColor = new Color(.33f, .1f, 0.54f);
                break;
            case BlockColor.Yellow:
                matColor = Color.yellow;
                break;
            case BlockColor.Gray:
                matColor = Color.gray;
                break;
            case BlockColor.Black:
                matColor = Color.black;
                break;
            default:
                //Debug color
                matColor = Color.cyan;
                break;
        }
        Material mat = new Material(Shader.Find("Standard"));

        mat.SetColor("_Color", matColor);

        GetComponent<Renderer>().material = mat;
    }
}
