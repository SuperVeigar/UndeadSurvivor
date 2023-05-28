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

        public void SetCharacter(PlayerType type, out CharacterData data)
        {
            switch (type)
            {
                default:
                case PlayerType.PLAYER_CS:
                    spriteLibrary.spriteLibraryAsset = cs;
                    data = new CharacterDataCS();
                    break;
                case PlayerType.PLAYER_YH:
                    spriteLibrary.spriteLibraryAsset = yh;
                    data = new CharacterDataYH();
                    break;
                case PlayerType.PLAYER_MH:
                    spriteLibrary.spriteLibraryAsset = mh;
                    data = new CharacterDataMH();
                    break;
                case PlayerType.PLAYER_SJ:
                    spriteLibrary.spriteLibraryAsset = sj;
                    data = new CharacterDataSJ();
                    break;
            }

            data.Init();
        }
    }
}


