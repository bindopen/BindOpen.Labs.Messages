using BindOpen.Data;

namespace BindOpen.Tests.Messages
{
    public static class GlobalVariables
    {
        static string _workingFolder = null;

        /// <summary>
        /// The storage URI folder.
        /// </summary>
        public static readonly string StorageUri = "https://storage.bindopen.org/";

        /// <summary>
        /// The global working folder.
        /// </summary>
        public static string WorkingFolder
        {
            get
            {
                if (_workingFolder == null)
                {
                    _workingFolder = (FileHelper.GetAppRootFolderPath() + @"data\").ToPath();
                }

                return _workingFolder;
            }
        }
    }

}
