using UnityEngine;
using System.Collections.Generic;

namespace SuperVeigar
{
    public class CoinSpawnService : SingletonBehaviour<CoinSpawnService>
    {
        [SerializeField]
        private Transform coinParent;
        private List<Coin> coins;
        [SerializeField]
        private GameObject[] coinPrefabs;

        private void Start()
        {
            InitCoin();
        }

        public void InitCoin()
        {
            coins = new List<Coin>();
        }

        public void SpawnCoin(CoinType type, Vector3 position)
        {
            Coin coin = GetCoin(type);

            coin.transform.position = position;
            coin.gameObject.SetActive(true);
        }

        private Coin GetCoin(CoinType type)
        {
            Coin coin = null;

            for (int i = 0; i < coins.Count; i++)
            {
                coin = coins[i];
                if (coin.data.type == type && coin.gameObject.activeInHierarchy == false)
                {
                    return coin;
                }
            }

            coin = Instantiate(coinPrefabs[(int)type], Vector3.zero, Quaternion.identity, coinParent).GetComponent<Coin>();

            coins.Add(coin);

            return coin;
        }
    }
}
