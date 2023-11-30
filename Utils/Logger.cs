using System.IO;

namespace Agrisys.Utils {
    public static class Logger {
        private static string Folder { get; set; } = "";

        public static void Init(string folder) {
            Folder = folder;
            Directory.CreateDirectory(Folder);
        }

        public static void Write(params string[] items) {
            using (var file = File.Open(Path.Combine(Folder, DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")), FileMode.OpenOrCreate)) {
                file.Seek(0, SeekOrigin.End);
                using (var stream = new StreamWriter(file)) {
                    foreach (var item in items) {
                        stream.Write(item);

                        if (item != items.Last()) {
                            stream.Write("|");
                        }
                    }
                }
            }
        }

        //public static List<List<string>> Read() {
            public static dynamic Read() {
            var files = Directory.GetFiles(Folder);

            var output = new List<List<string>>();
            var columns = 0;
            
            foreach (var file in files) {
                var lines = File.ReadAllLines(file);
                var entry = new List<string>{Path.GetFileName(file)};

                foreach (var line in lines) {
                    var items = line.Split('|');
                    if (columns < items.Count()) {
                        columns = items.Count();
                    }

                    foreach (var item in items) {
                        entry.Add(item);
                    }

                    output.Add(entry);
                }
            }

            return new { columnCount = columns, data = output };
        }
    }
}