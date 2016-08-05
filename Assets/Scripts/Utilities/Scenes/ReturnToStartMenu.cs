using UnityEngine;

namespace Assets.Scripts.Utilities.Scenes
{
    public class ReturnToStartMenu : MonoBehaviour
    {
        // If Escape key is pressed, return to start menu
        void OnGUI()
        {
            var currentEvent = Event.current;

            if (currentEvent.type != EventType.KeyUp)
                return;

            if (currentEvent.keyCode == KeyCode.Escape)
                DevHelper.LevelLoader.GoToStartMenu();
        }
    }
}