using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDate", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int BestScore { get; set; }
    public int CoinCount { get; set; }

    public int[] IndexCarPlayerHave = new int[3];

    public int CurrenCarIndex { get; set; }
}
