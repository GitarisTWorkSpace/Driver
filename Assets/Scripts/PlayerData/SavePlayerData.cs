using Gameplay.Score;
using UnityEngine;

public class SavePlayerData : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;

    private void OnEnable()
    {
        LoadData();
        ScoreController.CoinAdd += SaveData;
        PlayerLoseController.PlayerLost += SaveData;
    }

    private void OnDisable()
    {
        SaveData();
        ScoreController.CoinAdd -= SaveData;
        PlayerLoseController.PlayerLost -= SaveData;
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt("BestScore", _playerData.BestScore);
        PlayerPrefs.SetInt("CoinCount", _playerData.CoinCount);
    }

    private void LoadData()
    {
        if (PlayerPrefs.HasKey("BestScore"))
            _playerData.BestScore = PlayerPrefs.GetInt("BestScore");
        else 
            _playerData.BestScore = 0;

        if (PlayerPrefs.HasKey("CoinCount"))
            _playerData.CoinCount = PlayerPrefs.GetInt("CoinCount");
        else 
            _playerData.CoinCount = 0;
    }
}
