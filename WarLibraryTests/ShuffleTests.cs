using System;
using System.Collections;
using System.Collections.Generic;
using WarLibrary;
using Xunit;

namespace WarLibraryTests
{
    class TestObject
    {
        public object Id { get; set; }
    }
    public class ShuffleTests
    {
        private readonly FisherYatesShuffler shuffler;

        public ShuffleTests()
        {
            shuffler = new FisherYatesShuffler();
        }
        [Fact]
        public void ShuffleShouldChangeListOfObjects()
        {
            // arrange
            List<TestObject> objects = new List<TestObject>() {
                new TestObject() { Id = 1},
                new TestObject() { Id = 2},
                new TestObject() { Id = 3},
                new TestObject() { Id = 4}
            };
            var expected = new List<TestObject>(objects);
            // act
            var actual = shuffler.Shuffle(objects);
            // assert
            Assert.NotEqual(expected, actual);
            Assert.IsType<List<TestObject>>(actual);

        }
        [Fact]

        public void ShuffleShouldChangeListOfChars()
        {
            // arrange
            List<char> chars = new List<char>() { 'a', 'b', 'c', 'd' };
            List<char> expected = new List<char>(chars);

            // act
            var actual = shuffler.Shuffle(chars);
            // assert
            Assert.NotEqual(expected, actual);
            Assert.IsType<List<Char>>(actual);
        }

        [Fact]
        public void ShuffleShouldChangeQueues()
        {
            // arrange
            Queue<TestObject> QueueOfObjects = new Queue<TestObject>();
            QueueOfObjects.Enqueue(new TestObject() { Id = 1 });
            QueueOfObjects.Enqueue(new TestObject() { Id = 2 });
            QueueOfObjects.Enqueue(new TestObject() { Id = 3 });
            QueueOfObjects.Enqueue(new TestObject() { Id = 4 });
            var expected = new Queue<TestObject>(QueueOfObjects);
            // act
            var actual = shuffler.Shuffle(QueueOfObjects);
            // assert
            Assert.NotEqual(expected, actual);
            Assert.IsType<Queue<TestObject>>(actual);
        }
     
    }
}
