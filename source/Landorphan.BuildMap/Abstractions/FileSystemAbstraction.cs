using System;
using System.IO;
using System.Linq;

namespace Landorphan.BuildMap.Abstractions
{
    using Landorphan.Common;
    public class FileSystemAbstraction : IFileSystem
    {
        public string NormalizePath(string path)
        {
            path.ArgumentNotNull(nameof(path));
            return path.Replace("\\", "/", StringComparison.InvariantCulture).TrimEnd(
                Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
        }

        public string GetWorkingDirectory()
        {
            return NormalizePath(Directory.GetCurrentDirectory());
        }

        public string[] GetFiles(string path)
        {
            var baseFilePaths =
                (from p in Directory.GetFiles(NormalizePath(path), "*.*", SearchOption.AllDirectories) 
               select NormalizePath(p));
            return baseFilePaths.ToArray();
        }

        public string ReadFileContents(string path)
        {
            string retval = null;
            if (File.Exists(path))
            {
                using (var stream = File.OpenRead(path))
                using (var reader = new StreamReader(stream))
                {
                    retval = reader.ReadToEnd();
                }
            }

            return retval;
        }
    }
}