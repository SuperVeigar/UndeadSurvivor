using UnityEngine;

namespace SuperVeigar
{
    public enum CoinType
    {
        Normal = 0,
        Special,
        UltruSuperHyperSpecial
    }

    public class Coin : MonoBehaviour, ICollectable
    {
        public CoinData data;

        public void Collect(CharacterData data)
        {
            if (GameService.Instance.IsPlay() == true)
            {
                GameSoundService.Instance.Play(GameSoundType.Coin);

                data.AddEXP(this.data.exp);

                gameObject.SetActive(false);
            }
        }
    }
}

