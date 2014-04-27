using UnityEngine;
using System.Collections;

public class CostumeBuilder : MonoBehaviour {
    public enum Gender { MALE, FEMALE };
    public enum HairColour { RED, BROWN, BLACK, BLONDE, GREY, BALD };
    public enum SkinColour { WHITE, BLACK };
    public enum Clothing { CASUAL, SUIT };

    public KinematicBody.FacingDirection previewDirection = KinematicBody.FacingDirection.RIGHT;
    public Gender gender = Gender.MALE;
    public HairColour hairColour = HairColour.BROWN;
    public SkinColour skinColour = SkinColour.WHITE;
    public Clothing clothing = Clothing.SUIT;

    public tk2dSprite clothesSprite;
    public tk2dSprite skinSprite;
    public tk2dSprite hairSprite;

    private CharacterAnimator characterAnimator;
    public int animationFrame = 4;

    void Awake()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
    }

    public void EditorUpdate()
    {
        switch (previewDirection)
        {
            case KinematicBody.FacingDirection.RIGHT:
                animationFrame = 4;
                SetFlip(false);
                break;

            case KinematicBody.FacingDirection.DOWN:
                animationFrame = 6;
                break;

            case KinematicBody.FacingDirection.LEFT:
                animationFrame = 4;
                SetFlip(true);
                break;

            case KinematicBody.FacingDirection.UP:
                animationFrame = 1;
                break;
        }

        this.Update();
    }

    void Update()
    {
        string genderStr = gender == Gender.MALE ? "man" : "woman";
        string clothesStr = clothing == Clothing.CASUAL ? "casual" : "suit";
        string skinStr = skinColour == SkinColour.WHITE ? "white" : "black";
        string hairStr = "red";
        switch (hairColour)
        {
            case HairColour.BLACK:
                hairStr = "black";
                break;

            case HairColour.BROWN:
                hairStr = "brown";
                break;

            case HairColour.BLONDE:
                hairStr = "blonde";
                break;

            case HairColour.GREY:
                hairStr = "grey";
                break;

            case HairColour.BALD:
                hairStr = "bald";
                break;
        }

        if (characterAnimator != null)
            animationFrame = characterAnimator.animationFrame;
        clothesSprite.SetSprite(genderStr + " clothes " + clothesStr + "/" + animationFrame);
        skinSprite.SetSprite(genderStr + " skin " + skinStr + "/" + animationFrame);
        hairSprite.SetSprite(genderStr + " hair " + hairStr + "/" + animationFrame);
    }

    public void SetFlip(bool left)
    {
        clothesSprite.FlipX = left;
        skinSprite.FlipX = left;
        hairSprite.FlipX = left;
    }
}
