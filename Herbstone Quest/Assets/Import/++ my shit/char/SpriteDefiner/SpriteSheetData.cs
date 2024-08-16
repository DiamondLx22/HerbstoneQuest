using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Sprite Sheet Data", menuName = "Custom/Sprite Sheet Data")]
public class SpriteSheetData : ScriptableObject
{
    public int id;
    public Texture2D spriteSheetTexture; // Reference to the sprite sheet texture
}
