using System;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class Room
    {
        public int Index { get; set; }
        public Vector2 Size { get; set; }
        public string Name { get; set; }
        public GameObject GameObject { get; set; }
    }

    public static class RoomExtensions
    {
        public static Room ToRoom(this GameObject gameObject)
        {
            if (gameObject == null)
            {
                Debug.LogError("[RoomExtensions.From] gameObject cannot be null!");
                throw new InvalidOperationException();
            }

            var room = new Room()
            {
                Size = gameObject.GetSize(),
                Name = gameObject.name,
                GameObject = MonoBehaviour.Instantiate(gameObject),
            };

            // rename the object after the instantation ('clone' added to the name)
            room.GameObject.SetName(room.Name);
            return room;
        }

        public static Vector2 GetSize(this GameObject gameObject)
        {
            return gameObject.GetComponent<SpriteRenderer>().bounds.size;
        }

        public static void SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
        }

        public static void SetPosition(this Room room, Vector2 newPosition)
        {
            room.GameObject.transform.position = newPosition;
        }

        public static void SetPosition(this GameObject gameObject, Vector2 newPosition)
        {
            gameObject.transform.position = newPosition;
        }

        public static void SetParent(this GameObject gameObject, GameObject parent)
        {
            gameObject.transform.parent = parent.transform;
        }
        
        public static Vector2 GetPosition(this Room room)
        {
            return room.GameObject.transform.position;
        }

        public static Vector2 GetLeftDoorPosition(this Room room)
        {
            var roomPosition = room.GetPosition();
            var leftDoorPosition = new Vector2(roomPosition.x - room.Size.x / 2, 0);
            return leftDoorPosition;
        }

        public static Vector2 GetRightDoorPosition(this Room room)
        {
            var roomPosition = room.GetPosition();
            var leftDoorPosition = new Vector2(roomPosition.x + room.Size.x / 2, 0);
            return leftDoorPosition;
        }
    }
}