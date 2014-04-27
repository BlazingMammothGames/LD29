using UnityEngine;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class TypeAtComputer : MonoBehaviour {
    [Multiline]
    public string codeToType;
    int wordI = 0;
    private List<string> codeWords = new List<string>();

    private tk2dTextMesh textMesh;
    public GameObject speechBubble;
    public GameObject player, computer;
    private float timeCompleted = 0;
    public float timeOut = 2;

    void Awake()
    {
        textMesh = GetComponent<tk2dTextMesh>();

        // now tokenize the code
        string[] cWords = Regex.Split(codeToType, @"(?<=[\s+])");
        string whitespaceBuffer = "";
        for (int i = 0; i < cWords.Length; i++)
        {
            if (cWords[i] == " " || cWords[i] == "\t")
                whitespaceBuffer += cWords[i];
            else
            {
                if (whitespaceBuffer.Length > 0)
                {
                    codeWords.Add(whitespaceBuffer + cWords[i]);
                    whitespaceBuffer = "";
                }
                else
                {
                    codeWords.Add(cWords[i]);
                }
            }
        }
        if (whitespaceBuffer.Length > 0)
            codeWords.Add(whitespaceBuffer);
        //codeWords = new List<string>(cWords);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X)) && wordI < codeWords.Count)
        {
            // next letter
            textMesh.text += codeWords[wordI];
            wordI++;

            if (wordI >= codeWords.Count)
            {
                timeCompleted = Time.time;
                speechBubble.SetActive(true);
            }
        }

        if (wordI >= codeWords.Count && (Time.time - timeCompleted) > timeOut && Input.GetKeyUp(KeyCode.X))
        {
            player.SetActive(true);
            player.GetComponent<TaskList>().CompleteTask("Program computer");
            computer.SetActive(false);
        }
    }
}
