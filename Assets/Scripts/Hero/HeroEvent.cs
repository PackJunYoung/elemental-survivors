using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class HeroEvent
{
    public class OnMoveUpdate
    {
        public Vector3 Position { get; private set; }

        private static readonly OnMoveUpdate INSTANCE = new OnMoveUpdate();

        public static void Publish(Vector3 position)
        {
            INSTANCE.Position = position;
            MessageBroker.Default.Publish(INSTANCE);
        }
    }
}
