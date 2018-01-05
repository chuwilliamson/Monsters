using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeremy
{
    public class ContainerBehaviour : MonoBehaviour
    {
        // fields
        public Container container;

        // Unity methods
        void Start()
        {
            container = new Container(4, 4);

            foreach (ContainerSlot s in container.slots)
            {

            }
        }

        void Update()
        {

        }
    }
}
