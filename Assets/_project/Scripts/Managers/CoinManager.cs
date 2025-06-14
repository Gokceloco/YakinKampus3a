using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public int coinCount;

    public void CoinCollected()
    {
        coinCount++;
    }
}
