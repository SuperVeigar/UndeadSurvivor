using UnityEngine;
using UnityEngine.U2D.Animation;
namespace SuperVeigar
{
    public enum PlayerType
    {
        PLAYER_CS = 0,
        PLAYER_YH,
        PLAYER_MH,
        PLAYER_SJ,
    }

    public class PlayerSelector : MonoBehaviour
    {
        public SpriteLibraryAsset cs;
        public SpriteLibraryAsset yh;
        public SpriteLibraryAsset mh;
        public SpriteLibraryAsset sj;
        public SpriteLibrary spriteLibrary;

        public void SetCharacter(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.PLAYER_CS:
                    spriteLibrary.spriteLibraryAsset = cs;
                    break;
                case PlayerType.PLAYER_YH:
                    spriteLibrary.spriteLibraryAsset = yh;
                    break;
                case PlayerType.PLAYER_MH:
                    spriteLibrary.spriteLibraryAsset = mh;
                    break;
                case PlayerType.PLAYER_SJ:
                    spriteLibrary.spriteLibraryAsset = sj;
                    break;
            }
        }

        public CharacterData GetCharacterData(PlayerType type)
        {
            switch (type)
            {
                case PlayerType.PLAYER_CS:
                    return new CharacterDataCS();
                case PlayerType.PLAYER_YH:
                    return new CharacterDataYH();
                case PlayerType.PLAYER_MH:
                    return new CharacterDataMH();
                case PlayerType.PLAYER_SJ:
                    return new CharacterDataSJ();
                default:
                    return null;
            }
        }
    }
}


