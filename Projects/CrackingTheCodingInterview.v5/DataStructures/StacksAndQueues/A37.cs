using System;
using System.Collections.Generic;
using Common;
using Common.DataStructures.LinkedLists;

namespace CrackingTheCodingInterview.v5.DataStructures.StacksAndQueues
{
    public class A37: IProgram
    {
        public enum AnimalType
        {
            Cat,
            Dog
        }

        public class Animal
        {
            public int Order { get; }
            public AnimalType AnimalType { get; }

            private Animal(AnimalType animalType, int order)
            {
                this.Order = order;
                this.AnimalType = animalType;
            }

            public static Animal Create(AnimalType animalType, int order)
            {
                return new Animal(animalType, order);
            }
        }

        public class AnimalShelter
        {
            private int counter;
            private readonly IDictionary<AnimalType, Node<Animal>> heads;
            private readonly IDictionary<AnimalType, Node<Animal>> tails;

            public AnimalShelter()
            {
                counter = 0;
                heads = new Dictionary<AnimalType, Node<Animal>>();
                heads.Add(AnimalType.Cat, null);
                heads.Add(AnimalType.Dog, null);

                tails = new Dictionary<AnimalType, Node<Animal>>();
                tails.Add(AnimalType.Cat, null);
                tails.Add(AnimalType.Dog, null);
            }

            public void Push(AnimalType animalType)
            {
                Node<Animal> tail = tails[animalType];
                var node = Nodes.Create(Animal.Create(animalType, counter++));
                if (tail == null)
                {
                    heads[animalType] = node;
                    tails[animalType] = node;
                    return;
                }

                tail.Next = node;
                tails[animalType] = node;
            }

            public Animal Pop(AnimalType animalType)
            {
                Node<Animal> head = heads[animalType];
                if (head == null)
                {
                    throw new Exception("No animal found");
                }

                heads[animalType] = head.Next;
                return head.Data;
            }

            public Animal PopAny()
            {
                int catOrder = heads[AnimalType.Cat]?.Data?.Order ?? int.MaxValue;
                int dogOrder = heads[AnimalType.Dog]?.Data?.Order ?? int.MaxValue;
                AnimalType selected = catOrder < dogOrder ? AnimalType.Cat : AnimalType.Dog;
                var animal = Pop(selected);
                return animal;
            }
        }

        public void Run(string[] args)
        {
            AnimalShelter animalShelter = new AnimalShelter();
            animalShelter.Push(AnimalType.Dog);
            animalShelter.Push(AnimalType.Dog);
            animalShelter.Push(AnimalType.Cat);
            animalShelter.Push(AnimalType.Cat);

            animalShelter.Pop(AnimalType.Dog);
            animalShelter.PopAny();
            animalShelter.PopAny();
            animalShelter.Pop(AnimalType.Cat);
        }
    }
}
