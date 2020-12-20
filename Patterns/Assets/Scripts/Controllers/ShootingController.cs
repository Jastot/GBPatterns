namespace PatternsChudakovGA
{
    public sealed class ShootingController: IExecute, ICleanData
    {
       

        private readonly GameContext _gamePoolContext;

        private readonly IInputButton _fireInput;
        private readonly BulletPool _bulletPool;
        private readonly GameContext _gameContext;
        private BulletInitialization _bulletInitialization;

        private bool _isFire;
        public ShootingController(IInputButton fireInput, BulletPool bulletPool,GameContext gameContext)
        {
            _fireInput = fireInput;
            _bulletPool = bulletPool;
            _gameContext = gameContext;
            _fireInput.AxisOnChange += FireAxisOnChange;
            _bulletInitialization = new BulletInitialization(_bulletPool,_gameContext);
        }

        public void Execute(float deltaTime)
        {
            
            if (_isFire == true)
            {
                var speed = deltaTime * 20;
                            //_gamePoolContext.BulletModels[0].BulletStruct.Speed;
                _bulletInitialization.Initialize(speed);
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