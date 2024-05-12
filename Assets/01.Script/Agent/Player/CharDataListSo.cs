using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

[Serializable]
public struct Character
{
    public GunDataSo gun;
    public SpriteLibraryAsset spritePack;
}
[CreateAssetMenu(menuName = "SO/CharacterDatas")]
public class CharDataListSo : ScriptableObject
{
    public List<Character> dataList;
}
