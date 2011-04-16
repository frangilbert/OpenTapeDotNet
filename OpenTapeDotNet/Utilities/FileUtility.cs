using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace OpenTapeDotNet.Utilities
{
    public class FileUtility
    {
        public static bool DirectoryIsWriteable(string directoryPath)
        {
            // Get the access rules of the specified files (user groups and user names that have access to the file)
            var rules = Directory.GetAccessControl(directoryPath).GetAccessRules(true, true, typeof(System.Security.Principal.SecurityIdentifier));

            // Get the identity of the current user and the groups that the user is in.
            var groups = WindowsIdentity.GetCurrent().Groups;
            string sidCurrentUser = WindowsIdentity.GetCurrent().User.Value;

            // Check if writing to the file is explicitly denied for this user or a group the user is in.
            if (rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Deny && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData))
                return false;

            // Check if writing is allowed
            return rules.OfType<FileSystemAccessRule>().Any(r => (groups.Contains(r.IdentityReference) || r.IdentityReference.Value == sidCurrentUser) && r.AccessControlType == AccessControlType.Allow && (r.FileSystemRights & FileSystemRights.WriteData) == FileSystemRights.WriteData);
        
            
        }

        public static bool FileExists(string filePath)
        {
            string absoluteFilePath = ToAbsolutePath(filePath);
            return File.Exists(absoluteFilePath);
        }

        public static string ToAbsolutePath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}