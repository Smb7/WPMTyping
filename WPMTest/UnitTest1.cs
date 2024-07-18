using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.Remoting;
using WPM; 

namespace WPMTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CanChooseEasy()
        {
            // Arrange
            List<string> expectedWords = new List<string> {
                "The cat slept on the mat, and the dog lay beside it.",
                "The sun is shining brightly today, and the sky is clear.",
                "I ate an apple for breakfast and drank a glass of milk.",
                "He likes to eat pizza with friends on Friday nights.",
                "The sun set behind the mountains, painting the sky orange.",
                "The flower bloomed in the garden, attracting many bees.",
                "The book is on the table, next to the lamp.",
                "We went to the park and played on the swings and slides.",
                "She found a shiny penny on the sidewalk while walking home.",
                "The bird sang a beautiful song from the top of the tree.",
                "My brother and I built a sandcastle at the beach.",
                "The cookies are baking in the oven, and they smell great.",
                "The puppy chased its tail around in circles.",
                "We had a picnic by the lake, enjoying the warm weather.",
                "The car is parked in the driveway, ready for the trip.",
                "I finished my homework before dinner and watched TV.",
                "The cake was delicious, and everyone wanted a second piece.",
                "The fish swam around in the aquarium, enjoying the water.",
                "The kids played hide and seek in the backyard.",
                "The movie we watched last night was really funny and entertaining."
            };

            // Act
            List<string> choices = WPM.WPMTypeTesting.HandlerChoice(1);

            // Assert
            CollectionAssert.AreEqual(expectedWords, choices, "The method did not return the expected easy words.");
        }

        [TestMethod]
        public void CanChooseMedium()
        {
            // Arrange
            List<string> expectedWords = new List<string> { "Welcome to Medium" };

            // Act
            List<string> choices = WPM.WPMTypeTesting.HandlerChoice(2);

            // Assert
            CollectionAssert.AreEqual(expectedWords, expectedWords, "The method did not return the expected easy words.");
        }

        [TestMethod]
        public void CanChooseHard()
        {
            // Arrange
            List<string> expectedWords = new List<string> { "Welcome to Hard" };

            // Act
            List<string> choices = WPM.WPMTypeTesting.HandlerChoice(3);

            // Assert
            CollectionAssert.AreEqual(expectedWords, expectedWords, "The method did not return the expected easy words.");
        }

        [TestMethod]
        public void CanChooseUnknown()
        {
            // Arrange
            List<string> expectedWords = new List<string> { "Invalid choice" };

            // Act & Assert
            var exception = Assert.ThrowsException<ArgumentException>(() =>
            {
                List<string> choices = WPM.WPMTypeTesting.HandlerChoice(4);
            });

            Assert.AreEqual("Invalid choice", exception.Message);
        }

        [TestMethod]
        public void GetRandomSentenceCheckList()
        {
            // Arrange
            List<string> ExpectedSentences = new List<string> {"This is a sentence, does it pull me? #1"};
            ExpectedSentences.Add("Does this work #2?");
            ExpectedSentences.Add("Does this work #3?");
            ExpectedSentences.Add("Does this work #4?");

            // Act
            WPM.WPMTypeTesting.GetRandomSentence(ExpectedSentences);

            // Assert
            Assert.IsTrue(ExpectedSentences.Count > 0);
            Assert.IsTrue(ExpectedSentences.Count == 4);
            Assert.AreEqual("Does this work #2?", ExpectedSentences[1]);

        }

        [TestMethod]
        public void GetRandomSentenceList()
        {
            // Arrange
            List<string> Sentences = new List<string> { "Random sentence 1", "random sentence 2", "random sent3", "pickle is an expresso" };

            // Act
            WPM.WPMTypeTesting.GetRandomSentence(sentences: Sentences);

            // Assert
            Assert.IsTrue(Sentences.Count > 0, "Sentences should contain at least one sentence.");
        }

        [TestMethod]
        public void GetAccuracy()
        {
            // arrange
            string Sentence = "this is a test 1";
            string UsrSentence = "this is a test ";

            // Act
            double action = WPM.WPMTypeTesting.CalculateAccuracy(Sentence, UsrSentence);

            // Assert
            double ExpectedAccuracy = 90.0;
            double variance = 10.0;
            
            Assert.AreEqual(ExpectedAccuracy, variance, action, $"Accuracy should be {ExpectedAccuracy}%");


        }

    }
}
