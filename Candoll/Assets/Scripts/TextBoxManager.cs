using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {


    public GameObject textBox;
    public Text theText;

    public int currentLine;
    public int endAtLine;

    //public PlayerController player;

    public TextAsset textFile;
    public string[] textLines;

    // Use this for initialization
    void Start()
    {

        //player = FindObjectOfType<PlayerController>();
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;

        }
   
    }

    void Update()
    {
        theText.text = textLines[currentLine];

        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
        }

        if (currentLine <= endAtLine)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentLine++;
            }
        }

    }

}
