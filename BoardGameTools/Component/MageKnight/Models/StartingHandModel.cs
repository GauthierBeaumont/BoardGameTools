﻿namespace BoardGameTools.Component.MageKnight.Models
{
    public class AttackingModel
    {
        public List<Cards> Cards { get; set; } = new();
        public bool Success { get; set; }
    }
}