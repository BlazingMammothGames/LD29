using UnityEngine;
using System.Collections;

public class CostumeBuilder : MonoBehaviour {
    public enum Gender { MALE, FEMALE };
    public enum HairColour { RED, BROWN, BLACK, BLONDE, GREY };
    public enum SkinColour { WHITE, BLACK };
    public enum Clothing { CASUAL, SUIT };

    public Gender gender = Gender.MALE;
    public HairColour hairColour = HairColour.BROWN;
    public SkinColour skinColour = SkinColour.WHITE;
    public Clothing clothing = Clothing.SUIT;

    public tk2dSprite clothesSprite;
    public tk2dSprite skinSprite;
    public tk2dSprite hairSprite;

    private CharacterAnimator characterAnimator;

    void Awake()
    {
        characterAnimator = GetComponent<CharacterAnimator>();
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
        }

        clothesSprite.SetSprite(genderStr + " clothes " + clothesStr + "/" + characterAnimator.animationFrame);
        skinSprite.SetSprite(genderStr + " skin " + skinStr + "/" + characterAnimator.animationFrame);
        hairSprite.SetSprite(genderStr + " hair " + hairStr + "/" + characterAnimator.animationFrame);
    }
}
