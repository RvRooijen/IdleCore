using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace IdleCore.Tests
{
    public class DropTableTests
    {
        private Item _salad;
        private Item _potato;
        private Item _beef;
        private Item _sword;
        private Item _rock;
        private Item _hat;
        private Item _house;
        private Item _cat;

        private DropTable _dropTable;
        
        public DropTableTests(ITestOutputHelper testOutputHelper)
        {
            _salad = new Item("Salad");
            _potato = new Item("Potato");
            _beef = new Item("Beef");
            _sword = new Item("Sword");
            _rock = new Item("Rock");
            _hat = new Item("Hat");
            _house = new Item("House");
            _cat = new Item("Cat");
            
            _dropTable = new DropTable(new List<Tuple<IDroppable, int>>()
            {
                new(_salad, 4),
                new(_potato, 6),
                new(_beef, 10),
                new(_sword, 58),
                new(_rock, 2),
                new(_hat, 1),
                new(_house, 40),
                new(_cat, 999),
            });
        }
        
        [Fact]
        public void GetNormalizedWeight_ItemsInDropTable_ShouldReturnCorrectValue()
        {
            _dropTable.GetNormalizedWeight(_salad).Should().Be(0.00357142859F);
            _dropTable.GetNormalizedWeight(_potato).Should().Be(0.005357143f);
        }
        
        [Fact]
        public void Roll_MultipleItems_ShouldReturnItem()
        {
            _dropTable.Roll(new Random()).Should().NotBeNull();
        }
        
        [Fact]
        public void AddDrop_EmptyDropTable_ShouldAddItem()
        {
            Item testItem = new Item("Test");
            DropTable newDropTable = new DropTable(new List<Tuple<IDroppable, int>>());
            newDropTable.AddDrop(testItem, 50);
            newDropTable.TotalWeight.Should().Be(50);
        }
        
        [Fact]
        public void Roll_SingleItem_ShouldDrop()
        {
            Item testItem = new Item("Test");
            DropTable newDropTable = new DropTable(new List<Tuple<IDroppable, int>>());
            newDropTable.AddDrop(testItem, 50);
            newDropTable.Roll(new Random()).Should().Be(testItem);
        }
        
        [Fact]
        public void Roll_MultipleDropTables_ShouldReturnItem()
        {
            DropTable dropTable = new DropTable(new List<Tuple<IDroppable, int>>());
            dropTable.AddDrop(_dropTable, 1);

            var random = new Random();
            IDroppable droppable = dropTable.Roll(random);
            droppable.Should().BeOfType<Item>();
        }
        
        [Fact]
        public void TotalWeight_ItemsInDropTable_ShouldReturnCorrectValue()
        {
            _dropTable.TotalWeight.Should().Be(1120);
        }
    }
}