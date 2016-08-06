using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Gameplay
{
    public interface IRoomsManager
    {
        void GenerateLevelVertically(List<GameObject> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms);
        void GenerateLevelHorizontally(List<GameObject> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms);
        List<Room> Rooms { get; }
    }

    public class RoomsManager : IRoomsManager
    {
        private readonly GameObject _corridorsContainer;
        private readonly Sprite _corridorSprite;
        private readonly GameObject _startRoomModel;
        private GameObject _startRoom;
        public List<Room> Rooms { get; private set; }

        public RoomsManager(GameObject corridorsContainer, Sprite corridorSprite, GameObject startRoom)
        {
            _corridorsContainer = corridorsContainer;
            _corridorSprite = corridorSprite;
            _startRoomModel = startRoom;
            Rooms = new List<Room>();
        }

        public void GenerateLevelHorizontally(List<GameObject> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms)
        {
            if (rooms == null || !rooms.Any())
            {
                Debug.LogError("[RoomsManager] At least one room must be selected!");
                throw new InvalidOperationException();
            }

            Rooms = rooms.Select(r => r.ToRoom()).ToList();

            GenerateRoomsHorizontally(Rooms, minDistanceBetweenRooms, maxDistanceBetweenRooms);
            DrawHorizontalCorridorsBetweenRooms(Rooms);
        }

        private void DrawHorizontalCorridorsBetweenRooms(List<Room> rooms)
        {
            var orderedRooms = rooms.OrderBy(r => r.Index).ToList();

            var startRoomDoor = _startRoom.transform.position + new Vector3(4, 3, 0);
            var firstRoomDoor = orderedRooms[0].GetLeftDoorPosition();

            GameObject lastCorridorDrawn = null;
            for (int x = (int) startRoomDoor.x; x < firstRoomDoor.x; x=x+5)
            {
                lastCorridorDrawn = DrawCorridor(new Vector2(x, 0));
            }

            var collider = lastCorridorDrawn.AddComponent<BoxCollider2D>();
            collider.isTrigger = true;

            for (int i = 0; i < orderedRooms.Count - 1; i++)
            {
                var startDoor = orderedRooms[i].GetRightDoorPosition();
                var endDoor = orderedRooms[i+1].GetLeftDoorPosition();

                for (int x = (int) startDoor.x; x <= endDoor.x+5; x=x+5)
                {
                    DrawCorridor(new Vector2(x, 0));
                }
            }
        }
        
        private void GenerateRoomsHorizontally(List<Room> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms)
        {
            var seed = DateTime.Now.Millisecond;
            var roomRandomizer = new Random(seed);
            var randomizedRooms = rooms.OrderBy(room => roomRandomizer.Next()).ToList();

            var nextRoomPosition = new Vector2(0, 0);
            var roomIndex = 1;

            CreateStartRoom();

            foreach (var room in randomizedRooms)
            {
                room.SetPosition(new Vector2(nextRoomPosition.x + room.Size.x / 2, 0));
                room.Index = roomIndex;
                roomIndex++;

                // Calculate position for the next room
                var randomDistanceBetweenRooms = roomRandomizer.Next(minDistanceBetweenRooms, maxDistanceBetweenRooms);
                nextRoomPosition = new Vector2(room.GetPosition().x + randomDistanceBetweenRooms, 0);
            }
        }

        private void CreateStartRoom()
        {
            _startRoom = MonoBehaviour.Instantiate(_startRoomModel);
            _startRoom.SetName(GameplayServices.Constants.StartRoom);
            _startRoom.SetPosition(new Vector2(-30, -3));

            SpawnPlayer();
        }

        private GameObject DrawCorridor(Vector2 corridorPosition)
        {
            var corridor = new GameObject();
            corridor.SetName("corridor");
            corridor.SetPosition(corridorPosition);
            corridor.SetParent(_corridorsContainer);

            var spriteRenderer = corridor.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _corridorSprite;
            spriteRenderer.sortingOrder = -2;

            return corridor;
        }

        private void SpawnPlayer()
        {
            var playerModel = Resources.Load<GameObject>("Player/player_test");
            var player = MonoBehaviour.Instantiate(playerModel);
            player.SetPosition(new Vector2(_startRoom.transform.position.x -2, _startRoom.transform.position.y + 2));
            player.SetName(GameplayServices.Constants.PlayerName);
        }

        #region Vertical
        public void GenerateLevelVertically(List<GameObject> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms)
        {
            if (rooms == null || !rooms.Any())
            {
                Debug.LogError("[RoomsManager] At least one room must be selected!");
                throw new InvalidOperationException();
            }

            Rooms = rooms.Select(r => r.ToRoom()).ToList();

            GenerateRoomsVertically(Rooms, minDistanceBetweenRooms, maxDistanceBetweenRooms);
        }

        private void GenerateRoomsVertically(List<Room> rooms, int minDistanceBetweenRooms, int maxDistanceBetweenRooms)
        {
            var seed = DateTime.Now.Millisecond;
            var roomRandomizer = new Random(seed);
            var randomizedRooms = rooms.OrderBy(room => roomRandomizer.Next()).ToList();

            var nextRoomPosition = new Vector2(0, 0);

            foreach (var room in randomizedRooms)
            {
                room.SetPosition(new Vector2(0, nextRoomPosition.y + room.Size.y/2));

                // Calculate position for the next room
                var randomDistanceBetweenRooms = roomRandomizer.Next(minDistanceBetweenRooms, maxDistanceBetweenRooms);
                nextRoomPosition = new Vector2(0, room.GetPosition().y + randomDistanceBetweenRooms);
            }
        }
        #endregion Vertical
    }
}