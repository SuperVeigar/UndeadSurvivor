namespace SuperVeigar
{
    public class GameDataService : SingletonBehaviour<GameDataService>
    {
        public PlayerType playerType;
        public WeaponType weaponType;
        public SecondWeaponType secondWeaponType;
        public CharacterData playerData;
        public WeaponData weaponData;
                
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
