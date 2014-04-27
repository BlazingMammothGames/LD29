using UnityEngine;
using System.Collections;

public class TriggerSpeech : MonoBehaviour {
    public string text;
    public bool destroyOnDone = true;
    public string playerTag = "Player";
    public bool randomizeTexts = false;

    private int textIndex = 0;
    private string[] texts;
    private tk2dSlicedSprite speechBubble;
    private tk2dTextMesh textMesh;
    private PlayerControl playerControl = null;
    private TextAdvancer textAdvancer = null;
    private bool showingText = false;
    private bool waitingForExit = false;

    void Awake()
    {
        speechBubble = transform.parent.parent.GetComponentInChildren<tk2dSlicedSprite>();
        textMesh = transform.parent.parent.GetComponentInChildren<tk2dTextMesh>();

        speechBubble.renderer.enabled = false;
        textMesh.renderer.enabled = false;

        texts = text.Split(new string[] { "\n\n" }, System.StringSplitOptions.RemoveEmptyEntries);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (waitingForExit || showingText)
            return;

        if (randomizeTexts)
            textIndex = Random.Range(0, texts.Length - 1);

        if (other.CompareTag(playerTag))
        {
            playerControl = other.GetComponent<PlayerControl>();
            playerControl.freezeInput = true;
            speechBubble.renderer.enabled = true;
            textMesh.renderer.enabled = true;

            textMesh.text = texts[textIndex].Trim();
            int nLines = texts[textIndex].Trim().Split('\n').Length;
            speechBubble.dimensions = new Vector2(speechBubble.dimensions.x, 8 + (8 * nLines));

            showingText = true;
            textAdvancer = other.GetComponent<TextAdvancer>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Trigger exit");
        if (!other.CompareTag(playerTag))
            return;

        Debug.Log("Player left!");
        waitingForExit = false;
    }

    void Update()
    {
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
                    speechBubble.renderer.enabled = false;
                    textMesh.renderer.enabled = false;

                    if (destroyOnDone)
                    {
                        Debug.Log("Destroying..");
                        DestroyObject(this.gameObject);
                    }
                    else
                    {
                        Debug.Log("Waiting for player to exit...");
                        textIndex = 0;
                        waitingForExit = true;
                    }
                }
                else
                {
                    textMesh.text = texts[textIndex].Trim();
                    int nLines = texts[textIndex].Trim().Split('\n').Length;
                    speechBubble.dimensions = new Vector2(speechBubble.dimensions.x, 8 + (8 * nLines));
                }
            }
        }
    }
}
