﻿using System;

namespace KLASSEN_INF21
{
    [Serializable]
    public class Event
    {
        private ushort _eventDay;
        private ushort _maxNumberOfParticipants;

        public Event(ushort eventDay, ushort maxNumberOfParticipants)
        {
            _eventDay = eventDay;
            _maxNumberOfParticipants = maxNumberOfParticipants;
        }
    }
}