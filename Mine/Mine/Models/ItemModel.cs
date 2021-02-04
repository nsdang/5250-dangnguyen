﻿using System;
using SQLite;

namespace Mine.Models
{
    /// <summary>
    /// Iterms for the Characters and Monsters to use
    /// </summary>
    public class ItemModel
    {
        // The Id for the Item
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        // The Display Text for the Item
        public string Text { get; set; }

        // The Description for the Item
        public string Description { get; set; }

        // The value of the Item +9 Damage
        public int Value { get; set; } = 0;
    }
}