using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GenerateLevel : MonoBehaviour
    {
        [Tooltip("List of rooms the level will be composed of.")]
        public GameObject[] Rooms;
        public Sprite MainCorridorSprite;
        public GameObject CorridorsContainer;

        [Header("Generation Parameters")]
        public bool VerticalLevel;
        public int MinDistanceBetweenRooms;
        public int MaxDistanceBetweenRooms;

        private IRoomsManager _roomsManager;

        void Start()
        {
            _roomsManager = new RoomsManager(CorridorsContainer, MainCorridorSprite);

            if (VerticalLevel)
                _roomsManager.GenerateLevelVertically(GetRooms(), MinDistanceBetweenRooms, MaxDistanceBetweenRooms);
            else
                _roomsManager.GenerateLevelHorizontally(GetRooms(), MinDistanceBetweenRooms, MaxDistanceBetweenRooms);
        }
        
        private List<GameObject> GetRooms()
        {
            if (Rooms == null || !Rooms.Any())
            {
                Debug.LogError("[RoomsList] At least one room must be selected!");
                throw new InvalidOperationException();
            }

            return Rooms.ToList();
        }
    }
}