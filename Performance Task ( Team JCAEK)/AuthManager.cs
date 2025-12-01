using System;
using System.IO;
using System.Linq;

namespace Performance_Task___Team_JCAEK_
{
    public class AuthManager
    {
        private readonly string userFilePath;

        public AuthManager(string filePath)
        {
            userFilePath = filePath;

            // Create file if it doesn't exist
            if (!File.Exists(userFilePath))
            {
                File.Create(userFilePath).Close();
            }
        }

        public bool AuthenticateUser(string username, string password)
        {
            // Return false immediately if input invalid
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            // Load all user lines
            var lines = File.ReadAllLines(userFilePath);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var parts = line.Split(',');

                if (parts.Length < 2)
                    continue;

                string storedUsername = parts[0].Trim();
                string storedPassword = parts[1].Trim();

                if (string.Equals(storedUsername, username, StringComparison.OrdinalIgnoreCase) &&
                    storedPassword == password)
                {
                    return true; // Match found
                }
            }
            return false; // No match found
        }
    }
}
