using UnityEngine;

namespace Asteroidsberto.Ship
{
    public delegate void ShipBoosterStateChange(
        ShipStateController.BoosterState previousState,
        ShipStateController.BoosterState newState);
    
    public delegate void ShipTurningStateChange(
        ShipStateController.TurningState previousState,
        ShipStateController.TurningState newState);

    public delegate void OnShipShoot();

    public class ShipStateController : MonoBehaviour
    {
        public enum BoosterState
        {
            Off,
            On
        }
        
        public enum TurningState
        {
            NotTurning,
            Left,
            Right
        }

        

        public event ShipBoosterStateChange OnShipBoosterStateChange;
        public event ShipTurningStateChange OnShipTurningStateChange;
        public event OnShipShoot OnShipShoot;

        public void ShootTrigger()
        {
            OnShipShoot?.Invoke();
        }
        
        private BoosterState _currentBoosterState = BoosterState.Off;
        public BoosterState CurrentBoosterState
        {
            set
            {
                if (_currentBoosterState == value) return;
                
                var previousState = _currentBoosterState;
                _currentBoosterState = value;
                OnShipBoosterStateChange?.Invoke(previousState, value);
            }
            get => _currentBoosterState;
        }
        
        private TurningState _currentTurningState = TurningState.NotTurning;
        public TurningState CurrentTurningState
        {
            set
            {
                if (_currentTurningState == value) return;
                
                var previousState = _currentTurningState;
                _currentTurningState = value;
                OnShipTurningStateChange?.Invoke(previousState, value);
            }
            get => _currentTurningState;
        }
    }
}