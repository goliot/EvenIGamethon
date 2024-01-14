using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Object/ItemData")]
public class CardData : ScriptableObject
{
    public enum CardType { MagicBolt, Boom, Aqua, Lumos, Exo, Momen, Fines}

    [Header("# Main Info")] // 
    public CardType cardType;
    public int cardId; // 카드의 ID
    public string cardName; // 카드 이름
    public string cardDesc; // 아이템 설명
    public Sprite cardIcon; // 아이템의 UI를 담기위한 아이콘

    [Header("# Level Data")]
    public float baseDamage;  // 0레벨 기준 기본 공격력
    public int baseCount;     // 0레벨 기준 개수
    public float[] damages;
    public int[] counts;

    [Header("# Weapon?")] // 명칭 변경 추후 필요
    public GameObject projectiles; // 투사체

}
