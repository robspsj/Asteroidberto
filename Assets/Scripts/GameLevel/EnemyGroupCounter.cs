using System.Collections.Generic;
using GameLevel;
using UnityEngine;

namespace Asteroidsberto.GameLevel
{
    public class EnemyGroupCounter : MonoBehaviour
    {
        [SerializeField] private GameLevelState _gameLevelState; 
        private readonly List<EnemyGroupElement> _enemyGroupElements = new();
        private Camera _camera;

        public void RegisterObject(EnemyGroupElement spaceObject)
        {
            _enemyGroupElements.Add(spaceObject);
            _gameLevelState.EnemyCount = _enemyGroupElements.Count;
        }

        public void DeregisterObject(EnemyGroupElement spaceObject)
        {
            _enemyGroupElements.Remove(spaceObject);
            _gameLevelState.EnemyCount = _enemyGroupElements.Count;
        }
    }
}