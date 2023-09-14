namespace Lab_2___2910
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectRootFolder = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString();
            string filePath = projectRootFolder + "/videogames.csv";

            string filePathInterpolated = $"{projectRootFolder}{Path.DirectorySeparatorChar}videogames.csv";

            List<VideoGame> games = new List<VideoGame>(); // previous stuff from Lab 1

            using (var sr = new StreamReader(filePathInterpolated))
            {

                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();

                    string[] lineData = line.Split(','); //csvs are separated by ,

                    VideoGame game = new VideoGame()
                    {
                        //Name,Platform,Year,Genre,Publisher,NA_Sales,EU_Sales,JP_Sales,Other_Sales,Global_Sales 

                        Name = lineData[0],
                        Platform = lineData[1],
                        Year = Int32.Parse(lineData[2]),
                        Genre = lineData[3],
                        Publisher = lineData[4],
                        NA_Sales = Double.Parse(lineData[5]),
                        EU_Sales = Double.Parse(lineData[6]),
                        JP_Sales = Double.Parse(lineData[7]),
                        Other_Sales = Double.Parse(lineData[8]),
                        Global_Sales = Double.Parse(lineData[9]),

                    };

                    games.Add(game);
                }

            }

            games.Sort();


            // The code under this comment is all for part 2 

           
            // DICTIONARY PORTION

                Dictionary<string, string> namePublisher = new Dictionary<string, string>();

                foreach (var game in games)
                {

                if (!namePublisher.ContainsKey(game.Publisher) && !namePublisher.ContainsKey(game.Name)) // check for no duplicates
                {
                    namePublisher.Add(game.Name, game.Publisher); // adding the name + publisher
                }

                }

                 foreach (KeyValuePair<string, string> entry in namePublisher) // displaying each key + value
                {
                    Console.WriteLine("{0} is associated with {1}", entry.Key, entry.Value);
                // {0} is the key {1} is the value
                }

            Console.WriteLine("\n");
            Console.WriteLine("This is a demonstration of all keys and values for every NAME TO THEIR PUBLISHER");
            Console.WriteLine("Press any Key to see a LINQ search using Dictionaries");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("[LINQ] For the dictionary, which Publisher would you like to filter for?\n");
            string publisherResponse = Console.ReadLine();
            Console.WriteLine("\n");

            // DICTIONARY LINQ

            var dictionaryLINQ = namePublisher.Where(p => p.Value.Contains(publisherResponse));
            foreach (var p in dictionaryLINQ)
            {
                Console.WriteLine("{0} is associated with {1}", p.Key, p.Value);
            }

            Console.WriteLine("\nPress any Key to visualize a queue");
            Console.ReadKey();
            Console.Clear();

            // QUEUE PORTION

            Queue<VideoGame> gameQueue = new Queue<VideoGame>();

            foreach (var game in games)
            {
                gameQueue.Enqueue(game);
            }

            Console.WriteLine("The beginning of the OVERALL Game Queue is: \n" + gameQueue.First());
            Console.WriteLine("\nThe total count of games in this queue is: " + gameQueue.Count());

            // QUEUE LINQ

            Console.WriteLine("\n[LINQ] Filter out the queue using a platform of your choice. (e.g. - XOne, PS4, 3DS)"); // choose your response
            var platformResponse = Console.ReadLine();

            Console.Clear();

            Queue<VideoGame> platformGameQueue = new Queue<VideoGame>(); // PURPOSE OF THIS QUEUE IS TO SORT BY PLATFORM

            foreach (var game in games.Where(p => p.Platform == platformResponse)) // QUEUE utilizing a LINQ to filter a QUEUE solely based on platform
            {
                platformGameQueue.Enqueue(game); // every game for the platform you choose is now in queue
            }

            Console.WriteLine($"\nIn using LINQ, the beginning of the {platformResponse} Game Queue is: \n" + platformGameQueue.First());
            Console.WriteLine($"\nThe total count of games in this {platformResponse} queue is: " + platformGameQueue.Count());

            Console.Write("\nPress Y to see the next item in YOUR queue. Press N to ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write("continue "); 
            Console.ResetColor();
            Console.Write("to the default queue.\n");

            char queueResponse = Console.ReadLine().ToLower()[0];

            // LOOKING THROUGH ALL OF GAMES BASED ON PLATFORM OF CHOOSING

            if (queueResponse == 'y')
            {

                while (queueResponse == 'y') // while user is wanting to see next item
                {
                    Console.Clear();

                    var val = platformGameQueue.Dequeue();

                    if (platformGameQueue.Count > 0)
                    {
                        var next = platformGameQueue.Peek();
                        Console.WriteLine(next);
                    }

                    Console.WriteLine("\nEnter Y to see the next item in queue. Press N to skip to the to the default queue.");
                    Console.WriteLine("[UPDATED] Queue Count: " + platformGameQueue.Count());

                    queueResponse = Console.ReadLine().ToLower()[0];

                }

            }

            // LOOKING THROUGH ALL OF GAMES IN GAMEQUEUE

            Console.Clear(); 

            Console.WriteLine($"\nIn using LINQ, the beginning of the overall Game Queue is: \n" +gameQueue.First());
            Console.WriteLine($"\nThe total count of games in this overall queue is: " + gameQueue.Count());

            Console.WriteLine("\nEnter Y to see the next item in queue. Press N to skip to the stack section.");

            char userResponse = Console.ReadLine().ToLower()[0];

            if (userResponse == 'y')
            {

                while (userResponse == 'y') // while user is wanting to see next item
                {
                    Console.Clear();

                    var val = gameQueue.Dequeue();

                    if (gameQueue.Count > 0)
                    {
                        var next = gameQueue.Peek();
                        Console.WriteLine(next);
                    }

                    Console.WriteLine("\nEnter Y to see the next item in queue. Press N to skip to the stack section.");
                    Console.WriteLine("[UPDATED] Queue Count: " + gameQueue.Count());

                    userResponse = Console.ReadLine().ToLower()[0];

                }

            }
                Console.Clear();

                // STACK PORTION  

                Stack<VideoGame> gameStack = new Stack<VideoGame>(); // create stack

            // STACK LINQ


            foreach (var game in games.Where(p => p.Year >= 2000 && p.Year <= 2010)) // LINQ utilized to filter through year
            {
                gameStack.Push(game); // game is now being pushed into the stack
            }

            Console.WriteLine("Stack successfully completed. Current Stack Count of games from 2000-2010: " + gameStack.Count());

                Console.WriteLine("The current game at the top of the stack is: \n" + gameStack.Peek());

                Console.WriteLine("\nEnter the letter Y to see the top game being removed and to see the updated Stack.");
                Console.WriteLine("Otherwise, enter anything else to exit and terminate the program.");

            char stackUserResponse = Console.ReadLine().ToLower()[0];
      
            gameStack.Pop(); 

            if (stackUserResponse == 'y')
            {
                while (stackUserResponse == 'y')
                {
                    Console.Clear(); 
                    Console.WriteLine(gameStack.Pop());

                    Console.WriteLine("\nEnter the letter Y to see the top game being removed and to see the updated Stack.");
                    Console.WriteLine("Otherwise, enter anything other letter to exit and terminate the program.");
                    Console.WriteLine("[UPDATED] Stack Count: " + gameStack.Count());

                    stackUserResponse = Console.ReadLine().ToLower()[0];
                }
            }
                Console.Clear();
                Console.WriteLine("Thank you for reviewing my program :)");
                Console.WriteLine("By Logan Stegmaier"); 
        }
    }
}

