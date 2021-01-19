namespace PatternsChudakovGA
{
    public sealed class ShootingController: IExecute, ICleanData
    {
       

        private readonly GameContext _gamePoolContext;

        private readonly IInputButton _fireInput;
        private readonly BulletPool _bulletPool;
        private readonly GameContext _gameContext;
        private readonly BulletLifeController _bulletLifeController;
        private BulletInitialization _bulletInitialization;

        private bool _isFire;
        public ShootingController(IInputButton fireInput, BulletPool bulletPool,
            GameContext gameContext,BulletLifeController bulletLifeController)
        {
            _fireInput = fireInput;
            _bulletPool = bulletPool;
            _gameContext = gameContext;
            _bulletLifeController = bulletLifeController;
            _fireInput.AxisOnChange += FireAxisOnChange;
            _bulletInitialization = new BulletInitialization(_bulletPool,_gameContext,_bulletLifeController);
        }

        public void Execute(float deltaTime)
        {
            
            if (_isFire == true)
            {
                _bulletInitialization.Initialize();
            }
        }

        public void CleanData()
        {
           
        }
        
        private void FireAxisOnChange(bool value)
        {
            _isFire = value;
        }
    }
}