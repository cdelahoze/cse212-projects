using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {

        // Using a HashSet to store words we have already seen for O(1) lookup performance
        var seen = new HashSet<string>();
        // List to store the formatted strings of the pairs found
        var results = new List<string>();

        foreach (var word in words)
        {
            // To find a pair, we need to check if the reverse of the current word exists
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reverseWord = new string(charArray);

            // Check if the reverse of the current word was already added to the set
            if (seen.Contains(reverseWord))
            {
                // If found, we format the result as "word & reverseWord"
                results.Add($"{reverseWord} & {word}");
            }
            else
            {
                // If not found, add the current word to the set to check against future words
                seen.Add(word);
            }
        }

        // Convert the list of results back to an array as required by the function signature
        return results.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
         
            // The degree is in column 4 (index 3 because arrays start at 0)
            // I use Trim() to remove any accidental whitespace
            string degree = fields[3].Trim();

            // Check if the degree is already a key in our dictionary
            if (degrees.ContainsKey(degree))
            {
                // If it exists, increment the counter by 1
                degrees[degree]++;
            }
            else
            {
                // If it doesn't exist, add it to the dictionary with an initial count of 1
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // 1. Pre-process strings: Remove spaces and convert to lowercase as required
        string s1 = word1.Replace(" ", "").ToLower();
        string s2 = word2.Replace(" ", "").ToLower();

        // 2. If lengths are different, they cannot be anagrams
        if (s1.Length != s2.Length)
            return false;

        // 3. Create a dictionary to store character frequencies
        var letterCounts = new Dictionary<char, int>();

        // 4. Count the frequency of each letter in the first word
        foreach (char c in s1)
        {
            if (letterCounts.ContainsKey(c))
                letterCounts[c]++;
            else
                letterCounts[c] = 1;
        }

        // 5. Compare with the second word by decrementing the counts
        foreach (char c in s2)
        {
            // If the letter was never in word1, it's not an anagram
            if (!letterCounts.ContainsKey(c))
                return false;

            letterCounts[c]--;

            // If a letter appears more times in word2 than in word1, count becomes negative
            if (letterCounts[c] < 0)
                return false;
        }

        // 6. If we reached here and lengths were equal, all counts must be zero
        return true;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return [];
    }
}