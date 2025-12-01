using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Performance_Task___Team_JCAEK_
{
    public class FileManager
    {
        private readonly string filePath;

        public FileManager(string filePath)
        {
            this.filePath = filePath;

            // Create the file if it doesn't exist
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        // 🔹 Load all lines from the text file
        public List<string> LoadAll()
        {
            if (!File.Exists(filePath))
                return new List<string>();

            return File.ReadAllLines(filePath).ToList();
        }

        // 🔹 Add a new line of data
        public void AddLine(string data)
        {
            File.AppendAllText(filePath, data + Environment.NewLine);
        }

        // 🔹 Edit a line based on index
        public void EditLine(int index, string newData)
        {
            var lines = LoadAll();

            if (index < 0 || index >= lines.Count)
                throw new IndexOutOfRangeException("Invalid line index.");

            lines[index] = newData;
            File.WriteAllLines(filePath, lines);
        }

        // 🔹 Delete a line by index
        public void DeleteLine(int index)
        {
            var lines = LoadAll();

            if (index < 0 || index >= lines.Count)
                throw new IndexOutOfRangeException("Invalid line index.");

            lines.RemoveAt(index);
            File.WriteAllLines(filePath, lines);
        }

        // 🔹 Count number of lines in the file
        public int GetLineCount()
        {
            if (!File.Exists(filePath))
                return 0;
            return File.ReadAllLines(filePath).Length;
        }

        // 🔹 Find lines containing a keyword (optional search helper)
        public List<string> FindLines(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return new List<string>();

            return LoadAll()
                .Where(line => !string.IsNullOrEmpty(line) &&
                               line.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
