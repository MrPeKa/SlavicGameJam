using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GenerateLevel : MonoBehaviour
    {
        public GameObject[] Rooms;

        public List<GameObject> GetRooms()
        {
            if (Rooms == null || Rooms.Length < 1)
            {
                Debug.LogError("[RoomsList] At least one room must be selected!");
                throw new InvalidOperationException();
            }

            return Rooms.ToList();
        }
    }
}