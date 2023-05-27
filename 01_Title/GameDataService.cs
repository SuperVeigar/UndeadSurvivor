namespace SuperVeigar
{
    public class GameDataService : SingletonBehaviour<GameDataService>
    {
        public PlayerType playerType;
        
        private void Start()
        {
            DontDestroyOnLoad(this);
        }
    }
}
