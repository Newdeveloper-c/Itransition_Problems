using Problem2;

string folderPath = "C:\\Users\\User\\Downloads\\task2";

var files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories)
                          .Where(s => s.EndsWith(".data"))
                          .ToArray();

var hashList = files.Select(file => Helper.CalculateSHA3256Hash(file, false))
                    .OrderBy(hash => hash)
                    .ToList();

string concatenatedHashes = string.Concat(hashList);
string str = string.Concat(concatenatedHashes, "numonjonturdimurodov@gmail.com");

Console.WriteLine(Helper.CalculateSHA3256Hash(str, true));
