﻿namespace BoardGameLibrary.Component.MageKnight
{
    public class Cards
    {
        public string Name { get; }
        public Characteristic Characteristics { get; }
        public bool Delete { get; set; }

        public Cards(string name, Characteristic characteristics)
        {
            Name = name;
            Characteristics = characteristics;
        }
    }
}
