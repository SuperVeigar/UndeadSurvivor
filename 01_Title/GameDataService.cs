namespace SuperVeigar
{
    public class GameDataService : SingletonBehaviour<GameDataService>
    {
        public PlayerType playerType;
        public WeaponType weaponType;
        public SecondWeaponType secondWeaponType;
        
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
