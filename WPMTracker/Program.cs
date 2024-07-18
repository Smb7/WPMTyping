using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace WPM
{
    public class WPMTypeTesting
    {
        private static System.Timers.Timer aTimer;

        // All methods will be called into action here
        public static void Main(string[] args)
        {
            while (true) // Loop to allow repeating the process
            {
                // Starting by introduction
                Console.WriteLine("Welcome to WPM tester");
                Console.WriteLine("Select a difficulty:");
                Console.WriteLine("1. Easy");
                Console.WriteLine("2. Medium");
                Console.WriteLine("3. Hard");

                Console.WriteLine("Please enter your choice (1, 2, or 3): ");
                
                string num_input = Console.ReadLine();
                int choice = Convert.ToInt32(num_input);

                // Call HandlerChoice
                List<string> sentences = HandlerChoice(choice);

                // Get a random sentence
                string sentence = GetRandomSentence(sentences);
                Console.WriteLine(sentence);

                // Start the timer
                var stopwatch = new Stopwatch();
                stopwatch.Start();

                // Capture user input
                string userInput = Console.ReadLine();

                // Stop the timer
                stopwatch.Stop();

                // Display the user input
                Console.WriteLine("You entered: " + userInput);

                double elapsedTimeInSeconds = stopwatch.Elapsed.TotalSeconds;

                // Calculate WPM
                int wordCount = sentence.Split(' ').Length;
                double wordsPerMinute = (wordCount / elapsedTimeInSeconds) * 60;
                Console.WriteLine($"Time taken: {elapsedTimeInSeconds:F2} seconds");
                Console.WriteLine($"Words per minute: {wordsPerMinute:F2}");

                // Check accuracy
                double accuracy = CalculateAccuracy(sentence, userInput);
                Console.WriteLine($"Accuracy: {accuracy:F2}%");

                // Ask if the user wants to go again
                Console.WriteLine("Would you like to go again? (yes/no): ");
                string input = Console.ReadLine();
                if (input.ToLower() != "yes")
                {
                    break;
                }
            }
        }

        // This will handle the logic of choices
        public static List<string> HandlerChoice(int choice)
        {
            List<string> sentences;
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Welcome to Easy");
                    sentences = GetEasySentences();
                    break;
                case 2:
                    Console.WriteLine("Welcome to Medium");
                    sentences = GetMediumSentences();
                    break;
                case 3:
                    Console.WriteLine("Welcome to Hard");
                    sentences = GetHardSentences();
                    break;
                default:
                    throw new ArgumentException("Invalid choice");
            }

            return sentences;
        }

        private static List<string> GetEasySentences()
        {
            return new List<string>
            {
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
        }

        private static List<string> GetMediumSentences()
        {
            return new List<string>
            {
                "The elephant trumpeted loudly in the zoo, startling the nearby visitors.",
                "We climbed the mountain last summer and enjoyed the breathtaking view from the top.",
                "He worked on the computer all day, solving complex problems and writing code.",
                "Music filled the room with joy, creating a festive atmosphere for the party.",
                "The butterfly fluttered gracefully in the garden, landing on various flowers.",
                "The forest was filled with tall trees, creating a dense canopy overhead.",
                "She read a fascinating book about the mysteries of the universe.",
                "The chef prepared a gourmet meal, complete with an elaborate dessert.",
                "The students worked together on the project, each contributing their unique skills.",
                "The river flowed gently, reflecting the blue sky and the surrounding trees.",
                "We visited the museum and saw many interesting exhibits and artifacts.",
                "The rain poured down heavily, creating puddles on the ground.",
                "The children gathered around the campfire, listening to stories and roasting marshmallows.",
                "The scientist conducted experiments to test the new hypothesis.",
                "The city skyline was illuminated by the lights of the skyscrapers.",
                "The dog barked loudly at the mailman, who quickly walked away.",
                "She painted a beautiful landscape, capturing the essence of nature.",
                "The clock struck midnight, marking the start of a new day.",
                "The magician performed amazing tricks, leaving the audience in awe.",
                "The family went on a road trip, visiting several national parks and landmarks."
            };
        }

        private static List<string> GetHardSentences()
        {
            return new List<string>
            {
                "The sophisticated gentleman wore an elegant suit and a matching tie, exuding an air of confidence and poise.",
                "His eccentric behavior startled everyone at the party, leaving them wondering about his unusual past.",
                "Her resilience in the face of challenges was inspiring, motivating others to persevere despite difficulties.",
                "His impetuous decision to quit his job and travel the world surprised everyone, including his closest friends.",
                "The ineffable beauty of nature left us speechless as we hiked through the pristine wilderness.",
                "The enigma of the ancient artifact intrigued us, leading to months of research and exploration.",
                "The politician delivered a compelling speech, addressing the critical issues facing the nation with eloquence and clarity.",
                "The artist's latest exhibition featured a series of abstract paintings that challenged conventional perspectives.",
                "The complex machinery required precise calibration and maintenance to function optimally.",
                "The elaborate ceremony included traditional rituals, music, and dance, honoring the rich cultural heritage.",
                "The research team published a groundbreaking paper on the potential applications of quantum computing.",
                "The seasoned detective solved the perplexing case, uncovering the truth behind the mysterious disappearance.",
                "The concert pianist performed a challenging piece with remarkable skill and expression.",
                "The architect designed a sustainable building that incorporated innovative technologies for energy efficiency.",
                "The chef's signature dish featured an exquisite blend of flavors and textures, delighting the diners.",
                "The novel's intricate plot and well-developed characters kept readers engaged until the last page.",
                "The mountain climbers faced treacherous conditions as they ascended to the summit.",
                "The software developer implemented a complex algorithm to optimize the performance of the application.",
                "The biologist discovered a new species of insect in the remote rainforest.",
                "The financial analyst presented a detailed report on the market trends and investment opportunities."
            };
        }

        public static string GetRandomSentence(List<string> sentences)
        {
            var random = new Random();
            int index = random.Next(sentences.Count);
            return sentences[index];
        }

        public static double CalculateAccuracy(string originalSentence, string userSentence)
        {
            string[] originalWords = originalSentence.Split(' ');
            string[] userWords = userSentence.Split(' ');

            int correctWords = 0;
            int totalWords = originalWords.Length;

            for (int i = 0; i < totalWords && i < userWords.Length; i++)
            {
                if (originalWords[i].Equals(userWords[i], StringComparison.OrdinalIgnoreCase))
                {
                    correctWords++;
                }
            }

            return ((double)correctWords / totalWords) * 100;
        }
    }
}
