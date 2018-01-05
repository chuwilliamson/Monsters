using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Jeremy
{
    public struct Pos
    {
        public int x;
        public int y;
    }

    public class ContainerSlot
    {
        // fields
        public Pos position;

        // methods
        public ContainerSlot(int posX, int posY)
        {
            position.x = posX;
            position.y = posY;
        }
    }

    public class Container
    {
        // fields
        public int width;
        public int length;
        public List<ContainerSlot> slots;
        public List<Item> contents;

        // methods
        public Container(int w, int l)
        {
            width = w;
            length = l;
            slots = new List<ContainerSlot>();
            contents = new List<Item>();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    slots.Add(new ContainerSlot(i, j));
                }
            }
        }        
    }

    public class Item
    {
        // fields
        public string name;

        // methods
        public Item()
        {

        }
    }
}

