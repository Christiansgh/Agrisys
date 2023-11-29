using Microsoft.Extensions.Logging;

namespace Agrisys.Logger {
    public static class Logger {
        private static string Path { get; set; } = "";

        public static void Init(string path) {
            Path = path;
        }

        public static void WriteLine(params string[] text) {
            using (var file = File.Open(Path, FileMode.OpenOrCreate)) {
                file.Seek(0, SeekOrigin.End);
                using (var stream = new StreamWriter(file)) {
                    stream.WriteLine(text);
                }
            }
        }

        public static List<List<string>> ReadLines() {
            var lines = File.ReadAllLines(Path);
            var output = new List<List<string>>();
            foreach (var line in lines) {
                output.Add(new List<string>(line.Split('|')));
            }

            return output;
        }
    }
}