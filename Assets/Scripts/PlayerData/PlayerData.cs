using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDate", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int BestScore { get; set; }
    public int CoinCount { get; set; }
}
