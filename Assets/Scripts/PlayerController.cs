using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Stick m_stick;

        [SerializeField] private Button m_button;

        [SerializeField] private EventTrigger m_hitButton;

        private bool is_Down;

        private void Start()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryUp.callback.AddListener(OnPointerUp);
            entryDown.callback.AddListener(OnPointerDown);

            m_hitButton.triggers.Add(entryDown);
            m_hitButton.triggers.Add(entryUp);

        }

        private void OnPointerUp(BaseEventData arg0)
        {
            Up();
        }

        private void OnPointerDown(BaseEventData arg0)
        {
            Down();
        }

        private void Update()
        {
            if (is_Down)
            {
                m_stick.Down();
            }
            else
            {
                m_stick.Up();
            }
        }
        private void Down()
        {
            is_Down = true;
        }
        private void Up()
        {
            is_Down = false;
        }
    }
}

