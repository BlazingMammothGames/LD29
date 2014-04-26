using UnityEngine;
using System.Collections;

public class CharacterAnimator : MonoBehaviour {
    private KinematicBody body;
    private CostumeBuilder costumeBuilder;

    public int animationOffset = 1;
    public bool playForward = true;
    public int animationFrame = 4;
    public float frameRate = 8;
    private float framePeriod { get { return 1 / frameRate; } }
    private float lastFrameTime = -1;

    void Awake()
    {
        body = GetComponent<KinematicBody>();
        costumeBuilder = GetComponent<CostumeBuilder>();
    }

    void Start()
    {
        lastFrameTime = -1;
    }

    void Update()
    {
        int animationBase = 3;
        switch (body.facingDirection)
        {
            case KinematicBody.FacingDirection.UP:
                animationBase = 0;
                break;

            case KinematicBody.FacingDirection.RIGHT:
                animationBase = 3;
                SetFlip(false);
                break;

            case KinematicBody.FacingDirection.DOWN:
                animationBase = 6;
                break;

            case KinematicBody.FacingDirection.LEFT:
                animationBase = 3;
                SetFlip(true);
                break;
        }

        if (body.velocity.sqrMagnitude > 0)
        {
            if (lastFrameTime < 0)
            {
                lastFrameTime = Time.time;
                animationOffset = 2;
            }
            else
            {
                if (Time.time - lastFrameTime >= framePeriod)
                {
                    lastFrameTime = Time.time;
                    animationOffset += playForward ? 1 : -1;
                    if (animationOffset > 2)
                    {
                        animationOffset = 1;
                        playForward = false;
                    }
                    else if (animationOffset < 0)
                    {
                        animationOffset = 1;
                        playForward = true;
                    }
                }
            }
        }
        else
        {
            lastFrameTime = -1;
            animationOffset = 1;
            playForward = true;
        }

        animationFrame = animationBase + animationOffset;
    }

    public void SetFlip(bool left)
    {
        costumeBuilder.clothesSprite.FlipX = left;
        costumeBuilder.skinSprite.FlipX = left;
        costumeBuilder.hairSprite.FlipX = left;
    }
}
