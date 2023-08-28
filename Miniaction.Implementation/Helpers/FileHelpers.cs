using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Miniaction.Implementation.Helpers
{
    public static class FileHelpers
    {
        public static string GetFileExtensionFromBase64File(string base64File)
        {
            var regex = new Regex(@"^data:(?<type>[\w/\-\.]+);");
            var match = regex.Match(base64File);
            if (match.Success)
            {
                var contentType = match.Groups["type"].Value.Trim();
                var fileExtension = "." + contentType.Split("/")[1];
                return fileExtension;
            }
            return string.Empty;
        }
        public static string GenerateUniqueFileName(string label, string fileExtension)
        {
            string guid = Guid.NewGuid().ToString();
            return $"{guid}{label}{fileExtension}";
        }
        public static bool TrailerExtensionChecker(string trailer)
        {
            string[] allowedExtensions =
            {
                ".mp4",
                ".m4v",
                ".mkv",
                ".avi",
                ".wmv"
            };
            string extension = GetFileExtensionFromBase64File(trailer);
            if(string.IsNullOrEmpty(extension)){
                throw new Exception("Invalid trailer file.");
            }
            return allowedExtensions.Any(t => t.Equals(extension));
        }
        public static bool AvatarExtensionChecker(string avatar)
        {
            string[] allowedExtensions =
            {
                ".jpg",
                ".jpeg",
                ".png",
                ".webp"
            };
            string extension = GetFileExtensionFromBase64File(avatar);
            if (string.IsNullOrEmpty(extension))
            {
                throw new Exception("Invalid avatar file.");
            }
            return allowedExtensions.Any(a => a.Equals(extension));
        }
    }
}
