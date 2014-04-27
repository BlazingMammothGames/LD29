using UnityEngine;
using System.Collections;

public class SpeechController : MonoBehaviour
{
    [Multiline]
    public string text;
    public bool destroyOnDone = false;
    public string playerTag = "Player";
    public bool randomizeTexts = true;

    private int textIndex = 0;
    private string[] texts;
    private GameObject speech;
    private tk2dSlicedSprite speechBubble;
    private tk2dTextMesh textMesh;
    private PlayerControl playerControl = null;
    private TextAdvancer textAdvancer = null;
    private bool showingText = false;
    private bool skipUpdate = false;

    void Awake()
    {
        speech = transform.FindChild("SpeechBubble").gameObject;

        speechBubble = speech.GetComponentInChildren<tk2dSlicedSprite>();
        textMesh = speech.GetComponentInChildren<tk2dTextMesh>();

        speech.SetActive(false);
        UpdateTexts(text);
    }

    public void UpdateTexts(string txt)
    {
        text = txt;
        texts = text.Split(new string[] { "\n\n" }, System.StringSplitOptions.RemoveEmptyEntries);
    }

    public void StartSpeech(GameObject initiator)
    {
        if (showingText)
        {
            return;
        }

        if (randomizeTexts)
        {
            textIndex = Random.Range(0, texts.Length - 1);
        }

        if (initiator.CompareTag(playerTag))
        {
            playerControl = initiator.GetComponent<PlayerControl>();
            playerControl.freezeInput = true;
            speech.SetActive(true);

            showingText = true;
            skipUpdate = true;
            textAdvancer = initiator.GetComponent<TextAdvancer>();

            DrawText();
        }
        else
        {
            Debug.LogWarning("Can't do speech - not a player!");
        }
    }

    void DrawText()
    {
        string currentText = texts[textIndex].Trim();
        string formattedText = textMesh.FormatText(currentText).Trim();
        textMesh.text = formattedText;
        int nLines = formattedText.Split('\n').Length;
        speechBubble.dimensions = new Vector2(speechBubble.dimensions.x, 8 + (8 * nLines));
    }

    void Update()
    {
        if (skipUpdate)
        {
            skipUpdate = false;
            return;
        }

        if (showingText)
        {
            if (textAdvancer.ShouldTextBeAdvanced())
            {
                if (!randomizeTexts)
                    textIndex++;
                else
                    textIndex = texts.Length;

                if (textIndex >= texts.Length)
                {
                    playerControl.freezeInput = false;
                    speech.SetActive(false);
                    showingText = false;

                    if (destroyOnDone)
                    {
                        //DestroyObject(this.gameObject);
                        Destroy(this);
                    }
                    else
                    {
                        textIndex = 0;
                    }
                }
                else
                {
                    DrawText();
                }
            }
        }
    }
}
