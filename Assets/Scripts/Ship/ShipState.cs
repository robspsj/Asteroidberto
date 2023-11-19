using UnityEngine;

namespace Asteroidsberto.Ship
{
    public delegate void ShipBoosterStateChange(
        ShipState.BoosterState previousState,
        ShipState.BoosterState newState);
    
    public delegate void ShipTurningStateChange(
        ShipState.TurningState previousState,
        ShipState.TurningState newState);

    public delegate void OnShipShoot();

    public delegate void OnShipGotHit();

    public class ShipState : MonoBehaviour
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
        public event OnShipGotHit OnShipGotHit;

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

        public void GetHit()
        {
            OnShipGotHit?.Invoke();
        }
    }
}