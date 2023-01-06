using BindOpen.Data;

namespace BindOpen.Tests.Messages
{
    public static class GlobalVariables
    {
        static string _workingFolder = null;

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
